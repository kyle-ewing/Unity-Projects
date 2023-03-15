using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float fowardForce = 2000f;
    public float swidewayForce = 500f;
    void Start()
    {

    }
    
    void FixedUpdate() {
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        if (Input.GetKey("a")) {
            rb.AddForce(-swidewayForce * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("d")) {
            rb.AddForce(swidewayForce * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f) {
            FindObjectOfType<GameM>().EndGame();
        }
        
        
    }
}
