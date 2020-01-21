using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public LivesParameter lives;
    public ScoreParameter score;
    public GameParameters parameters;
    public ScoreManager scoreManager;
    public LivesManager livesManager;
    public GameObject UI;

    private void Start()
    {
        if(!parameters.HasReset)
        {
            score.CurrentScore = 0;
            parameters.lifes = lives.lifes;
        }
        else
            parameters.currentScore = score.CurrentScore;
    }

    public void ResetLevel()
    {
        parameters.HasReset = true;
        parameters.currentScore = score.CurrentScore;
        LoadThisScene();
    }

    public void RestartGame()
    {
        parameters.HasReset = false;
        lives.lifes = parameters.lifes;
        scoreManager.SaveHighScore();
        UI.SetActive(false);
        LoadThisScene();
    }

    public void LoadThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApplication()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
