using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocks_spawner : MonoBehaviour
{
    public List<GameObject> rocks;
    public float time;
    private float counter = 0;
    public int length;
    public int fuerza;
    private bool isHit;
    public bool increaseSpeed;
    public bool decreaseSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            StartCoroutine(RockDrop());
            isHit = true;
            if (increaseSpeed)
            {
                player_controller6.speed++;
                
                increaseSpeed = false;
            }
            else if(decreaseSpeed)
            {
                player_controller6.speed--;
                
                decreaseSpeed = false;
            }
            
        }

    }

    void Start()
    {

    }

    IEnumerator RockDrop()
    {
        Vector3 spawnerPosition = new Vector3();
        spawnerPosition = transform.localPosition;
        spawnerPosition.y = spawnerPosition.y + Random.Range(13,15);
        spawnerPosition.x += length*0.9f;
        while (counter < length)
        {
            GameObject troncoSpawed = Instantiate(rocks[Random.Range(0,rocks.Count)], spawnerPosition, Quaternion.identity);
            spawnerPosition.x += Random.Range(length*0.2f - 2, length * 0.2f + 2);
            yield return new WaitForSeconds(time);
            counter++;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
