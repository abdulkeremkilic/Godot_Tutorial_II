using Godot;
using System;

public partial class Globals : Node
{
		Signal killed;

		long enemyKilledCounter = 0;

	public void enemyKilled() {
		enemyKilledCounter += 1;
		EmitSignal("killed");
	}
}
