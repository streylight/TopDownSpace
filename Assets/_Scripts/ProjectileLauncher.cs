using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour
{

	// Class Members
	public Missile   missile;
	public Transform ship;

	// Use this for initialization
	void Start()
	{
		missile.CreatePool();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButtonDown(0)) {
			LaunchMissile();
		}
	}
	
	void LaunchMissile() {
		// Local Variables
		Vector3 projectileVelocity = rigidbody.velocity;
		
		// Update projectile velocity
		projectileVelocity += transform.TransformDirection(Vector3.forward * 10);

		missile.Spawn(transform.position, transform.rotation);
		missile.rigidbody.velocity = projectileVelocity;
		
		Physics.IgnoreCollision(missile.collider, collider);
	}
}
