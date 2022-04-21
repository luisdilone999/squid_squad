using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public float timeSpawn = 2f;
    public float timeWaves = 2f;

    public int score = -1;
    public int items = 0;
    public Text scoreText;
    public Text itemText;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Period)) { 
            items -= 1;
            itemText.text = "Ink sacs: " + items.ToString();
        }

        if (Time.time >= timeSpawn) {
            Spawner();
            timeSpawn = Time.time + timeWaves;

            timeWaves -= 0.05f;
            timeWaves = Mathf.Max(0.5f, timeWaves);

            score += 1;

            if (score % 20 == 0 && score != 0) {
                items += 1;
                itemText.text = "Ink sacs: " + items.ToString();
            }
            
            scoreText.text = score.ToString();
        }
    }

    void Spawner() {
        int randomNumber1 = Random.Range(0, spawnPoints.Length);
        int randomNumber2 = Random.Range(0, spawnPoints.Length);
        if(Mathf.Abs(randomNumber1 - randomNumber2) == 1) {
            if(randomNumber1 > randomNumber2) {
                if(randomNumber1 != 5) {
                    randomNumber1 += 1;
                }
                else {
                    randomNumber2 -= 1;
                }
            } 
            else {
                if(randomNumber2 != 5) {
                    randomNumber2 += 1;
                }
                else {
                    randomNumber1 -= 1;
                }
            }
        }

        for(int i = 0; i < spawnPoints.Length; i++) {
            if(randomNumber1 != i && randomNumber2 != i) {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
