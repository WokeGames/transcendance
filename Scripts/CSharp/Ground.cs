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

	public class Ground : Node2D
	{
		[Export]
		int SectorSize = 20;
		Biomes biomes;
		SectorScript leftMostSector;
		SectorScript rightMostSector;
		List<SectorScript> sectors;
		public override void _Ready()
		{
			sectors = new List<SectorScript>();
			biomes = GetParent().GetChildren().OfType<Biomes>().FirstOrDefault();
			GD.Print(biomes.size);
			leftMostSector = new SectorScript(null, null, SectorSize, biomes);
			rightMostSector = leftMostSector;
			GD.Print(leftMostSector.Size);
			sectors.Add(leftMostSector);
			AddSectorLeft();
			AddSectorRight();
			GD.Print("sectors : " + sectors.Count);
			var sector = leftMostSector;
			while (sector.RightSector != null)
			{
				GD.Print(sector.ToString());
				sector = sector.RightSector;
			}
			GD.Print(sector.ToString());
		}

		private void AddSectorLeft()
		{
			var newSector = new SectorScript(leftMostSector, null, SectorSize, biomes);
			sectors.Add(newSector);
			newSector.RightSector = leftMostSector;
			leftMostSector.LeftSector = newSector;
			leftMostSector = newSector;
		}

		private void AddSectorRight()
		{
			var newSector = new SectorScript(rightMostSector, null, SectorSize, biomes);
			sectors.Add(newSector);
			newSector.LeftSector = rightMostSector;
			rightMostSector.RightSector = newSector;
			rightMostSector = newSector;
		}
		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}

}