
var explosionPrefab : Transform;

function OnCollisionEnter(collision : Collision) {

    var contact = collision.contacts[2];
    var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    var pos = contact.point;
    Instantiate(explosionPrefab, pos, rot);

    Destroy (gameObject, 0);

}