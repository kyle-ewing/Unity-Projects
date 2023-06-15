using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class LevelEvents {

    public static UnityAction<Transform> levelLoaded;

    public static UnityAction<SceneAsset, string> levelExit;
}
