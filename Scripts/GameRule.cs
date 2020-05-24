using Godot;

public class GameRule : Node
{
	[Signal] public delegate void YouWin();

	[Signal] public delegate void YouLoose();

	[Export] private int coinsToWin = 10;
	private Timer waitTImer;
	private int coinsCollected = 0;

	public override void _Ready()
	{
		waitTImer = GetNode<Timer>("WaitTimer");
	}

	private void CoinCollected()
	{
		coinsCollected += 1;

		if (coinsCollected == coinsToWin)
		{
			EmitSignal("YouWin");
			waitTImer.Start();
		}
	}

	private void YouLooseToRoot()
	{
		EmitSignal("YouLoose");
		waitTImer.Start();
	}

	private void OnTimerTimeOut()
	{
		GetTree().Paused = true;
	}
}
