using Godot;
using System;

public partial class bg : ParallaxBackground
{

	private float scrollingSpeed = 100;

	public override void _Process(double delta)
	{
		Vector2 scrollOffset = ScrollOffset;
		scrollOffset.X -= scrollingSpeed * (float) delta; //minus is because we want bg to move to left.
		ScrollOffset = scrollOffset;//We have to do this to change the variable that actually holds the refference!
	}
}
