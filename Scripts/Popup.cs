using Godot;

public class Popup : Godot.Popup
{
	public override void _Process(float delta)
	{
		if (Input.IsActionPressed("ui_cancel") && !GetTree().IsPaused())
		{
			Show();
			GetTree().Paused = true;
		}
	}

	// Resume Button
	private void ResumeButtonPressed()
	{
		GetTree().Paused = false;
		Hide();
	}

	// MainMenueButton
	private void MainMenueButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeScene("res://Scenes/MainMenue.tscn");
	}

	// Restart Button
	private void RestartButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Hide();
	}

}
