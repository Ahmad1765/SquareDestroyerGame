using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    int score = 0;
    int highScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 000";
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Update the high score text
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "HighScore: " + highScore.ToString();
            // Save the updated high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Make sure to save changes immediately
        }
    }

    public void AddScore()
    {
        score++;
    }
}
