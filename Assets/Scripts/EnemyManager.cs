using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> EnemyTypes = new List<GameObject>();
    float minX, maxX, minY, maxY;

    public void RespawnEnemy()
    {
        if(this != null)
            Instantiate(EnemyTypes[(int)Random.Range(0, EnemyTypes.Count-1)], 
                new Vector3(Random.Range(minX, maxX), Random.Range(maxY, maxY+3), 0), 
                Quaternion.identity,transform);
        
    }

    public void Start()
    {
        minX = CameraExtensions.OrthographicBounds(Camera.main).min.x;
        maxX = CameraExtensions.OrthographicBounds(Camera.main).max.x;

        minY = CameraExtensions.OrthographicBounds(Camera.main).min.y;
        maxY = CameraExtensions.OrthographicBounds(Camera.main).max.y;

        for (int i = 0; i < EnemyTypes.Count; i++)
        {
            Instantiate(EnemyTypes[i],
                        new Vector3(Random.Range(minX, maxX), Random.Range(maxY, maxY + 3), 0),
                        Quaternion.identity, transform);
        }
        
    }
}
