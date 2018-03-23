using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private UIController myUIController;
    private SpawnController mySpawnController;

    public bool IsGameOver { get; set; }

    private void Start() {
        IsGameOver = false;
        // Replace Find Object Of Type with tags for performance
        myUIController = FindObjectOfType<UIController>();
        mySpawnController = FindObjectOfType<SpawnController>();
    }

    public void GameOver() {
        mySpawnController.StopSpawning();
        StartCoroutine(myUIController.ShowEndPanel(1f, 0));
        IsGameOver = true;
    }

    public void Restart() {
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.white, 2.0f);
    }
}
