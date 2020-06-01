using Godot;

public class MainMenue : Control
{
	public AudioStreamPlayer playButtonAudio;
	public AudioStreamPlayer exitButtonAudio;
	public Timer timer;

	public override void _Ready() {
		playButtonAudio = (AudioStreamPlayer)FindNode("PlayButtonAudio");
		exitButtonAudio = (AudioStreamPlayer)FindNode("ExitButtonAudio");
		timer = (Timer)FindNode("Timer");
	}

	private void PlayButtonPressed() {
		GetTree().ChangeScene("res://Scenes/Level.tscn");
		Input.SetMouseMode(Input.MouseMode.Captured);
		playButtonAudio.Play();
	}

	private void ExitButtonPressed() {
		exitButtonAudio.Play();
		timer.Start();
	}

	private void OnTimerTimeOut() {
		GetTree().Quit();
	}
}
