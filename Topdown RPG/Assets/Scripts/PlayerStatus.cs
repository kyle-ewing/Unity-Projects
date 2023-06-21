using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    [SerializeField] 
    private PlayerStats playerStats;

    private int maxStamina = 100;

    void Start() {
        StartCoroutine(staminaRegen());
    }

    void Update() {

    }

    private IEnumerator staminaRegen() {
        bool running = true;
        while (running) {
            if (playerStats.Stamina < maxStamina) {
                playerStats.Stamina++;
                Debug.Log(playerStats.Stamina);

            }

            yield return new WaitForSeconds(1);
        }
    }

    private void staminaDrain(Transform staminaHUD) {
        
    }
}
