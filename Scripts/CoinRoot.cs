using Godot;

public class CoinRoot : Control
{
	[Signal] public delegate void IncrementCoin();

	public override void _Ready()
	{
	}

	private void CoinCollected()
	{
		EmitSignal("IncrementCoin");
	}
}

