using Godot;


/// <summary>
/// Provides some control/decision logic so different steering behaviours can be tested.
/// Implementation not final and just for easy testing right now.
/// </summary>
[GlobalClass]
public partial class ActionSelection : Node
{
	[Export]
	public Vehicle Vehicle;

	[Export]
	public Vector3 TargetPos;

	[Export]
	public Vehicle TargetVehicle;

	public override void _Input(InputEvent @event)
	{
		if (@event.IsAction("click"))
		{
			TargetPos = ScreenPointToRay();
		}
	}

	private Vector3 ScreenPointToRay()
	{
		var spaceState = Vehicle.GetWorld3D().DirectSpaceState;

		var mousePos = GetViewport().GetMousePosition();
		var camera = GetTree().Root.GetCamera3D();
		var rayOrig = camera.ProjectRayOrigin(mousePos);
		var rayEnd = rayOrig + camera.ProjectRayNormal(mousePos) * 2000;

		var rayParam = new PhysicsRayQueryParameters3D() {
			From = rayOrig,
			To = rayEnd
		};
		var rayRes = spaceState.IntersectRay(rayParam);
		
		if (rayRes.TryGetValue("position", out var position))
		{
			return (Vector3)position;
		}
		return Vector3.Zero;
	}
}
