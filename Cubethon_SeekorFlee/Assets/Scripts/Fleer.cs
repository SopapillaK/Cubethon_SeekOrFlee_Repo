using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : MonoBehaviour
{
    public Vector3 velocity;
    public Rigidbody rb;
    public float current;
    public float maxspeed;

    public Transform playerTarget;
    public Transform obstChar;

    // Update is called once per frame
    void Update()
    {
        //get dir to the target
        velocity = obstChar.position - playerTarget.position;

        // move on this dir at maxspeed
        velocity.Normalize();
        velocity *= maxspeed;
        rb.AddForce(velocity * Time.deltaTime);

        //make obst face desired dir
        float targetAngle = newOrientation(obstChar.rotation.eulerAngles.y, velocity);
        obstChar.eulerAngles = new Vector3(0, targetAngle, 0);
    }

    public float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(velocity.x, velocity.z);
            targetAngle *= Mathf.Rad2Deg;
            return targetAngle;
        }
        else
        {
            return current;
        }
    }
}
