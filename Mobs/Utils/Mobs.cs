using Godot;
using System;

public partial class Mobs : Node2D
{
	private long MAX_MOB = 5;

	private void onTimeout() {
		var mobScene = GD.Load<PackedScene>("res://Mobs/frog.tscn");
		CharacterBody2D mob = mobScene.Instantiate<CharacterBody2D>();
		GD.Randomize();
		mob.Position = new Vector2(GD.RandRange(50, 1500), GD.RandRange(0, 35));

		if(this.GetChildCount() < MAX_MOB)
			this.AddChild(mob);
	}
}
