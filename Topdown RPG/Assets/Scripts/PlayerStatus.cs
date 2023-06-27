using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    [SerializeField] 
    private PlayerStats playerStats;
    
    private float staminaToGainPerSecond = 4;
    private float staminaToLosePerSecond = 5;
    private float staminaRefillTimer = 1f;


    void Update() {
        StaminaRegen();
        StaminaDrain();
    }

    private void StaminaRegen() {
        if (playerStats.Sprinting is false) {
            staminaRefillTimer -= Time.fixedTime;
            //
            // if (staminaRefillTimer < 0) {
            //     playerStats.Stamina += staminaToGainPerSecond * Time.deltaTime;
            //     staminaRefillTimer = 1f;
            // }
            if (!IsStamFull()) {
                playerStats.Stamina += staminaToGainPerSecond * Time.deltaTime;
            }
        }
    }

    private void StaminaDrain() {
        if (playerStats.Sprinting) {
            if (playerStats.Stamina > 0) {
                playerStats.Stamina -= staminaToLosePerSecond * Time.deltaTime;
            }
        }
    }
    
    private bool IsStamFull() {
        if(HelperMethods.Approximation(playerStats.Stamina, playerStats.MaxStamina, 0.01f)) {
            return true;
        }
        return false;
    }


}
