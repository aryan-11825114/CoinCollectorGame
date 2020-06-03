using Godot;

public class YouWinHud : Control
{
	public AudioStreamPlayer youWinButtonAudio;
	public AnimationPlayer animationPlayer;
	public Timer youWinButtonTimer;

	public override void _Ready()
	{
		youWinButtonAudio = (AudioStreamPlayer)FindNode("YouWinButtonAudio");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		youWinButtonTimer = (Timer)FindNode("YouWinButtonTimer");
	}

	private void YouWin() 
	{
		Input.SetMouseMode(Input.MouseMode.Visible);
		animationPlayer.Play("YouWinHud");
	}

	private void YouButtonPressed() 
	{
		youWinButtonTimer.Start();
		youWinButtonAudio.Play();
	}

	private void OnYouWinButtonTimerTimeOut() 
	{
		Input.SetMouseMode(Input.MouseMode.Captured);
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Engine.TimeScale = 1;
	}

}