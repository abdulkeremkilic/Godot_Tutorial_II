using Godot;
using System;

public partial class frog : CharacterBody2D
{
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private AnimationPlayer animations;
	private Boolean isChasing = false;
	private player player;
	Vector2 velocity;
	Vector2 direction;


	public override void _Ready()
	{
		animations = GetNode<AnimationPlayer>("AnimationPlayer");
		animations.Play("idle");
		player = (player)GetNode<CharacterBody2D>("../../Player/Player");
	}

	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;

		}


		if (isChasing && velocity.Y == 0)
		{

			direction = (player.Position - this.Position).Normalized(); //Player's location
			if (direction.X > 0)
				GetNode<AnimatedSprite2D>("Animations").FlipH = true;
			else
				GetNode<AnimatedSprite2D>("Animations").FlipH = false;

			animations.Play("jump");
			//if collides attack!
			velocity.X = direction.X * Globals.MOB_SPEED;
		}
		else if (!isChasing)
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

	private void onHurtAreaEntered(Node2D body)
	{
		if (body.Name == "Player")
		{
			isChasing = false;
			animations.Play("death");
			this.QueueFree();
		}
	}

	private void onPlayerCollitionEntered(Node2D body)
	{
		if (body.Name == "Player")
		{
			//this.player.health -= 2;
			//add health here for 
		}
	}

	private void onAttackFallBack(Node2D body)
	{
		if (body.Name == "Player")
		{
			direction = (player.Position - this.Position).Normalized();
			this.velocity.X = direction.X * Globals.BOUNCE_VELOCITY_X;
			this.velocity.Y = Globals.BOUNCE_VELOCITY_Y;
			Velocity = velocity;
		}
	}

}
