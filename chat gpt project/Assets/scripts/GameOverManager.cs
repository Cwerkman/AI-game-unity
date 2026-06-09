using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public TMP_Text finalScoreText;
    public TMP_Text survivalTimeText;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        finalScoreText.text =
            "Final Score: " + GameManager.Instance.GetScore();

        float time = GameManager.Instance.GetSurvivalTime();

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        survivalTimeText.text =
            "Time Survived: " +
            minutes.ToString("00") +
            ":" +
            seconds.ToString("00");

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit Game");
    }
}
