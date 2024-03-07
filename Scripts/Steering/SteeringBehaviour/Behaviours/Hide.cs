using Godot;
using System;


/// <summary>
/// Returns a steering force that steers an agent so that there is always an obstacle between it and another agent.
/// </summary>
[GlobalClass]
public partial class Hide : SteeringBehaviour
{
	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		throw new NotImplementedException();
	}
}
