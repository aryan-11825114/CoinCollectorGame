using Godot;

public class YouWinHud : Control
{
	public AnimationPlayer animationPlayer;
	public Timer timer;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		timer = GetNode<Timer>("Timer");
	}

	private void YouWin()
	{
		animationPlayer.Play("YouWinHud");
		timer.Start();
	}

	private void OnTimerTimeOut()
	{
		animationPlayer.QueueFree();
	}
}
