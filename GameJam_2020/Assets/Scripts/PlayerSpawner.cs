using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner: MonoBehaviour
{
    static System.Random random = new System.Random();
    public GameObject[] spawnPoints;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = chooseSpawnPoint().transform.position;
    }

    private GameObject chooseSpawnPoint()
    {
        return spawnPoints[random.Next(0, spawnPoints.Length)];
    }
}
