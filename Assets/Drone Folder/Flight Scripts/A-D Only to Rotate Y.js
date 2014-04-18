var speed = 50.0;
function Update () {
 
 if (Input.GetKey(KeyCode.A))
    transform.Rotate(Vector3.up * speed * Time.deltaTime);
 
 if (Input.GetKey(KeyCode.D))
    transform.Rotate(-Vector3.up * speed * Time.deltaTime);
 
}