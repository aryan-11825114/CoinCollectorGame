using Godot;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading;

public class SlowTime : Node
{
	const float EndValue = 0.0f;
	public bool isActive = false;
	private float timeStart;
	private float durationMs;
	private float startValue;

	private void Start(float duration = 0.4f, float strength = 0.9f)
	{
		timeStart = OS.GetTicksMsec();
		durationMs = duration * 1000;
		startValue = 1 - strength;
		Engine.TimeScale = startValue;
		isActive = true;
	}

	public override void _Ready()
	{
		if (isActive)
		{
			var currentTime = OS.GetTicksMsec() - timeStart;
			var value = CircleEaseIn(currentTime, startValue, EndValue, durationMs);

			if (currentTime > durationMs)
			{
				isActive = false;
				value = EndValue;

			}
			Engine.TimeScale = value;
		}
	}

	// t: current time
	// b: start value
	// c: end value
	// d: duration
	private float CircleEaseIn(float t, float b, float c, float d)
	{
		t /= d;
		return -c * (Mathf.Sqrt(1 - t * t) - 1) + b;
	}
}
