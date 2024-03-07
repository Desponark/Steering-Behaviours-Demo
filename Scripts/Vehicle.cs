using Godot;


/// <summary>
/// Provides locomotion for a CharacterBody3D and some needed data so different steering behaviours can be tested.
/// </summary>
[GlobalClass]
public partial class Vehicle : CharacterBody3D
{
	[Export]
	public Steering Steering;

	[Export]
	public int MaxSpeed = 10;

	[Export]
	public float Deceleration = 1;

	private Vector3 Gravity = new(0, -9.8f, 0);

	public override void _PhysicsProcess(double delta)
	{
		// LookAt doesn't like parallel vectors or zero vectors
		if (false == (Position.Normalized().Abs().IsEqualApprox(Steering.SteeringForce.Normalized().Abs())
			|| Steering.SteeringForce.IsEqualApprox(Vector3.Zero)))
		{
			LookAt(Position + new Vector3(Steering.SteeringForce.X, 0, Steering.SteeringForce.Z));
		}

		Velocity = Steering.SteeringForce;
		Velocity += Gravity;
		MoveAndSlide();
	}
}
