using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager", menuName = "LevelManager")]
public class LevelManager : ScriptableObject {

    public GameState gameState { get; set; }

    private void OnEnable() {
        LevelEvents.levelExit += onLevelExit;
    }

    private void onLevelExit(string nextLevel, string playerSpawnPosition) {
        gameState.PlayerSpawnLocation = playerSpawnPosition;
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }

    private void OnDisable() {
        LevelEvents.levelExit -= onLevelExit;
    }
}
