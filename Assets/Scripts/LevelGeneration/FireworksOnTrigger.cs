using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksOnTrigger : MonoBehaviour
{

    public GameObject fireworks;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fireworks.SetActive(true);
        }

    }
}
