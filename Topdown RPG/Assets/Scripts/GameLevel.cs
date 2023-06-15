using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour {
    
    public Transform defaultPlayerSpawn;

    // Start the game level
    void Start() {
        LevelEvents.levelLoaded.Invoke(defaultPlayerSpawn);
    }
}
