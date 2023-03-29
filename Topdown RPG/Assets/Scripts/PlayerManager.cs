using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public PlayerStats playerStats;
    

    void Start() {
        
    }

    void Update() {
        
    }

    private void FixedUpdate() {
        updateStamina();
    }

    private void updateStamina() {
        if (Input.GetKey("q")) {
            playerStats.stamina--;
            Debug.Log(playerStats.stamina);
        }
    }
}
