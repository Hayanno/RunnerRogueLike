using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpPower = 10.0f;
    
    private Rigidbody2D rigidBody;
    private GameController gameController;
    
    private bool isGrounded = false;
    private float posX = 0.0f;
    private double deltaPosX = 0.01; // Workaround because Unity fix position with a precision of 0.00(0*?)5 for performance issues

    void Start () {
        gameController = FindObjectOfType<GameController>();
        rigidBody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
    }
	
	void Update () {
        if (gameController.IsGameOver)
            return;

        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            rigidBody.AddForce(Vector3.up * (jumpPower * rigidBody.mass * rigidBody.gravityScale * 20.0f));
            //myAudioPlayer.PlayOneShot(jump);
            isGrounded = false;
        }

        if (transform.position.x < posX - deltaPosX) {
            gameController.GameOver();
        }
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            isGrounded = false;
        }
    }

    /*
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Star") {
            myGameController.IncrementGold(other.gameObject.GetComponent<>());
            myAudioPlayer.PlayOneShot(scoreSFX);
            Destroy(other.gameObject);
        }
    }
    */
}
