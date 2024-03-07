using Godot;
using System;


/// <summary>
/// Returns a steering force that steers an agent to avoid obstacles lying in its path.
/// </summary>
[GlobalClass]
public partial class ObstacleAvoidance : SteeringBehaviour
{
	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		throw new NotImplementedException();
	}
}
