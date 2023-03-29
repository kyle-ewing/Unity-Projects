using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenTrigger : MonoBehaviour {
    private bool ovenactive = false;
    private Animator anim;
    
    void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D player) {
        if(player.gameObject.CompareTag("Player")) {
            ovenactive = true;
            anim.SetBool("oventrigger", ovenactive);
        }
    }

    private void OnTriggerExit2D(Collider2D player) {
        if(player.gameObject.CompareTag("Player")) {
            ovenactive = false;
            anim.SetBool("oventrigger", ovenactive);
        }
    }
}
