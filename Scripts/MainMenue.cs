using Godot;

public class MainMenue : Button
{
	private void MainMenueButtonPressed()
	{
		GetTree().ChangeScene("res://Scenes/Level.tscn");
	}
}
