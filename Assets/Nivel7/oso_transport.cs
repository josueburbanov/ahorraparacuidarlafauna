using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oso_transport : MonoBehaviour
{
    private bool isHit;
    public player_controller1 player;
    private bool ableToMove;
    public static bool needToStop;
    public PhysicsMaterial2D roughy;
    private BoxCollider2D boxCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isHit)
        {
            if (collision.collider.name.Equals("Oso piezasperfil34"))
            {
                ableToMove = true;
                needToStop = false;
                player.speed = 0;
                collision.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 20f);
                collision.collider.sharedMaterial = roughy;
                isHit = true;
                collision.collider.transform.SetParent(gameObject.transform);
                StartCoroutine(waitTilEstabilize());
                
            }
        }
    }

    IEnumerator waitTilEstabilize()
    {
        yield return new WaitForSeconds(0.2f);
        boxCollider.enabled = true;
    }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        ableToMove = false;
    }

    private void FixedUpdate()
    {
        if (ableToMove && !needToStop)
        {
            transform.position += (new Vector3(5f,0f,0f))*Time.deltaTime;
        }
    }


}
