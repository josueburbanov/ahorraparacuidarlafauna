using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arana_controller : MonoBehaviour
{
    // Update is called once per frame
    Rigidbody2D rb;
    public float speed = 4f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
