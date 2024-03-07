using Godot;
using System;

[GlobalClass]
public partial class SteeringBehaviour : Node
{
    [Export]
    public bool active = true;
    [Export(PropertyHint.Range, "0, 1")]
    public float weight = 1;

    public virtual Vector3 Calculate(Vehicle vehicle, ActionSelection actionSelection, double delta)
    {
        return Vector3.Zero;
    }
}
