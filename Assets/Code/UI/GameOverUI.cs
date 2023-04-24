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

    private Vector3 backScale;

    private void Start()
    {
        backScale = back.transform.localScale;
        content.SetActive(false);
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
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
            + "Clefs: x" + Managers.scoreManager.GetScore() + "\n\n" + "Score: " + CalculateScore();
    }
    private string CalculateScore()
    {
        return ((int)Managers.distanceManager.GetDistance() + Managers.scoreManager.GetScore()).ToString();
    }
}