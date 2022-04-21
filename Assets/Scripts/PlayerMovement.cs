using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float screenwidth = 2f;
    public float centerscreen = 2.5f;
    public float slowness = 10f;
    public float laneLength = .2f;
    public GameObject theSpawner;
    public GameObject thePlayer;
    // public Text scoreText;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector2 newPosition = transform.position;

        if(Input.GetKeyDown(KeyCode.Comma)){
            newPosition.x -= laneLength;
        }
        if(Input.GetKeyDown(KeyCode.Slash)){
            newPosition.x += laneLength;
        }

        newPosition.x = Mathf.Max(Mathf.Min(newPosition.x, centerscreen + screenwidth), centerscreen - screenwidth);

        transform.position = newPosition;
        // rb.MovePosition(newPosition);
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision) {
        // scoreText.text = "0";
        BlockSpawner spawner = theSpawner.GetComponent<BlockSpawner>();
        spawner.score = -1;

        var cubeRenderer = thePlayer.GetComponent<Renderer>();

        cubeRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.5f);
        cubeRenderer.material.SetColor("_Color", Color.white);

        Destroy(collision.gameObject);
    }

    IEnumerator RestartLevel() {
        Time.timeScale = 1f/slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime/slowness;

        yield return new WaitForSeconds(1f/slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime*slowness;

        // scoreText.text = "0";
        BlockSpawner spawner = theSpawner.GetComponent<BlockSpawner>();
        spawner.score = -1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
