using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escalera2_controller : MonoBehaviour
{
    private GameObject PlayerBack;
    public GameObject ArmadilloBack;
    public GameObject TapirBack;
    public GameObject OsoBack;
    private bool isFirstCollision = true;
    int contCol = 0;

    void Start()
    {
        if (followPlayerX.isOso)
        {
            PlayerBack = OsoBack;
        }
        else if (followPlayerX.isTapir)
        {
            PlayerBack = TapirBack;
        }
        else if (followPlayerX.isArmadillo)
        {
            PlayerBack = ArmadilloBack;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFirstCollision)
        {
            Collider2D oso34Collider = collision.collider;
            oso34Collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Vector3 spawPosition = new Vector3(transform.position.x, oso34Collider.transform.position.y, oso34Collider.transform.position.z);
            PlayerBack.transform.position = spawPosition;
            PlayerBack.SetActive(true);
            collision.collider.gameObject.SetActive(false);
            isFirstCollision = false;
        }
        StartCoroutine(WaitAMomentOnUpstair(collision));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Oso piezasperfil34")
        {
            if (!isFirstCollision)
                isFirstCollision = true;
        }
    }

    IEnumerator WaitAMomentOnUpstair(Collision2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        collision.otherCollider.enabled = false;
    }
}
