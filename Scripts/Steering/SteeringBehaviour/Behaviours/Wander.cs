using Godot;


/// <summary>
/// Returns a steering force that makes an agent wander around
/// by projecting a circle in front of it and steering towards
/// a target position that is constrained to move along the circle perimeter.
/// </summary>
[GlobalClass]
public partial class Wander : SteeringBehaviour
{
	[Export]
	public float wanderRadius = 2;
	[Export]
	public float wanderDistance = 100;
	[Export]
	public float wanderJitter = 1;

	private Vector3 wanderTarget = Vector3.Zero;

	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		if (wanderTarget == Vector3.Zero) 
			wanderTarget = new Vector3(vehicle.Position.X, 0, vehicle.Position.Z);
		
		wanderTarget += new Vector3(RandomUnitFloat() * wanderJitter, 0, RandomUnitFloat() * wanderJitter);
		
		wanderTarget = wanderTarget.Normalized();
		wanderTarget *= wanderRadius;

		var targetLocal = wanderTarget + new Vector3(0, 0, -wanderDistance);
		var targetWorldPos = vehicle.ToGlobal(targetLocal);

		return Seek.Calc(vehicle.Position, targetWorldPos, vehicle.MaxSpeed);
	}

	private static float RandomUnitFloat()
	{
		var rand = new RandomNumberGenerator();
		return rand.RandfRange(-1, 1);
	}
}
