using Godot;

public class Coin : Area
{
	[Signal] public delegate void CoinCollected();

	[Export] public float speedMultiplier = 1.0f;
	public AnimationPlayer animationPlayer;
	public AudioStreamPlayer3D audioPlayer;
	public CollisionShape coinCollision;
	public Timer timer;

	public override void _Ready() 
	{
		audioPlayer = GetNode<AudioStreamPlayer3D>("AudioStreamPlayer3D");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		coinCollision = GetNode<CollisionShape>("CoinCollision");
		timer = GetNode<Timer>("Timer");
	}

	public override void _PhysicsProcess(float delta) 
	{
		RotateY(Mathf.Deg2Rad(delta * 100 * speedMultiplier));
	}

	private void CoinBodyEntered(object body) 
	{
		if (body.GetType().Name == "Orange") 
		{
			animationPlayer.Play("CoinBounce");
			coinCollision.QueueFree();
			audioPlayer.Play();
			timer.Start();

			EmitSignal("CoinCollected");
		}
	}
	private void OnTimerTimeOut() 
	{
		QueueFree();
	}
}
