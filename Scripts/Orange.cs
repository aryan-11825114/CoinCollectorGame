using Godot;
using System.ComponentModel;
using System.IO;

public class Orange : KinematicBody
{
	[Export] public float speed = 10.0f;
	[Export] public float rotationSpeed = 1.25f;
	[Export] public float acceleration = 10f;
	public MeshInstance mesh;
	
	private Vector3 velocity;

	public override void _Ready() {
		mesh = GetNode<MeshInstance>("OrangeMesh");
	}

	public override void _PhysicsProcess(float delta) {
		Movement(delta);
	}

	private void Movement(float delta) {
		Vector3 direction = new Vector3();
		
		if (Input.IsActionPressed("MoveForward")) {
			mesh.RotateX(Mathf.Deg2Rad(velocity.z * rotationSpeed));
			direction -= Transform.basis.z;
		}

		if (Input.IsActionPressed("MoveBackward")) {
			mesh.RotateX(Mathf.Deg2Rad(velocity.z * rotationSpeed));
			direction += Transform.basis.z;
		}

		if (Input.IsActionPressed("MoveLeft")) {
			mesh.RotateZ(Mathf.Deg2Rad(-velocity.x * rotationSpeed));
			direction -= Transform.basis.x;	
		}

		if (Input.IsActionPressed("MoveRight")) {
			direction += Transform.basis.x;
			mesh.RotateZ(Mathf.Deg2Rad(-velocity.x * rotationSpeed));
		}

		direction = direction.Normalized();

		velocity = velocity.LinearInterpolate(direction * speed, acceleration * delta);

		MoveAndSlide(velocity);
	}
}
