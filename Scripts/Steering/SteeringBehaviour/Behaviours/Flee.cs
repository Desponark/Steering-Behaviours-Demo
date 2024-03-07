using Godot;


/// <summary>
/// Returns a steering force that steers an agent away from the target position
/// </summary>
[GlobalClass]
public partial class Flee : SteeringBehaviour
{
	[Export]
	public double FleeDistance = 10;

	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		if (vehicle.Position.DistanceTo(actionSelection.TargetPos) > FleeDistance)
			return Vector3.Zero;
		
		return Seek.Calc(actionSelection.TargetPos, vehicle.Position, vehicle.MaxSpeed);
	}
}
