using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public LivesParameter Lives;
    public GameObject LivesHUD;
    
    public GameObject ResetCanvas;
    public GameObject RestartCanvas;
    public ScoreManager ScoreManager;
    public List<GameObject> LivesSprites = new List<GameObject>();

    public void Start()
    {
        //need to disable lives when reseting everything
        if(Lives.lifes < 3)
        {
            for (int i = LivesHUD.transform.childCount - 1; i > Lives.lifes-1; i--)
            {
                LivesHUD.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < LivesHUD.transform.childCount; i++)
        {
            if (LivesHUD.transform.GetChild(i).gameObject.activeInHierarchy)
                LivesSprites.Add(LivesHUD.transform.GetChild(i).gameObject);
        }
        
        
    }

    public void RemoveALife()
    {
        Lives.lifes -= 1;
        if (Lives.lifes <= 0)
        {
            ScoreManager.SaveHighScore();
            RestartCanvas.SetActive(true);
            Lives.lifes = 3;
        }
        else
        {
            LivesSprites[LivesSprites.Count - 1].SetActive(false);
            LivesSprites.RemoveAt(LivesSprites.Count - 1);
            ResetCanvas.SetActive(true);
        }
    }
}
