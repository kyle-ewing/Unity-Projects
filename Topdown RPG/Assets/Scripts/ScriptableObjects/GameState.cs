using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "GameState")]
public class GameState : ScriptableObject { [SerializeField] 
    private string playerSpawnLocation = "";

    public string PlayerSpawnLocation {
        get => playerSpawnLocation;
        set => playerSpawnLocation = value;
    }
}
