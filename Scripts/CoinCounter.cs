using Godot;

public class CoinCounter : Label
{
	private int coins;

	// 0 on start
	public override void _Ready()
	{
		coins = 0;
		Text = 0.ToString();
	}

	// Increment Coin by 1
	private void IncrementCoin()
	{
		coins += 1;
		Text = coins.ToString();
	}
}
