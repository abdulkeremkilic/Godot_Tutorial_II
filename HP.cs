using Godot;
using System;

public partial class HP : Label
{
	public override void _Process(double delta)
	{
		var player = (player) GetNode<CharacterBody2D>("../../Player/Player");
		String healtBar = "HP: "  + player.health;
		this.Text = healtBar;
	}
}
