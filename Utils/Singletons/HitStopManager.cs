using Godot;

public partial class HitStopManager : Node
{
	bool isWaiting;
	
	public void hitStop() {
		if(isWaiting)
			return;
		Engine.TimeScale = 0.0f;
		this.wait(2.0f);
	}

	public void wait(float duration) {
		isWaiting = true;
		GetTree().CreateTimer(duration);
		Engine.TimeScale = 1.0f;
		isWaiting = false;		
	}
}
