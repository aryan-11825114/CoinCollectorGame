using Godot;

public class Popup : Godot.Popup
{
	public override void _Process(float delta)
	{
		if (Input.IsActionPressed("ui_cancel"))
		{
			Show();
			GetTree().Paused = true;
		}
	}

	private void ResumeButtonPressed()
	{
		GetTree().Paused = false;
		Hide();
	}

	private void MainMenueButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeScene("res://Scenes/MainMenue.tscn");
	}

	private void RestartButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Hide();
	}

}
