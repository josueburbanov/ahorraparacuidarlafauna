using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeCanvasAfterStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitTilNoText());
    }

    IEnumerator waitTilNoText()
    {
        yield return new WaitForSeconds(7);
        gameObject.SetActive(false);
    }
}
