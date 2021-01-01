using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public List<GameObject> gameObjects = null;
    float gap = 2.0f;
    Vector3 center;
    private void Start()
    {
        center = new Vector3(150/2.0f*gap,0,100/2.0f*gap);
        //gameObjects = new List<GameObject>();
        for(int i = 0; i < 100; i++)
        {
            //Debug.Log(i);
            for(int j = 0; j < 100; j++)
            {
                //Debug.Log("j" + j);
                generateBuildings(i, j);    
            }
        }
    }

    void generateBuildings(int i, int j)
    {
        Vector3 pos = new Vector3(i * gap, 0, j * gap);
        float distanceToCenter = Vector3.Distance(pos, center);
        float radius = (100 * gap) / 2f;
        int num;
        int noise = (int)(Mathf.PerlinNoise(i / 3.0f, j / 3.0f) * 100);
        Debug.Log(noise);
        if (distanceToCenter < 0.3f * radius)
        {
            if (noise < 43)
                num = 4;
            else if (noise >=43 && noise < 80)
                num = 3;
            else
                num = 0;
        }
        else if (distanceToCenter < 0.66f * radius)
        {
            if (noise < 35)
                num = 3;
            else if (noise >= 35 && noise < 90)
                num = 2;
            else
                num = 0;
        }
        else if (distanceToCenter < radius)
        {
            if (noise < 40)
                num = 2;
            else if (noise >= 40 && noise < 80)
                num = 1;
            else
                num = 0;
        }
        else if (distanceToCenter < 1.2f * radius)
        {
            if (noise < 50)
                num = 1;
            else
                num = 0;
        }
        else
        {
            if (noise < 45)
                num = 1;
            else
                num = 0;
        }

        Instantiate(gameObjects[num], new Vector3(i * gap, 0, j * gap), Quaternion.identity);
    }
}
