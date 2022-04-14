using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float screenwidth = 5f;
    public float slowness = 10f;
    public GameObject theSpawner;
    public Text scoreText;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x, -screenwidth, screenwidth);

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
