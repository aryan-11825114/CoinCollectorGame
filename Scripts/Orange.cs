using Godot;
using System.ComponentModel;
using System.IO;

public class Orange : KinematicBody
{
	[Export] private float speed = 10.0f;
	[Export] private float rotationSpeed = 1.25f;
	[Export] private float acceleration = 10f;
	private MeshInstance mesh;
	private Vector3 velocity;

	public override void _Ready()
	{
		mesh = GetNode<MeshInstance>("OrangeMesh");
	}

	public override void _PhysicsProcess(float delta)
	{
		Movement(delta);
	}

	// Movement
	private void Movement(float delta)
	{
		Vector3 direction = new Vector3();
		
		if (Input.IsActionPressed("MoveForward"))
		{
			direction -= Transform.basis.z;
			mesh.RotateX(Mathf.Deg2Rad(velocity.z * rotationSpeed));
		}

		if (Input.IsActionPressed("MoveBackward"))
		{
			direction += Transform.basis.z;
			mesh.RotateX(Mathf.Deg2Rad(velocity.z * rotationSpeed));
		}

		if (Input.IsActionPressed("MoveLeft"))
		{
			direction -= Transform.basis.x;	
			mesh.RotateZ(Mathf.Deg2Rad(-velocity.x * rotationSpeed));
		}

		if (Input.IsActionPressed("MoveRight"))
		{
			direction += Transform.basis.x;
			mesh.RotateZ(Mathf.Deg2Rad(-velocity.x * rotationSpeed));
		}

		direction = direction.Normalized();

		velocity = velocity.LinearInterpolate(direction * speed, acceleration * delta);

		MoveAndSlide(velocity);
	}
}
