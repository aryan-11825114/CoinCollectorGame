using Godot;

public class ExitMainMeneButton2 : Button
{
	private void ExitMainMeneButtonPressed()
	{
		GetTree().Quit();
	}
}
