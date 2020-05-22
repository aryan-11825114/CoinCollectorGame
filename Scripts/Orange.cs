using Godot;

public class Orange : KinematicBody
{

	[Export] public float speed = 8.0f;
	[Export] public float rotationSpeed = 8.0f;
	[Export] public float slidingSpeed = 0.05f;
	public MeshInstance mesh;
	public Vector3 velocity;

	public override void _Ready()
	{
		mesh = GetNode<MeshInstance>("OrangeMesh");
	}

	public override void _PhysicsProcess(float delta)
	{
		Movement(delta);
	}

	private void YouLoose()
	{
		SetPhysicsProcess(false);
	}

	private void YouWin()
	{
		SetPhysicsProcess(false);
	}

	private void Movement(float delta)
	{
		if (Input.IsActionPressed("MoveForward"))
		{
			velocity.z = -speed;
			mesh.RotateX(Mathf.Deg2Rad(-rotationSpeed));
		}
		else if (Input.IsActionPressed("MoveBackward"))
		{
			velocity.z = speed;
			mesh.RotateX(Mathf.Deg2Rad(rotationSpeed));
		}
		else
		{
			velocity.z = Mathf.Lerp(velocity.z, 0.0f, slidingSpeed);
		}

		if (Input.IsActionPressed("MoveLeft"))
		{
			velocity.x = -speed;
			mesh.RotateZ(Mathf.Deg2Rad(rotationSpeed));
		}
		else if (Input.IsActionPressed("MoveRight"))
		{
			velocity.x = speed;
			mesh.RotateZ(Mathf.Deg2Rad(-rotationSpeed));
		}
		else
		{
			velocity.x = Mathf.Lerp(velocity.x, 0.0f, slidingSpeed);
		}

		MoveAndSlide(velocity, Vector3.Up);
	}
}
