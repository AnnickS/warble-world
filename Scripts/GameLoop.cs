using Godot;
using System;

public partial class GameLoop : Node
{
	private bool paused = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetMouse();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SetMouse()
	{
		if (paused)
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}
		else
		{
			Input.MouseMode = Input.MouseModeEnum.Captured;
		}
	}

    public override void _Input(InputEvent @event)
    {
		if(@event.IsActionReleased("Toggle_In-Game_Menu"))
		{
			paused = !paused;
			GetTree().Paused = paused;
			SetMouse();
		}
	}
}
