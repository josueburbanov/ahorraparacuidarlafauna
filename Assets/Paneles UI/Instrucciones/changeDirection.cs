using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDirection : MonoBehaviour
{
    private bool isHit;
    public player_cont_Ins player;
    public bool needEnter;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isHit)
        {
            if (!needEnter)
            {
                collider.gameObject.transform.localScale = new Vector3(-collider.gameObject.transform.localScale.x, collider.gameObject.transform.localScale.y, collider.gameObject.transform.localScale.z);
                isHit = true;
                player.speed = -player.speed;
                StartCoroutine(waitTilTurnOn()); //espera a q se gire para activar de nuevo el detector y formar un loop
            }
            else
            {
                StartCoroutine(waitTilTurnOn());
            }
            
        }
        
    }

    IEnumerator waitTilTurnOn()
    {
        yield return new WaitForSeconds(1f);
        isHit = false;
        needEnter = false;
    }
}
