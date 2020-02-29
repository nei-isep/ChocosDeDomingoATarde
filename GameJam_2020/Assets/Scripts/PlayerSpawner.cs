using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner: MonoBehaviour
{
    static System.Random random = new System.Random();
    public GameObject[] spawnPoints;
    public GameObject player;
    public GameObject endPoint;
    public int currentSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = chooseSpawnPoint().transform.position;
        endPoint.transform.position = chooseEndPoint().transform.position;
    }

    private GameObject chooseSpawnPoint()
    {
        currentSpawnPoint = random.Next(0, spawnPoints.Length);
        return spawnPoints[currentSpawnPoint];
    }

    private GameObject chooseEndPoint()
    {
        int currentEndPoint = currentSpawnPoint;
        while (currentEndPoint == currentSpawnPoint)
        {
            currentEndPoint = random.Next(0, spawnPoints.Length);
        }
        return spawnPoints[currentEndPoint];
    }
}
