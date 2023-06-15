using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

    // public int sceneIndex;
    // private GameObject player;
    //
    // public SceneAsset sceneToLoad;
    //
    //
    // private void Start() {
    //     player = GameObject.Find("Player");
    // }
    //
    // private void OnTriggerEnter2D(Collider2D changeScene) {
    //     if (changeScene.gameObject.CompareTag("Player")) {
    //         //DontDestroyOnLoad(player);
    //         SceneLoader.Load(sceneIndex);
    //     }
    // }
    
    public string triggererTag = "Player";
    public string playerSpawnTransformName = "NOT SET";
    public SceneAsset sceneToLoad;

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag == triggererTag) {

            LevelEvents.levelExit.Invoke(sceneToLoad, playerSpawnTransformName);
        }
    }
}
