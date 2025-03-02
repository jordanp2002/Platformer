using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
