using Godot;

public class Enemy : MeshInstance
{
	[Signal] public delegate void YouLooseToRoot();

	private void EnemyAreaEntered(object body)
	{
		if (body.GetType().Name == "Orange")
		{
			EmitSignal("YouLooseToRoot");
		}
	}
}
