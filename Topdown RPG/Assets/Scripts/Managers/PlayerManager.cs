using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerManager", menuName = "PlayerManager")]
public class PlayerManager : ScriptableObject {
    public GameState gameState { get; set; }
    public GameObject activePlayer { get; private set; }
    public string spawnTag;
    
    [SerializeField]
    private GameObject playerPrefab;

    private void OnEnable() {
        LevelEvents.levelLoaded += SpawnPlayer;
    }


    private void SpawnPlayer(Transform playerPosition) {
        if (gameState.PlayerSpawnLocation != "") {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag(spawnTag);
            bool foundSpawn = false;

            foreach (GameObject spawn in spawns) {
                if (spawn.name == gameState.PlayerSpawnLocation) {
                    foundSpawn = true;


                    activePlayer = Instantiate(playerPrefab, spawn.transform.position, Quaternion.identity);
                    break;
                }
            }

            if (!foundSpawn) {
                throw new MissingReferenceException("Could not find player spawn location with name: " + gameState.PlayerSpawnLocation);
            }
        }
        else {
            activePlayer = Instantiate(playerPrefab, playerPosition.transform.position, Quaternion.identity);
            Debug.Log("Player spawned at default location: " + playerPosition);
        }

        if (activePlayer) {
            PlayerEvents.onPlayerSpawned.Invoke(activePlayer.transform);
        }
    }

    private void OnDisable() {
        LevelEvents.levelLoaded -= SpawnPlayer;
    }
}
