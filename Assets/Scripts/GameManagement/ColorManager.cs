using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    private const int SIZE = 3;

    public int colorIdx;
    public Color skyCol;
    public Color groundCol;
    public Color enemyCol;


    public Color[] skyColors;

    public Material GroundMaterial;
    public Color[] groundColors;

    public Material EnemyMaterial;
    public Color[] enemyColors;

    //This is Main Camera in the Scene
    Camera m_MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        colorIdx = Random.Range(0, skyColors.Length);

        GroundMaterial.SetColor("_Color", groundColors[colorIdx]);
        EnemyMaterial.SetColor("_Color", enemyColors[colorIdx]);


        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        m_MainCamera.backgroundColor = skyColors[colorIdx];



        skyCol = skyColors[colorIdx];
        groundCol = groundColors[colorIdx];
        enemyCol = enemyColors[colorIdx];
    }

}
