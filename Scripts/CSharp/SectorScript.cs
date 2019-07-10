using Godot;
using System;
using RogueCity.Classes;
using System.Linq;
namespace RogueCity.Scripts.CSharp
{

	public class SectorScript : Node
	{
		public GroundTileScript[] groundTiles;
		public GroundTileScript LeftTile;
		public GroundTileScript RightTile;
		public SectorScript LeftSector;
		public SectorScript RightSector;
		public int Size;
		private Biomes Biomes;

		public SectorScript( SectorScript leftSector, SectorScript rightSector, int size, Biomes biomes)
		{
			Size = size;
			LeftSector = leftSector;
			RightSector = rightSector;
			Biomes = biomes;
			groundTiles = new GroundTileScript[Size];
			GenerateSector();
		}
		public override void _Ready()
		{
		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }

		private void GenerateSector()
		{
			Random r = new Random();
			int biomeSize = r.Next() % 5 + 3;
			Biome currentBiome = r.Next() % 2 == 1 ? Biome.Forest : Biome.Winter;
			var startLeft = true;
			if (LeftSector != null)
			{
				currentBiome = LeftSector.RightTile.Biome;
				startLeft = false;
			}
			else
			{
				if (RightSector!=null)
				{
					currentBiome = RightSector.LeftTile.Biome;
				}
			}
			int lastFilledTile = 0;
			if( startLeft)
			{
				lastFilledTile = groundTiles.Length - 1;
			}
			int firstEmptyTileIndex = startLeft ? 0 : groundTiles.Length - 1;
			while (groundTiles[lastFilledTile] == null)
			{
				var tilesOfBiome = Biomes.tiles.Where(t => t.Biome == currentBiome).ToList();
				var tilesLeft = groundTiles.Count(t => t == null);
				var biomeSectorTemp = new GroundTileScript[biomeSize];
				for (int i = 0; i < biomeSize; i++)
				{
					biomeSectorTemp[i] = new GroundTileScript(tilesOfBiome[r.Next()%tilesOfBiome.Count]);
				}
				firstEmptyTileIndex = CopyTempInSector(biomeSectorTemp, startLeft, firstEmptyTileIndex);
				currentBiome = r.Next() % 2 == 1 ? Biome.Forest : Biome.Winter;
			}
		}

		public override string ToString()
		{
			string retVal = "";
			foreach (var t in groundTiles.Where(t=> t !=null))
			{
				retVal = t.Sprite.Name+" ";
			}
			return base.ToString();
		}

		private int CopyTempInSector(GroundTileScript[] tiles, bool startLeft, int firstEmptyTileIndex)
		{
			var emptyTiles = groundTiles.Count(t => t == null);
			var tilesToAdd = Math.Min(emptyTiles, tiles.Length);
			if (startLeft)
			{
				for (int i = firstEmptyTileIndex, j=0; i < tilesToAdd; i++, j++)
				{
					groundTiles[i] = tiles[j];
				}
			}
			else
			{
				for (int i = firstEmptyTileIndex, j=0; j < tilesToAdd; i--, j++)
				{
					groundTiles[i] = tiles[j];
				}
			}
			return firstEmptyTileIndex + tilesToAdd;
		}
	}

}