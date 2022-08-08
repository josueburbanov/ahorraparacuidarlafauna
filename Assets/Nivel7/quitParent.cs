using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitParent : MonoBehaviour
{
    public player_controller1 player;
    public PhysicsMaterial2D slippery;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
        player.speed = player.formerSpeed;
        oso_transport.needToStop = true;
        collision.collider.sharedMaterial = slippery;
    }
}
