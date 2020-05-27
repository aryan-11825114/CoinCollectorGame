using Godot;

public class GameRule : Node
{
	[Signal] public delegate void YouWin();

	[Signal] public delegate void YouLoose();

	private int coinsToWin = 10;
	private Timer waitTimer;
	private int coinsCollected = 0;

	public override void _Ready()
	{
		waitTimer = GetNode<Timer>("LevelEnder");
	}

	// When Coin is colleccted
	private void CoinCollected()
	{
		coinsCollected += 1;

		// Emit Signal when won and of course slow mo
		if (coinsCollected == coinsToWin)
		{
			waitTimer.Start();
			Engine.TimeScale = Mathf.Lerp(Engine.TimeScale, 0.0f, 0.4f);

			EmitSignal("YouWin");
		}
	}

	// Emit Signla on loose and slow mo
	private void YouLooseToRoot()
	{
		waitTimer.Start();
		Engine.TimeScale = Mathf.Lerp(Engine.TimeScale, 0.0f, 0.4f);

		EmitSignal("YouLoose");
	}

	// Pause when Loosing or Winning
	private void OnTimerTimeOut()
	{
		GetTree().Paused = true;
	}
}
