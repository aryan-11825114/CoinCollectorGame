using Godot;

public class Camera : InterpolatedCamera
{
	[Export] private OpenSimplexNoise noise;
	[Export] private float trauma = 0.0f;
	[Export] private float maxX = 150;
	[Export] private float maxY = 150;
	[Export] private float maxR = 5f;
	[Export] private float timeScale = 150;
	[Export] private float easingValue = 0.6f;
	private float time = 0.0f;
	private Timer timer;

	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
	}


	public override void _Process(float delta)
	{
		CameraShake(delta);
	}

	// Trauma
	public void AddTrauma(float traumaIn)
	{
		trauma = Mathf.Clamp(trauma + traumaIn, 0, 1);
	}

	// Camera Shake
	private void CameraShake(float delta)
	{
		time += delta;

		float shake = Mathf.Pow(trauma, 2);
		HOffset = noise.GetNoise3d(time * timeScale, 0f, 0f) * maxX * shake;
		VOffset = noise.GetNoise3d(0f, time * timeScale, 0f) * maxY * shake;
		RotateZ(noise.GetNoise3d(0f, 0f, time * timeScale) * maxR * shake);
	}

	// Add Trauma when enemy is hit
	private void EnemyHit()
	{
		AddTrauma(0.3f);
		timer.Start();
	}

	// When the timer times out set it back to 0
	private void TimerTimeOut()
	{
		trauma = Mathf.Clamp(trauma - (GetProcessDeltaTime() * easingValue), 0, 1);
	}
}
