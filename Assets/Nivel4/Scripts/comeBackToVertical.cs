using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comeBackToVertical : MonoBehaviour
{
    private bool isHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isHit)
        {
            player_controller4.movingLeft = false;
            player_controller4.movingRight = false;
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
