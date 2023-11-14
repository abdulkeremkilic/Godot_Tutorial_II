using Godot;
using System;

public partial class fps : Label
{
	public override void _Process(double delta)
	{
		String fps = "fps: " + Engine.GetFramesPerSecond();
		this.Text = fps;
	}
}
