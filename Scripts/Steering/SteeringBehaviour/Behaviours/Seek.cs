using Godot;


/// <summary>
/// Returns a steering force that directs an agent towards a target position
/// </summary>
[GlobalClass]
public partial class Seek : SteeringBehaviour
{
	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		return Calc(vehicle.Position, actionSelection.TargetPos, vehicle.MaxSpeed);
	}

	public static Vector3 Calc(Vector3 from, Vector3 to, float maxSpeed)
	{
		return from.DirectionTo(to) * maxSpeed;
	}
}
