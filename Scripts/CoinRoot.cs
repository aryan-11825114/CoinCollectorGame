using Godot;

public class CoinRoot : Control
{
	[Signal] public delegate void IncrementCoin();

	private void CoinCollected()
	{
		EmitSignal("IncrementCoin");
	}
}