using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public AudioClip jump;
    public AudioClip scoreSFX;
    public AudioClip deadSFX;

    public float jumpPower = 10.0f;

    private ChallengeController myChallengeController;
    private GameController myGameController;
    private AudioSource myAudioPlayer;
    private Rigidbody2D myRigidbody;

    private bool isGameOver = false;
    private bool isGrounded = false;
    private float posX = 0.0f;
    
    void Start () {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myChallengeController = FindObjectOfType<ChallengeController>();
        myGameController = FindObjectOfType<GameController>();
        myAudioPlayer = FindObjectOfType<AudioSource>();
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver) {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
            myAudioPlayer.PlayOneShot(jump);
            isGrounded = false;
        }

        if (transform.position.x < posX - 0.01 && !isGameOver) {
            GameOver();
        }
	}

    void GameOver() {
        isGameOver = true;
        myAudioPlayer.PlayOneShot(deadSFX);
        myChallengeController.GameOver();
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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Star") {
            myGameController.IncrementScore();
            myAudioPlayer.PlayOneShot(scoreSFX);
            Destroy(other.gameObject);
        }
    }
}
