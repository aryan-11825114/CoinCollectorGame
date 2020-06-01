using Godot;

public class EnemyRootScript : Node
{
	[Signal] public delegate void YouLooseToRoot();

	private void EnemyGameOver() {
		EmitSignal("GameOverRoot");
	}

	private void YouLoose() {
		EmitSignal("YouLooseToRoot");
	}
}
