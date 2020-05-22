using Godot;

public class GameOverButton : Button
{
	private void GameOverButtonPressed()
	{
		GetTree().ReloadCurrentScene();
	}
}
