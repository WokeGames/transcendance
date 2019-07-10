using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Array = Godot.Collections.Array;

namespace RogueCity.Scripts.CSharp
{
	public class Biomes : Node2D
	{
		public GroundTileScript[] tiles;
		[Export]
		public int size = 0;
		public override void _Ready()
		{
			var biomes = GetChildren();
			Array[] tilesTemp = new Array[biomes.Count];
			int index = 0;
			int count = 0;
			foreach (var b in biomes.OfType<Node2D>())
			{
				tilesTemp[index] = b.GetChildren();
				count += tilesTemp[index].Count;
				index++;
			}
			tiles = new GroundTileScript[count];
			index = 0;
			foreach (var gts in tilesTemp.OfType<GroundTileScript>())
			{
				tiles[index] = gts;
			}
			size = tiles.Count();
			GD.Print(size);
		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	} 
}
