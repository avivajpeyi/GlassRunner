using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateNextGroundRandom : MonoBehaviour
{
    static int spawn_count = 0;
    public static Vector3 offset;
    public GameObject ground_prefab;


    void Start()
    {
        offset = ground_prefab.transform.Find("EndMarker").position - ground_prefab.transform.Find("StartMarker").position;
        offset.z = offset.z / 2;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            PlaceNextGround();
            Destroy(this); // only create ground once
        }

    }

 

    void PlaceNextGround()
    {

        Vector3 position = ground_prefab.transform.Find("EndMarker").position + offset;


        GameObject new_ground;

        new_ground =  Instantiate(ground_prefab, position, new Quaternion(0, 0, 0, 0));
        new_ground.GetComponentInChildren<LevelGenerator>().DeleteExistingLevel();
     
        spawn_count++;
        new_ground.name = "Ground" + spawn_count.ToString();

    }


}
