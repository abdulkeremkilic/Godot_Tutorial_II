using Godot;
using System;

public partial class ScoreManager : Node
{
	public long score;

	public void setScore(long score) {this.score = score;}
	
	public long getScore() {return this.score;}
}
