using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{

    int width = 10;
    int height = 10;

    public GameObject generationArea;

    public GameObject wall;
    public GameObject enemy; // moving wall

    public NavMeshSurface surface;

    //private bool playerSpawned = false;

    // Use this for initialization
    public void Start()
    {
        surface = GameObject.Find("NavMesh").GetComponent<NavMeshSurface>();

        width = (int)generationArea.transform.localScale.x;
        height = (int)generationArea.transform.localScale.z;
        generationArea.SetActive(false);


        DeleteExistingLevel();
        GenerateLevel();

        // Update navemesh based on generated level
        surface.BuildNavMesh();
        ////Debug.Log("Built nav mesh on ground init");

    }

    // Create a grid based level
    public void GenerateLevel()
    {
        // Loop over the grid
        for (int x = 0; x <= width; x += 2)
        {
            for (int y = 0; y <= height; y += 2)
            {
                // Should we place a wall?
                if (Random.value > .7f)
                {
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    pos = new Vector3(pos.x + this.transform.position.x, pos.y, pos.z + this.transform.position.z);
                    if (Random.value > 0.9f)
                        PlaceEnemy(pos);
                    else
                        PlaceWall(pos);

                }
            }
        }
    }


    public void PlaceWall(Vector3 pos)
    {
        Instantiate(wall, pos, Quaternion.identity, transform);
    }

    public void PlaceEnemy(Vector3 pos)
    {
        GameObject this_enemy = Instantiate(enemy, pos, Quaternion.identity, transform);
        this_enemy.transform.Rotate(0, 90 * Random.Range(0, 4), 0);

    }

    public void DeleteExistingLevel()
    {
        int count_deleted = 0;

        foreach (Transform child in transform)
        {
            //child is your child transform
            if (child.gameObject.name.Contains(generationArea.name) == false)
            {
                if (Application.isPlaying)
                {
                    Destroy(child.gameObject);
                    count_deleted++;
                }
                else
                {
                    DestroyImmediate(child.gameObject);
                    count_deleted++;
                }
            }

        }

        ////Debug.Log(count_deleted.ToString() + " enemys deleted from "+ this.transform.parent.gameObject.name);


    }
}

