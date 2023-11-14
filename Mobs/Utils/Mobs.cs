using Godot;
using System;

public partial class Mobs : Node2D
{

	private void onTimeout() {
		var mobScene = GD.Load<PackedScene>("res://Mobs/frog.tscn");
		CharacterBody2D mob = mobScene.Instantiate<CharacterBody2D>();
		GD.Randomize();
		mob.Position = new Vector2(GD.RandRange(50, 1500), GD.RandRange(0, 35)); // random düzgün değil.

		if(this.GetChildCount() < Globals.MAX_MOB)
			this.AddChild(mob);
	}
}
