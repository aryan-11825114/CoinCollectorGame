using Godot;

public class YouLooseMenueButtonPressed : Button
{

	private void ButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
	}
}
