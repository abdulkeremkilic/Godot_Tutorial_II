using Godot;
using System;

public partial class score : Label
{
	int scoreLable = 0;

	private void onFrogTreeExited() {
		
		var node = GetNode<Node2D>("../../Mobs");
		node.GetChildCount();
	}

	
}
