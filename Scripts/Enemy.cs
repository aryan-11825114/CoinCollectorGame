using Godot;

public class Enemy : MeshInstance
{
	[Signal] public delegate void YouLooseToRoot();

	AudioStreamPlayer3D hurtAudioPlayer;
	AudioStreamPlayer3D landAudioPlayer;

	public override void _Ready()
	{
		hurtAudioPlayer = GetNode<AudioStreamPlayer3D>("HurtAudioPlayer");
		landAudioPlayer = GetNode<AudioStreamPlayer3D>("LandAudioPlayer");
	}

	private void EnemyAreaEntered(object body)
	{
		if (body.GetType().Name == "Orange")
		{
			hurtAudioPlayer.Play();

			EmitSignal("YouLooseToRoot");
		}

		landAudioPlayer.Play();
	}
}
