using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escalera_controller : MonoBehaviour
{
    public GameObject OsoBack;
    private bool isFirstCollision = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFirstCollision)
        {
            Collider2D oso34Collider = collision.collider;
            Vector3 spawPosition = new Vector3(6.49f, oso34Collider.transform.position.y, oso34Collider.transform.position.z);
            var osoSpawed = Instantiate(OsoBack, spawPosition, Quaternion.identity);
            osoSpawed.SetActive(true);
            oso34Collider.gameObject.SetActive(false);
            Destroy(oso34Collider.gameObject);
            isFirstCollision = false;
        }
        StartCoroutine(WaitAMomentOnUpstair(collision));
    }

    IEnumerator WaitAMomentOnUpstair(Collision2D collision)
    {
        yield return new WaitForSeconds(0.2f);

        collision.otherCollider.enabled = false;

        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
