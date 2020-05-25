using Godot;

public class MainMenue : Control
{
	private AudioStreamPlayer playButtonAudio;
	private AudioStreamPlayer exitButtonAudio;
	private Timer timer;

	public override void _Ready()
	{
		playButtonAudio = (AudioStreamPlayer)FindNode("PlayButtonAudio");
		exitButtonAudio = (AudioStreamPlayer)FindNode("ExitButtonAudio");
		timer = (Timer)FindNode("Timer");
	}

	// Play Button
	private void PlayButtonPressed()
	{
		playButtonAudio.Play();
		GetTree().ChangeScene("res://Scenes/Level.tscn");
	}

	// Exit Buttom
	private void ExitButtonPressed()
	{
		exitButtonAudio.Play();
		timer.Start();
	}

	private void OnTimerTimeOut()
	{
		GetTree().Quit();
	}
}
