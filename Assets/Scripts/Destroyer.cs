using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    void Start() {
        GetComponent<Rigidbody2D>(); 
    }

    void Update() {
        if (transform.position.y < -0.5) {
            Destroy(gameObject);
        }
    }

}
