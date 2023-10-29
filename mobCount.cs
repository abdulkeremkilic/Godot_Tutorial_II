using Godot;
using System;

public partial class mobCount : Label
{
	public override void _Process(double delta)
	{
		var node = GetNode<Node2D>("../../Mobs");
		
		String mobCount = "Mob Count: "  + node.GetChildCount();
		this.Text = mobCount;
	}
}
