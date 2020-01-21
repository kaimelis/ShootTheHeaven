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

    //At the end of the game
    public void SaveHighScore()
    {
        if(ScoreParameter.HighScore < ScoreParameter.CurrentScore)
            ScoreParameter.HighScore = ScoreParameter.CurrentScore;
        FinalHighScoreText.text = ScoreParameter.HighScore.ToString();
    }
}
