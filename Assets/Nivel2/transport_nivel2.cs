using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transport_nivel2 : MonoBehaviour
{
    private bool isHit;
    private bool ableToMove;
    public static bool needToStop;
    private BoxCollider2D boxCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isHit)
        {
            if (collision.collider.name.Equals("Oso piezasperfil34"))
            {
                ableToMove = true;
                needToStop = false;
                //collision.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 20f);
                collision.collider.transform.SetParent(gameObject.transform);
                GameObject.Find("Oso piezasperfil34").GetComponent<player_controller1>().speed = 0;
                //StartCoroutine(waitTilEstabilize());

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject.Find("Oso piezasperfil34").GetComponent<player_controller1>().speed = 0.1f;
    }

    IEnumerator waitTilEstabilize()
    {
        yield return new WaitForSeconds(0.2f);
        boxCollider.enabled = true;
    }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (ableToMove && !needToStop)
        {
            transform.position += (new Vector3(8f, 0f, 0f)) * Time.deltaTime;
        }
    }
}
