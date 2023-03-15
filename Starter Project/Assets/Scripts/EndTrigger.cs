using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameM gameManager;
    
    private void OnTriggerEnter() {
        gameManager.CompleteLevel();
    }
}
