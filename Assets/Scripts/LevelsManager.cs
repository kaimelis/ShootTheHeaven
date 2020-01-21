using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public LivesParameter lives;
    public ScoreParameter score;
    public GameParameters parameters;
    public ScoreManager scoreManager;
    public GameObject UI;

    private void Start()
    {
        parameters.lifes = lives.lifes;
    }

    public void ResetLevel()
    {
        parameters.currentScore = score.CurrentScore;
        LoadThisScene();
    }

    public void RestartGame()
    {
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
