using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * MovementSpeed;
    }
}
