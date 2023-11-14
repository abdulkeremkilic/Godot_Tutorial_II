using Godot;

public partial class score : Label
{
	public int scoreLable = 0;

	private void onMobKilled() {
		scoreLable += 1;
		this.Text = "SCORE: " + scoreLable;
	}
	
}
