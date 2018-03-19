using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject gameOverPanel;
    public Text goldText;
    public Text currentText;

    public IEnumerator ShowEndPanel(float delayTime, int score) {
        yield return new WaitForSeconds(delayTime);
        ShowOverPanel(score);
    }

    public void ShowOverPanel(int gold) {
        goldText.gameObject.SetActive(false);

        // Sauvegarder ici les permanents et les golds
        
        currentText.text = "Gold : " + gold.ToString();

        gameOverPanel.SetActive(true);
    }

    public void DisplayGold(int gold) {
        goldText.text = gold.ToString();
    }
}
