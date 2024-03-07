using Godot;


/// <summary>
/// /// Returns a steering force that steers towards the predicted position of an agent based on the last two positions it received
/// </summary>
[GlobalClass]
public partial class PursuitByPositions : SteeringBehaviour
{
	private Vector3 lastKnowPos = Vector3.Zero;
	private Vector3 newestPos = Vector3.Zero;
	private double timeBetweenPosChange = 0;

	private Vector3 evaderVelocity = Vector3.Zero;


	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		CalculateEvaderVelocity(actionSelection, delta);

		if (evaderVelocity == Vector3.Zero)
		{
			return Seek.Calc(vehicle.Position, actionSelection.TargetPos, vehicle.MaxSpeed);
		}
		else
		{
			var toEvader = actionSelection.TargetPos - vehicle.Position;

			if (IsEvaderAheadAndFacingPursuer(vehicle, toEvader))				
				return Seek.Calc(vehicle.Position, actionSelection.TargetPos, vehicle.MaxSpeed);

			var lookAheadTime = toEvader.Length() / (vehicle.MaxSpeed + evaderVelocity.Length());
			var predictedPos = actionSelection.TargetPos + evaderVelocity * lookAheadTime;

			return Seek.Calc(vehicle.Position, predictedPos, vehicle.MaxSpeed);
		}
	}

	private bool IsEvaderAheadAndFacingPursuer(Vehicle vehicle, Vector3 toEvader)
	{
		var relativeHeading = vehicle.Velocity.Normalized().Dot(evaderVelocity.Normalized());
		if (toEvader.Dot(vehicle.Velocity.Normalized()) > 0 && relativeHeading < -0.95) //acos(0.95)=18 degs
			return true;
		return false;
	}

	private void CalculateEvaderVelocity(ActionSelection actionSelection, double delta)
	{
		timeBetweenPosChange += delta;

		if (newestPos != actionSelection.TargetPos)
		{
			lastKnowPos = newestPos;
			newestPos = actionSelection.TargetPos;
			if (lastKnowPos != Vector3.Zero)
			{
				evaderVelocity = lastKnowPos - newestPos / (float)timeBetweenPosChange;
			}
			timeBetweenPosChange = 0;
		}
	}
}
