using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class PlayerPrefsRemover : MonoBehaviour
{
    [MenuItem("Tools/Player Prefs Remover")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player prefs deleted! . . .");
    }
}