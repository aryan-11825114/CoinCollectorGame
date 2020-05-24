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

	public override void _Process(float delta)
	{
		if (Input.IsActionPressed("ui_cancel"))
		{
			Hide();
		}
		else if (Input.IsActionPressed("ui_cancel") && GetTree().IsPaused() == false)
		{
			Show();
		}
	}

	private void YouWin()
	{
		Show();
		animationPlayer.Play("YouWinHud");
		timer.Start();
	}

	private void OnTimerTimeOut()
	{
		animationPlayer.QueueFree();
	}
}
