using Godot;

public class Camera : InterpolatedCamera
{
	[Export] public float easingValue = 0.6f;
	[Export] public OpenSimplexNoise noise;
	[Export] public float timeScale = 150;
	[Export] public float trauma = 0.0f;
	[Export] public float maxX = 150;
	[Export] public float maxY = 150;
	[Export] public float maxR = 5f;
	
	private float time = 0.0f;
	private Timer timer;

	public override void _Ready() {
		timer = GetNode<Timer>("Timer");
	}

	public override void _Process(float delta) {
		CameraShake(delta);
	}

	public void AddTrauma(float traumaIn) {
		trauma = Mathf.Clamp(trauma + traumaIn, 0, 1);
	}

	private void CameraShake(float delta) {
		time += delta;

		float shake = Mathf.Pow(trauma, 2);

		HOffset = noise.GetNoise3d(time * timeScale, 0f, 0f) * maxX * shake;
		VOffset = noise.GetNoise3d(0f, time * timeScale, 0f) * maxY * shake;
		RotateZ(noise.GetNoise3d(0f, 0f, time * timeScale) * maxR * shake);
	}

	private void EnemyHit() {
		AddTrauma(0.3f);
		timer.Start();
	}

	private void TimerTimeOut() {
		trauma = Mathf.Clamp(trauma - (GetProcessDeltaTime() * easingValue), 0, 1);
	}
}
