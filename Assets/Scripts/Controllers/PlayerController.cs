using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    #region PUBLIC UNITY VARIABLE
    public AudioClip jump;
    public AudioClip scoreSFX;
    public AudioClip deadSFX;
    #endregion

    #region PUBLIC VARIABLE
    public float jumpPower = 10.0f;
    #endregion

    #region PRIVATE UNITY VARIABLE
    private AudioSource myAudioPlayer;
    private Rigidbody2D myRigidbody;
    #endregion

    #region PRIVATE VARIABLE
    private bool isGameOver = false;
    private bool isGrounded = false;
    private float posX = 0.0f;
    // Workaround because Unity fix position with a precision of 0.00(0*?)5 for performance issues
    private double deltaPosX = 0.01;
    #endregion

    void Start () {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        myAudioPlayer = FindObjectOfType<AudioSource>();

        posX = transform.position.x;
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver) {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
            myAudioPlayer.PlayOneShot(jump);
            isGrounded = false;
        }

        if (transform.position.x < posX - deltaPosX && !isGameOver) {
            GameOver();
        }
	}

    void GameOver() {
        isGameOver = true;
        myAudioPlayer.PlayOneShot(deadSFX);
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
