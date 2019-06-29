using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleOnAndroid : MonoBehaviour
{

    MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();

        if (Application.platform == RuntimePlatform.Android)
        {
            mesh.enabled = false;
        }
    }
}