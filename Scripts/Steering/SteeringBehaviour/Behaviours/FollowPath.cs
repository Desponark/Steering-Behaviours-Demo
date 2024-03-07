using Godot;
using System;


/// <summary>
/// Returns a steering force that moves an agent along a series of positions
/// </summary>
[GlobalClass]
public partial class FollowPath : SteeringBehaviour
{
	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		throw new NotImplementedException();
	}
}
