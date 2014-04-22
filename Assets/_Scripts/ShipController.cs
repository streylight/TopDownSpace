using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour {

	[SerializeField] 
	private float maxEnginePower = 40f;
	[SerializeField] 
	private float throttleChangeSpeed = 0.3f; 

	public float Throttle { get; private set; }                         
	public float ThrottleSpeed { get; private set; }                  
	public float EnginePower { get; private set; }            
	public float RotationInput { get; private set; }
	public float ThrottleInput { get; private set; }
	public float BankThrottle { get; private set; }  
	public float BankPower { get; private set; } 

	private float originalDrag;                                         
	private float originalAngularDrag;                                  

	public bool reverse;
	
	void Start () {
		// can most likely be removed
		originalDrag = rigidbody.drag;
		originalAngularDrag = rigidbody.angularDrag;
	}
	
	public void Move(float rotationInput, float throttleInput) {
		this.RotationInput = rotationInput;
		this.ThrottleInput = throttleInput;

		// negate throttle if in reverse
		// needed for the "realistic" velocity change when changing from forward to reverse
		if (throttleInput < 0) {
			this.ThrottleInput *= -1;
			this.reverse = true;
		} else {
			this.reverse = false;
		}

		// set/calculate movement factors
		CalculateThrottleSpeed ();
		ControlThrottle ();
		CalculateLinearForces ();
	}

	// normalize rotation and throttle inputs
	void ClampInputs() {
		RotationInput = Mathf.Clamp (RotationInput, -1, 1);
		ThrottleInput = Mathf.Clamp (ThrottleInput, -1, 1);
	}

	// calculate throttle speed and set it
	void CalculateThrottleSpeed() {
		var localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
		localVelocity.y = 0.0f;
		ThrottleSpeed = Mathf.Max(0, localVelocity.z);
	}

	// self explanatory
	void ControlThrottle() {
		Throttle = Mathf.Clamp01(Throttle + ThrottleInput * Time.fixedDeltaTime * throttleChangeSpeed);
        BankThrottle = Mathf.Clamp01(BankThrottle + RotationInput * Time.fixedDeltaTime * throttleChangeSpeed);
		EnginePower = Throttle * maxEnginePower;
		BankPower = BankThrottle * maxEnginePower / 2;
	}
	
	void CalculateLinearForces() {
		var forces = Vector3.zero;
		var sign = reverse ? -1 : 1;

		//used for the zero gravity type effect
		forces += EnginePower * ((sign * transform.forward) * ThrottleInput);
		//Debug.Log ("Thrrotle input is " + ThrottleInput);
		//Debug.Log (forces);
		rigidbody.AddForce (forces);
	}
}
