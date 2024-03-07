using Godot;


/// <summary>
/// Returns a steering force required to keep an agent at a specified offset from a target agent.
/// </summary>
[GlobalClass]
public partial class OffsetPursuit : SteeringBehaviour
{
	[Export]
	public Vector3 Offset = new(2, 0, 2);

	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		var leader = actionSelection.TargetVehicle;

		var worldOffsetPos = leader.ToGlobal(Offset);
		
		var lookAheadTime = vehicle.Position.DistanceTo(worldOffsetPos) / (vehicle.MaxSpeed + leader.MaxSpeed);
		var targetPos = worldOffsetPos + leader.Velocity * lookAheadTime;
		
		return Arrive.Calc(vehicle, targetPos, 0.1f);
	}
}
