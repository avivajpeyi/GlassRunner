using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestroyOnTrigger : MonoBehaviour
{

    public GameObject parent;
    //public NavMeshSurface surface;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ////Debug.Log("Destroy "+ parent.name + " due to trigger");
            //surface.BuildNavMesh();
            Destroy(parent);
        }

    }
}
