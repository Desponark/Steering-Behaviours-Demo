using Godot;
using System;


/// <summary>
/// Returns a steering force that directs an agent toward the center of mass of its neighbours
/// </summary>
[GlobalClass]
public partial class Cohesion : SteeringBehaviour
{
	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		throw new NotImplementedException();
	}
}
