using Godot;

public class YouLooseMenueButtonPressed : Button
{
	public override void _Ready()
	{
	}

	private void ButtonPressed()
	{
		GetTree().ReloadCurrentScene();
	}
}
