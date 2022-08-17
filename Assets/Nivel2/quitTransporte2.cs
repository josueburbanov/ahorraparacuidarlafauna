using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitTransporte2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transport_nivel2.needToStop = true;
        GameObject.Find("Oso piezasperfil34").GetComponent<player_controller1>().speed = 8f;
    }
}
