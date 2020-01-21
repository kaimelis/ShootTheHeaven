using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "SObj/HighScore", order = 1)]
public class ScoreParameter : ScriptableObject
{
   public int HighScore;
   public int CurrentScore;


    private int _previousScore;
    private bool _scoreAdded = false;

    public void AddScore()
    {
        if (!_scoreAdded)
        {
            CurrentScore += 1;
        }

        if (_previousScore == CurrentScore - 1)
        {
            _scoreAdded = true;
            _previousScore = CurrentScore;
        }
        else
        {
            _scoreAdded = false;
        }
    }
}

