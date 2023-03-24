using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    //private float speed;
    public float movementSpeed;
    private Animator anim;
    private Vector2 moveDirection;
    

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update() {
        ProcessInputs();
    }

    void FixedUpdate() {
        Move();
    }

    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        


    }

    void Move() {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
        
        anim.SetFloat("moveX", rb.velocity.x); 
        anim.SetFloat("moveY", rb.velocity.y);
        
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1 ) {
            anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            
            anim.SetFloat("speed", movementSpeed);

        }
    }
}
