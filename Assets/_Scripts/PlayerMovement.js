#pragma strict

public var flySpeed : float = 8.0;

function FixedUpdate () {
	//var x = Input.GetAxis("Horizontal");
	//var z = Input.GetAxis("Vertical");
	
	//var movement = Vector3(x,0.0f,z);
	var rotation = Input.GetAxis("Horizontal") * Time.deltaTime;
	
	
	if (Input.GetKey(KeyCode.W)) {
		rigidbody.AddRelativeForce(Vector3.forward * flySpeed);
	}
	if (Input.GetKey(KeyCode.S)) {
		rigidbody.AddRelativeForce(-Vector3.forward * flySpeed);
	}
	if (Input.GetKey(KeyCode.Q)) {
		rigidbody.AddRelativeForce(Vector3.right * flySpeed);
	}
	if (Input.GetKey(KeyCode.E)) {
		rigidbody.AddRelativeForce(-Vector3.right * flySpeed);
	}
	
	//transform.Rotate(0.0f, rotation, 0.0f);
	rigidbody.rotation = Quaternion(0.0f, rotation, 0.0f, 0.0f);
}

function Start () {
	rigidbody.useGravity = false;
}