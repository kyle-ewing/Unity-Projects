using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameM : MonoBehaviour {
    private bool gameHasEnded = false;
    public float delay = 1;
    public GameObject completeLevelUI;

    public void CompleteLevel() {
        completeLevelUI.SetActive(true);
    }
    
    public void EndGame() {

        if (!gameHasEnded) {
            gameHasEnded = true;
            Invoke("Restart", delay);
        }
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}
