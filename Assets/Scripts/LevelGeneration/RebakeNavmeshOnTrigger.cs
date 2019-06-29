using UnityEngine;
using UnityEngine.AI;

public class RebakeNavmeshOnTrigger : MonoBehaviour
{
    public NavMeshSurface surface;

    public void Start()
    {
        surface = GameObject.Find("NavMesh").GetComponent<NavMeshSurface>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Update navemesh based on generated level
            surface.BuildNavMesh();
            ////Debug.Log("Rebuilt nav mesh after trigger");
            ////Debug.Log("Destroy " + this.name);
            Destroy(this);
        }

    }
}
