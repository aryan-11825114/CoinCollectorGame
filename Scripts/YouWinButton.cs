using Godot;

public class YouWinButton : Button
{
	private void YouWinButton_pressed()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		Engine.TimeScale = 1;
	}
}
