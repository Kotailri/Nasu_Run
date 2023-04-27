using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public GameObject back;
    public GameObject content;
    public Button restartButton;
    public TextMeshProUGUI gameOverTextBox;
    public TextMeshProUGUI headerTextBox;

    private Vector3 backScale;

    private void Start()
    {
        backScale = back.transform.localScale;
        content.SetActive(false);
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Managers.audioManager.StopAllSounds();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenUI()
    {
        gameObject.SetActive(true);
        back.transform.localScale = new Vector3(0, backScale.y, backScale.z);
        LeanTween.scaleX(back, backScale.x, 0.5f).setOnComplete(ShowContent);
    }

    private void ShowContent()
    {
        content.SetActive(true);
        gameOverTextBox.text = "Distance: " + (int)Managers.distanceManager.GetDistance() + "m\n\n"
            + "Clefs: x" + Managers.scoreManager.GetScore() + "\n\n" + "Score: " + CalculateScore().ToString() + "\nHigh Score: " + GetHighScore().ToString();
        Time.timeScale = 0;
    }
    private int CalculateScore()
    {
        return ((int)Managers.distanceManager.GetDistance() + Managers.scoreManager.GetScore());
    }

    private int GetHighScore()
    {
        int score = CalculateScore();
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            headerTextBox.text = "New Highscore!!";
            return score;
        }
        headerTextBox.text = "Game Over!";
        return highscore;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)
        {
            RestartGame();
        }
    }
}
