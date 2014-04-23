using UnityEngine;

[RequireComponent(typeof(ShipController))]
public class ShipUserController : Photon.MonoBehaviour {

    public float rotationSpeed = 160; // 160 = best rotation speed
    private ShipController ship;
    	
    //void FixedUpdate() {
    //    // get input for rotation and the forward/reverse movement
    //    float rotate = CrossPlatformInput.GetAxis("Horizontal");
    //    float throttle = CrossPlatformInput.GetAxis("Vertical");
		
    //    // pass the input to the ship
    //    ship.Move(rotate, throttle);
    //}

    //void Update() {
    //    // rotate ship around y axis
    //    transform.Rotate(0.0f, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0.0f);
    //    // clamps boundries for map which are currently hardcoded
    //    // the clamp is needed to prevent the rotation physics to move the ship +- on the y axis which is baaaaad
    //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -500, 500),0.0f,Mathf.Clamp(transform.position.z,-500,500));
    //}

    private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
    private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this

    void Start()
    {
        if (photonView.isMine)
        {
            var camera = Camera.main.GetComponent<SmoothFollow>();
            camera.target = transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
        else if (photonView.isMine)
        {
            ship = GetComponent<ShipController>();

            //rotate ship around y axis
            transform.Rotate(0.0f, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0.0f);
            // clamps boundries for map which are currently hardcoded
            // the clamp is needed to prevent the rotation physics to move the ship +- on the y axis which is baaaaad
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -500, 500),0.0f,Mathf.Clamp(transform.position.z,-500,500));
                       
        }
    }

    void FixedUpdate()
    {
        if (photonView.isMine)
        {
            ship = GetComponent<ShipController>();
            // get input for rotation and the forward/reverse movement
            float rotate = CrossPlatformInput.GetAxis("Horizontal");
            float throttle = CrossPlatformInput.GetAxis("Vertical");

            // pass the input to the ship
            ship.Move(rotate, throttle);
        }
    }

    //void Update()
    //{
    //    // rotate ship around y axis
    //    transform.Rotate(0.0f, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0.0f);
    //    // clamps boundries for map which are currently hardcoded
    //    // the clamp is needed to prevent the rotation physics to move the ship +- on the y axis which is baaaaad
    //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -500, 500), 0.0f, Mathf.Clamp(transform.position.z, -500, 500));
    //}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

            //ShipUserController myC = GetComponent<ShipUserController>();
            //stream.SendNext((int)myC._characterState);
        }
        else
        {
            // Network player, receive data
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();

            //ShipUserController myC = GetComponent<ShipUserController>();
            //myC._characterState = (CharacterState)stream.ReceiveNext();
        }
    }
}
