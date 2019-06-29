using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Vector3 new_postion;
    Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public float maxDistanceBetween = 50;
    float distanceInBetween = 0;


    [SerializeField] Vector3 offset;                     // The initial offset from the target.
    [SerializeField] Vector3 my_pos;

    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;

        // Calculate the initial offset.
        offset = transform.position - target.position;
        my_pos = this.transform.position;
    }


    void Update()
    {
        my_pos = this.transform.position;

        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetPos = new Vector3(x: my_pos.x, y: my_pos.y, z: target.position.z );
        distanceInBetween = targetPos.z - transform.position.z;

        if (distanceInBetween > maxDistanceBetween)
        {
            // Fuck smooth movement, teleport me closer to my target
            transform.position = new Vector3(x: my_pos.x, y: my_pos.y, z: target.position.z - maxDistanceBetween);
            my_pos = this.transform.position;
        }
        else {
            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime * 0.01f);
            my_pos = this.transform.position;
        }



    }
}

