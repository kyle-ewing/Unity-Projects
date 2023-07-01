using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelEvents {

    public static UnityAction<Transform> levelLoaded;

    public static UnityAction<string, string> levelExit;
}
