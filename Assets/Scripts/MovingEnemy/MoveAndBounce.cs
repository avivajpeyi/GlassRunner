using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBounce : MonoBehaviour
{

    public bool forward = true;
    public float movementSpeed = 1f;
    public float minMovementSpeed = 1f;
    public float maxMovementSpeed = 5f;

     float posBoundary = 11.5f;
     float negBoundary = -11.5f;


    public void Start()
    {
        GameObject arrow = this.transform.Find("Arrow").gameObject;
        arrow.SetActive(false);


        movementSpeed = Random.Range(minMovementSpeed, maxMovementSpeed); 
    }

    private void Update()
    {
        Move();
        OutOfBoundsCheck();
    }

    void Move()
    {
        if (forward)
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        else
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
    }

    void OutOfBoundsCheck()
    { 
        if (transform.position.x <= negBoundary || transform.position.x >= posBoundary)
        {
            Destroy(transform.gameObject);

            //GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            forward = !forward;
        }

    }
}
