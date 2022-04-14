using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public float screenwidth = 6f;
    public float slowness = 10f;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
