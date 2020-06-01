using Godot;

public class GameRule : Node
{
	[Signal] public delegate void YouLoose();
	[Signal] public delegate void YouWin();

	public Timer waitTimer;
	
	private int coinsCollected = 0;
	private int coinsToWin = 10;

	public override void _Ready() {
		waitTimer = GetNode<Timer>("LevelEnder");
	}

	private void CoinCollected() {
		coinsCollected += 1;

		if (coinsCollected == coinsToWin) {
			waitTimer.Start();
			Engine.TimeScale = Mathf.Lerp(Engine.TimeScale, 0.0f, 0.4f);

			EmitSignal("YouWin");
		}
	}

	private void YouLooseToRoot() {
		waitTimer.Start();
		Engine.TimeScale = Mathf.Lerp(Engine.TimeScale, 0.0f, 0.4f);

		EmitSignal("YouLoose");
	}

	private void OnTimerTimeOut() {
		GetTree().Paused = true;
	}
}
