using Godot;


/// <summary>
/// Returns a steering force that keeps an agents heading (look direction) aligned with its neighbors
/// </summary>
[GlobalClass]
public partial class Alignment : SteeringBehaviour
{
	public override Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
	{
		return Vector3.Zero;
	}
}
