using Godot;
using System;
using System.Diagnostics;
using System.Numerics;

[GlobalClass]
public partial class PlayerCamera : SpringArm3D
{
	[Export]
	Node3D CameraPivot;
	float TiltLimitTop = Mathf.DegToRad(65);
	float TiltLimitBottom = Mathf.DegToRad(25);
	float MouseSensitivity = 0.002f;

    public override void _UnhandledInput(InputEvent @event)
    {
		if(@event is InputEventMouseMotion)
		{
			InputEventMouseMotion thisEvent = (InputEventMouseMotion)@event;
			Godot.Vector3 CamRotation = CameraPivot.Rotation;
			CamRotation.X -= thisEvent.ScreenRelative.Y * MouseSensitivity;
			CamRotation.X = Math.Clamp(CamRotation.X, -TiltLimitTop, TiltLimitBottom);
			CamRotation.Y += -thisEvent.ScreenRelative.X * MouseSensitivity;
			
			CameraPivot.Rotation = CamRotation;
		}
    }
}
