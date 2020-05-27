using Godot;

public class YouLooseHud : Control
{
	private AnimationPlayer animationPlayer;
	private AudioStreamPlayer youLooseButtonAudio;
	private Timer youLooseButtonTimer;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		youLooseButtonAudio = (AudioStreamPlayer)FindNode("YouLooseButtonAudio");
		youLooseButtonTimer = (Timer)FindNode("YouLooseButtonTimer");
	}

	// When lost
	private void YouLoose()
	{
		Input.SetMouseMode(Input.MouseMode.Visible);
		animationPlayer.Play("YouLooseHud");
	}

	// YouLoose Hud button
	private void YouLooseHudButtonPressed()
	{
		youLooseButtonAudio.Play();
		youLooseButtonTimer.Start();
	}

	private void OnYouLooseButtonTimerTimeOut()
	{
		Input.SetMouseMode(Input.MouseMode.Captured);
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Engine.TimeScale = 1;
	}
}
