using Godot;

public class GameRule : Node
{
	[Signal] public delegate void YouWin();

	[Signal] public delegate void YouLoose();

	[Export] private int coinsToWin = 10;

	private int coinsCollected = 0;

	private void CoinCollected()
	{
		coinsCollected += 1;

		if (coinsCollected == coinsToWin)
		{
			EmitSignal("YouWin");
		}
	}

	private void YouLooseToRoot()
	{
		EmitSignal("YouLoose");
	}

	public override void _Process(float delta)
	{
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			GetTree().ChangeScene("res://Scenes/OrangeMenue.tscn");
		}
	}
}
