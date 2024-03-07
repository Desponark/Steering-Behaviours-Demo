using Godot;
using System;


/// <summary>
/// Returns a steering force that decelerates an agent onto a target position
/// </summary>
[GlobalClass]
public partial class Arrive : SteeringBehaviour
{
	[Export]
	public float Deceleration = 1;

	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		return Calc(vehicle, actionSelection.TargetPos, Deceleration);
	}

	public static Vector3 Calc(Vehicle vehicle, Vector3 targetPos, float deceleration)
	{
		var toTarget = targetPos - vehicle.Position;
		var dist = toTarget.Length();

		if (dist > 0.01)
		{
			var speed = dist / deceleration;
			speed = Math.Min(speed, vehicle.MaxSpeed);
			return toTarget * speed / dist;
		}
		return Vector3.Zero;
	}
}
