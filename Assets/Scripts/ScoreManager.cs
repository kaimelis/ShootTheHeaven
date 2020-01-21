using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public ScoreParameter ScoreParameter;
    public Text ScoreHUD;
    public Text FinalHighScoreText;

    public void Update()
    {
        ScoreHUD.text = ScoreParameter.CurrentScore.ToString();
    }

    public void SaveHighScore()
    {
        ScoreParameter.HighScore = ScoreParameter.CurrentScore;
        ScoreParameter.CurrentScore = 0;
        FinalHighScoreText.text = ScoreParameter.HighScore.ToString();
    }
}
