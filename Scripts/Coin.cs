using Godot;

public class Coin : Area
{
	[Signal] public delegate void CoinCollected();

	[Export] public float speedMultiplier = 1.0f;

	public AnimationPlayer animationPlayer;
	public Timer timer;
	public CollisionShape coinCollision;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		timer = GetNode<Timer>("Timer");
		coinCollision = GetNode<CollisionShape>("CoinCollision");
	}

	public override void _PhysicsProcess(float delta)
	{
		this.RotateY(Mathf.Deg2Rad(delta * 100 * speedMultiplier));
	}

	private void CoinBodyEntered(object body)
	{
		if (body.GetType().Name == "Orange")
		{
			animationPlayer.Play("CoinBounce");
			timer.Start();
			coinCollision.QueueFree();

			EmitSignal("CoinCollected");
		}
	}
	private void OnTimerTimeOut()
	{
		this.QueueFree();
	}
}
