using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Point 1")]
    public GameObject point1;
    public int quantityOfPoint1 = 10;
    public int heightOfAreaOfPoint1 = 10;
    public int widthOfAreaOfPoint1 = 10;

    [Header("Enemy 1")]
    public GameObject enemy1;
    public int quantityOfEnemy1 = 10;
    public int heightOfAreaOfEnemy1 = 10;
    public int widthOfAreaOfEnemy1 = 10;



    private void Awake()
    {
        // Point 1
        int heightMinOfPoint1 = heightOfAreaOfPoint1 - (heightOfAreaOfPoint1 * 2);
        int widthMinOfPoint1 = widthOfAreaOfPoint1 - (widthOfAreaOfPoint1 * 2);

        int pos = 0;
        while(pos < quantityOfPoint1)
        {
            int x = Random.Range(widthMinOfPoint1, widthOfAreaOfPoint1);
            int y = Random.Range(heightMinOfPoint1, heightOfAreaOfPoint1);
            Vector3 area = new Vector3(x, y, 0);
            Instantiate(point1, area, Quaternion.identity);
            pos++;
        }

        // Enemy 1
        int heightMinOfEnemy1 = heightOfAreaOfEnemy1 - (heightOfAreaOfEnemy1 * 2);
        int widthMinOfEnemy1 = widthOfAreaOfEnemy1 - (widthOfAreaOfEnemy1 * 2);

        int posEnemy = 0;
        while (posEnemy < quantityOfEnemy1)
        {
            int x = Random.Range(widthMinOfEnemy1, widthOfAreaOfEnemy1);
            int y = Random.Range(heightMinOfEnemy1, heightOfAreaOfEnemy1);
            Vector3 area = new Vector3(x, y, 0);
            Instantiate(enemy1, area, Quaternion.identity);
            posEnemy++;
        }

    }
}
