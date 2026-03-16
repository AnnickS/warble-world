using Godot;
using System;

[GlobalClass]
public partial class InputComponent : Node
{
	[Export]
	MovementStatComponent CharacterStats;
	[Export]
	Camera3D PlayerCamera;

	public override void _PhysicsProcess(double delta)                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
	{
		if (Input.IsActionJustPressed("Jump"))
		{
			CharacterStats.SetJumping(true);
		}

		if (Input.IsActionJustPressed("Run"))
		{
			CharacterStats.SetRunning(true);
		}

		if (Input.IsActionJustReleased("Run"))
		{
			CharacterStats.SetRunning(false);
		}

		// Left/Right = X , Up/Down = Y
		Vector2 InputDir = Input.GetVector("Move_Left", "Move_Right", "Move_Up", "Move_Down");
		Vector3 StrafeDir = PlayerCamera.GlobalTransform.Basis.X * InputDir.X;
		Vector3 ForwardDir = PlayerCamera.GlobalTransform.Basis.Z * InputDir.Y;
		Vector3 Direction = new Vector3(StrafeDir.X + ForwardDir.X, 0, StrafeDir.Z + ForwardDir.Z).Normalized();

		CharacterStats.SetInputDirection(Direction);
	}
}
