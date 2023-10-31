using Godot;
using System;

public partial class main : Node2D
{

	private void onQuitButtonPressed() 
	{
		GetTree().Quit();
	}

	private void onPlayButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://World/world.tscn");
	}

}
