using Godot;
using System;

public partial class frog : CharacterBody2D
{
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private const float Speed = 50f;
	private AnimationPlayer animations;
	private Boolean isChasing = false;
	private Node2D player;

    public override void _Ready()
    {
		animations = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;

		}


		if (isChasing)
		{
			
			player = GetNode<Node2D>("../../Player/Player");
			Vector2 direction = (player.Position - this.Position).Normalized();
			if (direction.X > 0)
				GetNode<AnimatedSprite2D>("Animations").FlipH = true;
			else
				GetNode<AnimatedSprite2D>("Animations").FlipH = false;

			animations.Play("jump");
			//if collides attack!
			velocity.X = direction.X * Speed;
		}
		else
		{
			animations.Play("idle");
			velocity.X = 0;
		}


		Velocity = velocity;

		MoveAndSlide();
	}

	private void onBodyEntered(Node2D body)
	{
		if (body.Name == "Player")
			isChasing = true;
	}

	private void onBodyExit(Node2D body)
	{
		if (body.Name == "Player")
			isChasing = false;

	}
}
