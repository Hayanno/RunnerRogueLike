using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject gameOverPanel;
    public GameObject newAlert;
    public Text scoreText;
    public Text bestText;
    public Text currentText;

    public IEnumerator ShowEndPanel(float delayTime, int score) {
        yield return new WaitForSeconds(delayTime);
        ShowOverPanel(score);
    }

    public void ShowOverPanel(int score) {
        scoreText.gameObject.SetActive(false);

        if (score > PlayerPrefs.GetInt("Best", 0)) {
            PlayerPrefs.SetInt("Best", score);
            newAlert.SetActive(true);
        }

        bestText.text = "Best Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        currentText.text = "Current Score : " + score.ToString();

        gameOverPanel.SetActive(true);
    }

    public void DisplayScore(int score) {
        scoreText.text = score.ToString();
    }
}
