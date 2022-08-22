using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arana_change_direction : MonoBehaviour
{
    private bool isHit;
    public arana_controller player;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isHit)
        {
            string realName = collider.name;
            if (collider.name.Contains("("))
            {
                 realName = collider.name.Split('(')[0];
                 realName = realName.Split(' ')[0];
            }
            print(realName);
            if (realName.Equals("arana_piezas"))
            {
                collider.gameObject.transform.localScale = new Vector3(-collider.gameObject.transform.localScale.x, collider.gameObject.transform.localScale.y, collider.gameObject.transform.localScale.z);
                isHit = true;
                player.speed = -player.speed;
                StartCoroutine(waitTilTurnOn());//espera a q se gire para activar de nuevo el detector y formar un loop
            }
            
        }

    }

    IEnumerator waitTilTurnOn()
    {
        yield return new WaitForSeconds(1f);
        isHit = false;
    }
}
