using UnityEngine;

[RequireComponent(typeof(ShipController))]
public class ShipUserController : MonoBehaviour {

	public float rotationSpeed = 160; // 160 = best rotation speed
	private ShipController ship;
	
	void Awake () {
		ship = GetComponent<ShipController>();
	}
	
	void FixedUpdate() {
		// get input for rotation and the forward/reverse movement
		float rotate = CrossPlatformInput.GetAxis("Horizontal");
		float throttle = CrossPlatformInput.GetAxis("Vertical");
		
		// pass the input to the ship
		ship.Move(rotate, throttle);
	}

	void Update() {
		// rotate ship around y axis
		transform.Rotate(0.0f, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0.0f);
		// clamps boundries for map which are currently hardcoded
		// the clamp is needed to prevent the rotation physics to move the ship +- on the y axis which is baaaaad
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -500, 500),0.0f,Mathf.Clamp(transform.position.z,-500,500));
	}
}
