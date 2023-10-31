using Godot;
using System;

public partial class gameOver : Node2D
{

	private void onPlayAgainButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://World/world.tscn");
	}

	private void onMainMenuButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Menus/main.tscn");
	}

}
