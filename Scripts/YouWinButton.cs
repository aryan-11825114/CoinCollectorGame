using Godot;

public class YouWinButton : Button
{
	public override void _Ready()
	{
	}

	private void YouWinButton_pressed()
	{
		GetTree().ReloadCurrentScene();
	}
}