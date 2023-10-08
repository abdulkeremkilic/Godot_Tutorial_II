using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private AnimationPlayer animations;

    public override void _Ready()
    {
		animations = GetNode<AnimationPlayer>("AnimationPlayer");
		animations.Play("idle");
    }
    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			animations.Play("jump");
		}

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if(direction == Vector2.Left)
			GetNode<AnimatedSprite2D>("Animations").FlipH = true;
		else if(direction == Vector2.Right)
			GetNode<AnimatedSprite2D>("Animations").FlipH = false;


		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			if(velocity.Y == 0)
				animations.Play("run");
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			if(velocity.Y == 0)
				animations.Play("idle");
		}

		if(velocity.Y > 0)
			animations.Play("fall");

		Velocity = velocity;
		MoveAndSlide();
	}
}
