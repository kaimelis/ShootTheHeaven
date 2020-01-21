using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parameters", menuName = "SObj/Game Parameters", order = 1)]
public class GameParameters : ScriptableObject
{
    public int lifes;
    public int currentScore;
}
