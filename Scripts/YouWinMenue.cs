using Godot;

public class YouWinMenue : Label
{
	public AnimationPlayer animationPlayer;
	public Timer lifetime;

	public override void _Ready()
	{
		Hide();
		animationPlayer = GetNode<AnimationPlayer>("YouWinAnimPlayer");
		lifetime = GetNode<Timer>("Timer");
	}

	private void YouWin()
	{
		animationPlayer.Play("YouWinAnimation");
		Show();
		lifetime.Start();
	}

  	private void OnTimerTimeOut()
	{
		//QueueFree();
	}
}
