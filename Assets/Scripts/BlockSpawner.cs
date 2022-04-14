using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public float timeSpawn = 2f;
    public float timeWaves = 1.5f;

    void Update() {
        if (Time.time >= timeSpawn) {
            Spawner();
            timeSpawn = Time.time + timeWaves;
        }
    }

    void Spawner() {
        int randomNumber = Random.Range(0, spawnPoints.Length);

        for(int i = 0; i < spawnPoints.Length; i++) {
            if(randomNumber != i) {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
