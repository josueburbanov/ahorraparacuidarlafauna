using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escalerapro_controller : MonoBehaviour
{
    private bool isFirstCollision = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFirstCollision)
        {
            print("First Collision");
            collision.collider.transform.localScale = new Vector3(-collision.collider.transform.localScale.x, collision.collider.transform.localScale.y, collision.collider.transform.localScale.z);
            collision.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.collider.gameObject.GetComponent<Rigidbody2D>().position = new Vector3(transform.localPosition.x, collision.collider.gameObject.transform.position.y, collision.collider.gameObject.transform.position.z);
            isFirstCollision = false;
        }
        StartCoroutine(WaitAMomentOnUpstair(collision));
    }

    IEnumerator WaitAMomentOnUpstair(Collision2D collision)
    {
        yield return new WaitForSeconds(0.01f);
        collision.otherCollider.enabled = false;
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
