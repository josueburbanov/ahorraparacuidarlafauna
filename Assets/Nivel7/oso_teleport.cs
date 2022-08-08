using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oso_teleport : MonoBehaviour
{
    public GameObject teleport2;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.transform.localPosition = teleport2.transform.localPosition;
    }
}
