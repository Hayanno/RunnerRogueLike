using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private int score = 0;

    private UIController myUIController;
    private SpawnController mySpawnController;

    private void Start() {
        myUIController = FindObjectOfType<UIController>();
        mySpawnController = FindObjectOfType<SpawnController>();
    }

    public void GameOver() {
        mySpawnController.StopScroll();
        StartCoroutine(myUIController.ShowEndPanel(1f, score));
    }

    public void Restart() {
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.white, 2.0f);
    }

    public void IncrementScore() {
        score++;
        myUIController.DisplayScore(score);
    }
}
