using Godot;
using System;

public partial class player : CharacterBody2D
{
	private int jumpCounter = 0;
	public long health = 10;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private AnimationPlayer animations;
	Vector2 velocity;

	public override void _Ready()
	{
		animations = GetNode<AnimationPlayer>("AnimationPlayer");
		animations.Play("idle");
	}
	public override void _PhysicsProcess(double delta)
    {

        if (this.health <= 0)
        {
            GetTree().ChangeSceneToFile("res://Menus/gameOver.tscn");
        }

        velocity = Velocity;

        renewJumpAction();

        // Add the gravity.
        if (!IsOnFloor())
            velocity.Y += gravity * (float)delta;

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && jumpCounter <= Globals.MAX_JUMP_LIMIT)
        {
            velocity.Y = Globals.JUMP_VELOCITY;
            animations.Play("jump");
            jumpCounter += 1;
        }

        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        if (direction == Vector2.Left && !Input.IsActionJustPressed("ui_right"))
            GetNode<AnimatedSprite2D>("Animations").FlipH = true;
        else if (direction == Vector2.Right && !Input.IsActionJustPressed("ui_left"))
            GetNode<AnimatedSprite2D>("Animations").FlipH = false;


        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Globals.SPEED;
            if (velocity.Y == 0)
                animations.Play("run");
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Globals.SPEED);
            if (velocity.Y == 0)
                animations.Play("idle");
        }

        if (velocity.Y > 0)
            animations.Play("fall");

        Velocity = velocity;
        MoveAndSlide();
    }

    private void renewJumpAction()
    {
        if (IsOnFloor())
            jumpCounter = 0;
    }

    private void onBodyEntered(Node2D body)
	{
		if (body.IsInGroup("Mob"))
		{
			this.velocity.Y = Globals.BOUNCE_VELOCITY_Y;
			Velocity = velocity;
		}
	}

	private void onHurtBodyEntered(Node2D body)
	{
		if (body.IsInGroup("Mob"))
		{
			this.health -= 2;
			animations.Play("hurt");
			Vector2 direction = (this.Position - this.Position).Normalized();
			this.velocity.Y = Globals.BOUNCE_VELOCITY_Y;
			this.velocity.X = - direction.X *  Globals.BOUNCE_VELOCITY_X; // TODO: doesnt work; it may be try to override something! 
			Velocity = velocity;
		}
	}

}
