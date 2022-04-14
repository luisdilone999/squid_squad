using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    public static float score = 0f;
    public Text scoreText;

    void Start() {
        GetComponent<Rigidbody2D>(); 
    }

    void Update() {
        if (transform.position.y < -0.5) {
            Destroy(gameObject);
            score += 0.25f;
            
            scoreText.text = score.ToString();
        }
    }

}
