using Godot;
using System;
using System.Runtime.CompilerServices;

//Contains the movement stats and adjusts direction with necessary velocity
[GlobalClass]
public partial class MovementStatComponent : Node
{
	[Export]
	MovementComponent ThisCharacter;
	float Acceleration;
	[Export]
	private float WalkSpeed = 5.0f;
	[Export]
	private float RunSpeed = 7.5f;
	private Vector3 InputDirection = Vector3.Zero;
	[Export]
	private float JumpVelocity = 5.0f;
	private bool Running = false;
	private bool Jumping = false;

	public void SetInputDirection(Vector3 moveDirection)
	{
		InputDirection = moveDirection;
	}

	public void SetRunning(bool isRunning)
	{
		Running = isRunning;
	}

	public void SetJumping(bool isJumping)
	{
		if(!Jumping && ThisCharacter.IsOnFloor() && isJumping)
		{
			Jumping = true;
		} else
		{
			Jumping = false;
		}
	}

	public bool GetJumping()
	{
		return Jumping;
	}

	public float GetJumpingSpeed()
	{
		return JumpVelocity;
	}

	public float GetMaxSpeed()
	{
		return Running ? RunSpeed : WalkSpeed;
	} 

	public Vector3 GetVelocity()
	{
		Vector3 Direction = InputDirection;

		if(Direction != Vector3.Zero)
		{
			Direction.X = Direction.X * GetMaxSpeed();
			Direction.Z = Direction.Z * GetMaxSpeed();
		} else
		{
			Direction.X = Mathf.MoveToward(ThisCharacter.Velocity.X, 0, GetMaxSpeed());
			Direction.Z = Mathf.MoveToward(ThisCharacter.Velocity.Y, 0, GetMaxSpeed());
		}

		return Direction;
	}
}
