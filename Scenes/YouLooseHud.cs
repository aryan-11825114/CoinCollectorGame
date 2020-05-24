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

	private void YouLoose()
	{
		Show();
		animationPlayer.Play("YouLooseHud");
		timer.Start();
	}

	private void OnTimerTimeOut()
	{
		animationPlayer.QueueFree();
	}
}
