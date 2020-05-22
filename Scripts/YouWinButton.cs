using Godot;

public class YouWinButton : Button
{
	private void YouWinButtonPressed()
	{
		GetTree().ReloadCurrentScene();
	}
}
