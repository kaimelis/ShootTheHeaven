using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Lives", menuName = "SObj/Lives", order = 1)]
public class LivesParameter : ScriptableObject
{
    public int lifes = 3;

    public void RemoveALife()
    {
        lifes -= 1;
    }
}
