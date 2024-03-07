using Godot;


/// <summary>
/// Returns a steering force that steers away from the predicted position of an agent
/// </summary>
[GlobalClass]
public partial class Evade : SteeringBehaviour
{
	[Export]
	public double EvadeDistance = 10;

	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		var pursuer = actionSelection.TargetVehicle;

		var toPursuer = pursuer.Position.DistanceTo(vehicle.Position);
		if (toPursuer > EvadeDistance)
			return Vector3.Zero;

		var lookAheadTime = toPursuer / (vehicle.MaxSpeed + pursuer.MaxSpeed);
		var predictedPos = pursuer.Position + pursuer.Velocity * lookAheadTime;
		return Seek.Calc(predictedPos, vehicle.Position, vehicle.MaxSpeed);
	}
}
