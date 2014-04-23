/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance = 10;
    // the height we want the camera to be above the target
    public float height = 80;
    // How much we 
    public float heightDamping = 2;
    public float rotationDamping = 3;


    void LateUpdate()
    {
        // Early out if we don't have a target
        if (!target)
            return;

        // Calculate the current rotation angles
        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y + height;

        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);//Time.GetMyDeltaTime());

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);//Time.GetMyDeltaTime());
        //System.Console.WriteLine("dt: {0}", dt);//Time.GetMyDeltaTime());
        //Debug.Log("dt: " + Time.deltaTime);

        // Convert the angle into a rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        //transform.position = target.position;
        var pos = target.position - currentRotation * Vector3.forward * distance;
        pos.y = currentHeight;

        // Set the height of the camera
        transform.position = pos;

        // Always look at the target
        transform.LookAt(target);
    }
}