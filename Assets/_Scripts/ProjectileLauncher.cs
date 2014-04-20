using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour {

	// Class Members
	public GameObject missile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			// Local Variables
			GameObject thisMissile;
			Vector3 projectileVelocity = rigidbody.velocity;
			Vector3 position = new Vector3(0, 0, 0) * 10.0f;
			
			// Update projectile velocity
			projectileVelocity += transform.TransformDirection(Vector3.forward * 10);
			
			position = transform.TransformPoint(position);
			
			thisMissile = (GameObject)GameObject.Instantiate(missile, position, transform.localRotation);
			thisMissile.rigidbody.velocity = projectileVelocity;
			
			Physics.IgnoreCollision(thisMissile.collider, collider);
		}
	}
}
