using TMPro;

public class ScoreManager : Manager
{
    public TextMeshProUGUI scoreText;

    private int score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    protected override void SetManager()
    {
        Managers.scoreManager = this;
    }

    private void UpdateScoreText()
    {
        scoreText.text = ("x" + score.ToString());
    }

    public void AddScore(int score_)
    {
        score += score_;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }
}
