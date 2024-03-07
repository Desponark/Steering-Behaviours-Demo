using Godot;
using System;


/// <summary>
/// Returns a steering force that directs an agent away from neighbouring agents
/// </summary>
[GlobalClass]
public partial class Separation : SteeringBehaviour
{
	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		throw new NotImplementedException();
	}
}
