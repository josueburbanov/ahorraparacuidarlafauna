using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aranaSpawner : MonoBehaviour
{
    public GameObject arana;
    public float time;
    private float counter = 0;
    public int numero_Aranas;
    public int fuerza;
    private bool isHit;
    Vector3 spawnerPosition = new Vector3();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            StartCoroutine(AranaDrop());
            isHit = true;
        }
    }

    void Start()
    {
        spawnerPosition.x = transform.position.x;
    }

    IEnumerator AranaDrop()
    {
        spawnerPosition = transform.localPosition;
        spawnerPosition.x = spawnerPosition.x + numero_Aranas * 20;
        while (counter < numero_Aranas)
        {
            GameObject troncoSpawed = Instantiate(arana, spawnerPosition, Quaternion.identity);
            Rigidbody2D rb = troncoSpawed.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-fuerza, 0);
            yield return new WaitForSeconds(time);
            counter++;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
