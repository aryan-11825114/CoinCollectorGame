using Godot;
using System;

public class ExitMainMeneButton2 : Button
{
	public override void _Ready()
	{
		
	}

	private void ExitMainMeneButtonPressed()
	{
		GetTree().Quit();
	}
}
