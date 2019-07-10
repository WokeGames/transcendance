using Godot;
using System;
using RogueCity.Classes;
namespace RogueCity.Scripts.CSharp
{
    public class GroundTileScript : Node
    {
        [Export]
        public Biome LeftLinksTo;
        [Export]
        public Biome RightLinksTo;
        [Export]
        public Biome Biome;
        [Export]
        public Sprite Sprite;

		public GroundTileScript(GroundTileScript tile)
		{
			LeftLinksTo = tile.LeftLinksTo;
			RightLinksTo = tile.RightLinksTo;
			Biome = tile.Biome;
			Sprite = tile.Sprite;
		}
		public GroundTileScript()
		{

		}
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {

        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {

        }
    }

}