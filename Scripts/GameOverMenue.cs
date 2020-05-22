using Godot;

public class GameOverMenue : Godot.Label
{
	public AnimationPlayer labelAnimationPlayer;
	public Timer lifetime;

	public override void _Ready()
	{
		this.Hide();
		labelAnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		lifetime = GetNode<Timer>("Timer");
	}

	private void YouLoose()
	{
		this.Show();
		labelAnimationPlayer.Play("GameOverAnimation");
		lifetime.Start();
	}

	private void OnTimerTimeOut()
	{
		labelAnimationPlayer.QueueFree();
	}
}
