using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGenerator))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGenerator gen = (LevelGenerator)target;

        if (GUILayout.Button("Create Labirynth"))
        {
            gen.GenerateLabirynth();
        }
    }
}
