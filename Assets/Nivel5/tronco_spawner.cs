using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronco_spawner : MonoBehaviour
{
    public GameObject tronco;
    public float time;
    private float counter = 0;
    public int length;
    public int fuerza;
    private bool isHit;
    Vector3 spawnerPosition = new Vector3();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            StartCoroutine(TroncoDrop());
            isHit = true;
            print("spawner activo "+name);
        }
        
    }

    void Start()
    {
        spawnerPosition.x = transform.position.x;
    }

    IEnumerator TroncoDrop()
    {
        spawnerPosition = transform.localPosition;
        spawnerPosition.x += length * 12;
        while ( counter < length)
        {
            GameObject troncoSpawed = Instantiate(tronco, spawnerPosition, Quaternion.identity);
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
