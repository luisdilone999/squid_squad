using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float screenwidth = 5.5f;
    public float slowness = 10f;
    public float laneLength = 2.2f;
    public GameObject theSpawner;
    public Text scoreText;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector2 newPosition = transform.position;
        if(Input.GetKeyDown(KeyCode.A)){
            newPosition.x -= laneLength;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            newPosition.x += laneLength;
        }

        newPosition.x = Mathf.Max(Mathf.Min(newPosition.x, 4.4f), -4.4f);
        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter2D() {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel() {
        Time.timeScale = 1f/slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime/slowness;

        yield return new WaitForSeconds(1f/slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime*slowness;

        scoreText.text = "0";
        BlockSpawner spawner = theSpawner.GetComponent<BlockSpawner>();
        spawner.score = -1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
