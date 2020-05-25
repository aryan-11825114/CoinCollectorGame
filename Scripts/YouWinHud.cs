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
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Engine.TimeScale = 1;
	}

}
