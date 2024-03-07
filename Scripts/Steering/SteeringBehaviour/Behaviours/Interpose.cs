using Godot;
using System;


/// <summary>
/// Returns a steering force that moves an agent to the midpoint of the imaginary line connecting two other agents/positions
/// </summary>
[GlobalClass]
public partial class Interpose : SteeringBehaviour
{
	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		throw new NotImplementedException();
	}
}
