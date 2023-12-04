using Godot;
using System;

public partial class cards : CharacterBody2D
{

	private Sprite2D sprite;

	public void ChangeSprite(int indexNumber) {
		sprite = GetNode<Sprite2D>("Sprite2D");
		if (indexNumber == 0) {
		Texture2D bananasymbol = GD.Load<Texture2D>("res://banana.webp");
		sprite.Texture = bananasymbol;
		sprite.Scale = new Vector2(0.05f, 0.05f);
		}
		else if (indexNumber == 1) {
		Texture2D bananasymbol = GD.Load<Texture2D>("res://360_F_325616239_jPMacbnlr5hNYLBOazcKMtwvLWGKUEy3.jpeg");
		sprite.Texture = bananasymbol;
		sprite.Scale = new Vector2(0.1f, 0.1f);
		}
	}


	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
