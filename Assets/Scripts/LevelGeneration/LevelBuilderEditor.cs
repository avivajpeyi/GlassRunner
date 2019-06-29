//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//[CustomEditor(typeof(LevelGenerator))]
//public class LevelBuilderEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        LevelGenerator myScript = (LevelGenerator)target;
//        if (GUILayout.Button("Build Level"))
//        {
//            myScript.Start();
//            //myScript.GenerateLevel();

//        }

//        if (GUILayout.Button("Delete Level"))
//        {
//            myScript.DeleteExistingLevel();

//        }
//    }
//}