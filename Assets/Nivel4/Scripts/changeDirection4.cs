using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDirection4 : MonoBehaviour
{
    private bool isHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isHit)
        {
            collision.collider.transform.eulerAngles = new Vector3(0, 0, 0);
            isHit = true;
            player_controller4.movingRight = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
