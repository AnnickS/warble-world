using Godot;
using System;
using System.Diagnostics;

public partial class MovementComponent : CharacterBody3D
{
	[Export]
	MovementStatComponent CharacterStats;

	//Moves the character in the given direction with the given velocity
	//Applies gravity if the character is in not touching the floor (can/should be adjusted for floating entities)
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (CharacterStats.GetJumping())
		{
			CharacterStats.SetJumping(false);
			velocity.Y = CharacterStats.GetJumpingSpeed();
		}

		Vector3 newVelocity = CharacterStats.GetVelocity();
		velocity.X = newVelocity.X;
		velocity.Z = newVelocity.Z;

		Velocity = velocity;
		MoveAndSlide();
	}
}
