using Godot;

public class YouLooseHud : Control
{
	public AnimationPlayer animationPlayer;
	public Timer timer;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		timer = GetNode<Timer>("Timer");
	}

	private void YouLoose()
	{
		animationPlayer.Play("YouLooseHud");
		timer.Start();
	}

	private void OnTimerTimeOut()
	{
		animationPlayer.QueueFree();
	}
}
