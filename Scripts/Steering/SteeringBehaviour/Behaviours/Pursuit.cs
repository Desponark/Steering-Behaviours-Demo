using Godot;


/// <summary>
/// Returns a steering force that steers towards the predicted position of an agent
/// </summary>
[GlobalClass]
public partial class Pursuit : SteeringBehaviour
{
	private Vehicle evader;

	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		evader = actionSelection.TargetVehicle;

		if (IsEvaderAheadAndFacingPursuer(vehicle))
			return Seek.Calc(vehicle.Position, evader.Position, vehicle.MaxSpeed);

		var lookAheadTime = evader.Position.DistanceTo(vehicle.Position) / (vehicle.MaxSpeed + evader.MaxSpeed);
		var predictedPos = evader.Position + evader.Velocity * lookAheadTime;

		return Seek.Calc(vehicle.Position, predictedPos, vehicle.MaxSpeed);
	}

	private bool IsEvaderAheadAndFacingPursuer(Vehicle vehicle)
	{
		var relativeHeading = vehicle.Velocity.Normalized().Dot(evader.Velocity.Normalized());
		var toEvader = evader.Position - vehicle.Position;
		if (toEvader.Dot(vehicle.Velocity.Normalized()) > 0 && relativeHeading < -0.95) //acos(0.95)=18 degs
			return true;
		return false;
	}
}
