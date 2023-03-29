using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

    public int sceneIndex;
    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D changeScene) {
        if (changeScene.gameObject.CompareTag("Player")) {
            //DontDestroyOnLoad(player);
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }
    }
}
