using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameplayParameters))]
public class GameplayParametersEditor : Editor
{
    GameplayParameters gameplayParameters;
    private void OnEnable()
    {
        gameplayParameters = (GameplayParameters)target;

    }

    /*
     * Inspector button that sets all ScriptableObject's variables
     * to their default values. These values are set in the
     * "DefaultValues()" method.
     */

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        if(GUILayout.Button("Default Values"))
        {
            gameplayParameters.DefaultValues();
        }
    }
}
