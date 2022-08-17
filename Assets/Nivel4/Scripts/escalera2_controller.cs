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

    void Start()
    {
        StartCoroutine(Pause(3));
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

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.0001f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;

        }
        Time.timeScale = 1f;
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
