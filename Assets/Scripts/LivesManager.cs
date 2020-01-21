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

    public List<GameObject> LivesSprites = new List<GameObject>();

    public void Start()
    {
        for (int i = 0; i < LivesHUD.transform.childCount; i++)
        {
            LivesSprites.Add(LivesHUD.transform.GetChild(i).gameObject);
        }
    }

    public void RemoveALife()
    {
        Lives.lifes -= 1;
        if (Lives.lifes <= 0)
        {
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
