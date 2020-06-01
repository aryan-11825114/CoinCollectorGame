using Godot;

public class CoinCounter : Label
{
	private int coins;

	public override void _Ready() {
		coins = 0;
		Text = 0.ToString();
	}

	private void IncrementCoin() {
		coins += 1;
		Text = coins.ToString();
	}
}
