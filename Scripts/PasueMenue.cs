using Godot;

public class PasueMenue : Godot.Popup
{
	public AudioStreamPlayer buttonAudio;
	public Timer mainMenueTimer;
	public Timer restartTimer;
	public Timer resumeTimer;

	public override void _Ready() {
		buttonAudio = GetNode<AudioStreamPlayer>("ButtonAudio");
		mainMenueTimer = (Timer)FindNode("MainMenueTimer");
		restartTimer = (Timer)FindNode("RestartTimer");
		resumeTimer = (Timer)FindNode("ResumeTimer");
	}

	public override void _Process(float delta) 	{
		if (Input.IsActionPressed("ui_cancel") && !GetTree().Paused) {
			Input.SetMouseMode(Input.MouseMode.Visible);
			Show();
			GetTree().Paused = true;
		}
	}

	private void ResumeButtonPressed() {
		resumeTimer.Start();
		buttonAudio.Play();
	}

	private void OnResumeTimerTimeOut() {
		Input.SetMouseMode(Input.MouseMode.Captured);
		GetTree().Paused = false;
		Hide();
	}

	private void MainMenueButtonPressed() {
		mainMenueTimer.Start();
		buttonAudio.Play();
	}

	private void OnMainMenueTimerTimeOut() {
		GetTree().Paused = false;
		GetTree().ChangeScene("res://Scenes/MainMenue.tscn");
	}

	private void RestartButtonPressed() {
		buttonAudio.Play();
		restartTimer.Start();
	}

	private void OnRestartTimerTimeOut() {
		Input.SetMouseMode(Input.MouseMode.Captured);
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Hide();
	}
}
