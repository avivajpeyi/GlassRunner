using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroundSegmentArchive : MonoBehaviour
{
    public GameObject[] groundSegments;
    public GameObject[] easyGroundSegments;
    public int distanceTillNotEasy = 50;

    public List<int> segmentId;
    private int currentIndex = 0;


    PlayerScore playerScore;

    void Start()
    {
        playerScore = FindObjectOfType<PlayerScore>();
        instantiateSegmentIdx();
    }

    void instantiateSegmentIdx()
    {
        // Instantiate
        segmentId = new List<int>();
        for (int i = 0; i < groundSegments.Length; i++)
        {
            segmentId.Add(i);
        }

        // Shuffle List
        for (int i = 0; i < segmentId.Count; i++)
        {
            int temp = segmentId[i];
            int randomIndex = Random.Range(i, segmentId.Count);
            segmentId[i] = segmentId[randomIndex];
            segmentId[randomIndex] = temp;
        }


    }

    int NextSegmentId()
    {
        int new_segment_id = segmentId[currentIndex];
        currentIndex = (currentIndex + 1) % groundSegments.Length;
        return new_segment_id;
    }



    public GameObject GetRandomTestedGroundSegment()
    {

        GameObject ground_prefab = null;


        if (playerScore.currentDistance <= distanceTillNotEasy)
        {
            while (ground_prefab == null)
            {
                ground_prefab = easyGroundSegments[Random.Range(0, easyGroundSegments.Length)];
            }
        }
        else
        {

            while (ground_prefab == null)
            {
                //ground_prefab = groundSegments[Random.Range(0, groundSegments.Length)];

                ground_prefab = groundSegments[NextSegmentId()];
            }
        }



        return ground_prefab;
    }
}
