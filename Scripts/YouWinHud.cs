using Godot;

public class YouWinHud : Control
{
	private AnimationPlayer animationPlayer;
	private AudioStreamPlayer youWinButtonAudio;
	private Timer youWinButtonTimer;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		youWinButtonAudio = (AudioStreamPlayer)FindNode("YouWinButtonAudio");
		youWinButtonTimer = (Timer)FindNode("YouWinButtonTimer");
	}

	private void YouWin()
	{
		Input.SetMouseMode(Input.MouseMode.Visible);
		animationPlayer.Play("YouWinHud");
	}

	// You Win Button
	private void YouButtonPressed()
	{
		youWinButtonAudio.Play();
		youWinButtonTimer.Start();
	}

	private void OnYouWinButtonTimerTimeOut()
	{
		Input.SetMouseMode(Input.MouseMode.Captured);
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Engine.TimeScale = 1;
	}

}
