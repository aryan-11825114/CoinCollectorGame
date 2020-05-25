using Godot;

public class PasueMenue : Godot.Popup
{
	private AudioStreamPlayer buttonAudio;
	private Timer resumeTimer;
	private Timer restartTimer;
	private Timer mainMenueTimer;

	public override void _Ready()
	{
		buttonAudio = GetNode<AudioStreamPlayer>("ButtonAudio");
		resumeTimer = (Timer)FindNode("ResumeTimer");
		restartTimer = (Timer)FindNode("RestartTimer");
		mainMenueTimer = (Timer)FindNode("MainMenueTimer");
	}

	public override void _Process(float delta)
	{
		// Show the pause menue when escape button is pressed
		if (Input.IsActionPressed("ui_cancel") && !GetTree().IsPaused())
		{
			Show();
			GetTree().Paused = true;
		}
	}

	// Resume Button
	private void ResumeButtonPressed()
	{
		buttonAudio.Play();
		resumeTimer.Start();
	}

	private void OnResumeTimerTimeOut()
	{
		GetTree().Paused = false;
		Hide();
	}

	// MainMenueButton
	private void MainMenueButtonPressed()
	{
		buttonAudio.Play();
		mainMenueTimer.Start();
	}

	private void OnMainMenueTimerTimeOut()
	{
		GetTree().Paused = false;
		GetTree().ChangeScene("res://Scenes/MainMenue.tscn");
	}

	// Restart Button
	private void RestartButtonPressed()
	{
		buttonAudio.Play();
		restartTimer.Start();
	}

	private void OnRestartTimerTimeOut()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Hide();
	}
}
