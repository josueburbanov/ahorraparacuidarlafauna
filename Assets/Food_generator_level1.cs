using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_generator_level1 : MonoBehaviour
{
    public GameObject plataformPrefab;
    private float heightMin = -3f;
    private float heightMax = 3f;
    public float width;
    public float minX = 3f;
    public float maxX = 6f;
    public int numberOfFood = 200;
    private Vector3 spawnPosition = new Vector3();
    void Start()
    {
        for (int i = 0; i < numberOfFood; i++)
        {
            spawnPosition.y = Random.Range(heightMin, heightMax);
            heightMin -= 1.55f;
            heightMax -= 1.55f;
            spawnPosition.x += Random.Range(minX, maxX) + plataformPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            Instantiate(plataformPrefab, spawnPosition, Quaternion.identity);

        }

        heightMin = -3f;
        heightMax = 3f;
        spawnPosition = new Vector3();

        for (int i = 0; i < numberOfFood; i++)
        {
            spawnPosition.y = Random.Range(heightMin, heightMax);
            heightMin -= 1.45f;
            heightMax -= 1.45f;
            spawnPosition.x += Random.Range(minX, maxX) + plataformPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            Instantiate(plataformPrefab, spawnPosition, Quaternion.identity);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
