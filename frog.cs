using Godot;
using System;

public partial class frog : CharacterBody2D
{
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private const float Speed = 50f;
	private const float fallBackVelocityY = -400f;
	private const float fallBackVelocityX = 200f;

	private AnimationPlayer animations;
	private Boolean isChasing = false;
	private player player;
	Vector2 velocity;
	Vector2 direction;


	public override void _Ready()
	{
		animations = GetNode<AnimationPlayer>("AnimationPlayer");
		animations.Play("idle");
	}

	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		player = (player)GetNode<CharacterBody2D>("../../Player/Player");


		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;

		}


		if (isChasing)
		{

			direction = (player.Position - this.Position).Normalized();
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
			this.player.health -= 2;
		}
	}

	private void onAttackFallBack(Node2D body)
	{
		if (body.Name == "Player")
		{
			direction = (player.Position + this.Position).Normalized();
			this.velocity.Y = fallBackVelocityY;
			this.velocity.X = direction.X * fallBackVelocityX; // TODO: doesnt work check why
			Velocity = velocity;
		}
	}

}
