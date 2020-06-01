using Godot;

public class YouLooseHud : Control
{
	public AudioStreamPlayer youLooseButtonAudio;
	public AnimationPlayer animationPlayer;
	public Timer youLooseButtonTimer;

	public override void _Ready() {
		youLooseButtonAudio = (AudioStreamPlayer)FindNode("YouLooseButtonAudio");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		youLooseButtonTimer = (Timer)FindNode("YouLooseButtonTimer");
	}

	private void YouLoose() {
		Input.SetMouseMode(Input.MouseMode.Visible);
		animationPlayer.Play("YouLooseHud");
	}
	
	private void YouLooseHudButtonPressed() {
		youLooseButtonTimer.Start();
		youLooseButtonAudio.Play();
	}

	private void OnYouLooseButtonTimerTimeOut() {
		Input.SetMouseMode(Input.MouseMode.Captured);
		GetTree().ReloadCurrentScene();
		GetTree().Paused = false;
		Engine.TimeScale = 1;
	}
}
