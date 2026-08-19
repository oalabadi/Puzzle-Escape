using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridManagement))]
class GridManagementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GridManagement gm = (GridManagement)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Reset Grid"))
            gm.ResetGrid();
    }
}
