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
			Vector3 position = new Vector3(0, 0, 0) * 10.0f;
			
			position = transform.TransformPoint(position);
			
			thisMissile = (GameObject)GameObject.Instantiate(missile, position, transform.localRotation);
			Physics.IgnoreCollision(thisMissile.collider, collider);
		}
	}
}
