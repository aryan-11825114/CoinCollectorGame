using Godot;

public class Enemy : MeshInstance
{
	[Signal] public delegate void YouLooseToRoot();

	private AudioStreamPlayer3D hurtAudioPlayer;
	private AudioStreamPlayer3D landAudioPlayer;
	private Area enemyArea;

	public override void _Ready()
	{
		hurtAudioPlayer = GetNode<AudioStreamPlayer3D>("HurtAudioPlayer");
		landAudioPlayer = GetNode<AudioStreamPlayer3D>("LandAudioPlayer");
		enemyArea = GetNode<Area>("Area");
	}

	// Collision Detection
	private void EnemyAreaEntered(object body)
	{
		if (body.GetType().Name == "Orange")
		{
			hurtAudioPlayer.Play();
			enemyArea.QueueFree();

			EmitSignal("YouLooseToRoot");
		}

		// Play Landing audion when collision is detected
		landAudioPlayer.Play();
	}
}
