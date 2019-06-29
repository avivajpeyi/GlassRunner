using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateNextGround : MonoBehaviour
{
    static int spawn_count = 0;
    static Vector3 offset;
    GroundSegmentArchive groundSegmentsArchive;

    private void Start()
    {
        groundSegmentsArchive = GameObject.Find("/GroundSegmentGenerator").GetComponent<GroundSegmentArchive>();
    }

    void OnTriggerEnter(Collider other)
    {
        ////Debug.Log("CreateNextGround");
        if (other.gameObject.CompareTag("Player"))
        {
            PlaceNextGround();
            Destroy(this); // only create ground once
        }

    }



    void PlaceNextGround()
    {

        GameObject new_ground;
        GameObject ground_prefab = groundSegmentsArchive.GetRandomTestedGroundSegment();

        offset = ground_prefab.transform.Find("EndMarker").position - ground_prefab.transform.Find("StartMarker").position;
        offset.z = offset.z / 2;
        Vector3 position = transform.parent.transform.Find("EndMarker").position + offset;


        new_ground = Instantiate(ground_prefab, position, new Quaternion(0, 0, 0, 0));
        spawn_count++;
        new_ground.name = new_ground.name.Substring(0, "GroundSeg00".Length);


    }
}
