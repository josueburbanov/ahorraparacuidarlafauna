using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food_generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plataformPrefab;
    private float height = 3f;
    public float width;
    public float minX = 3f;
    public float maxX = 6f;
    public int numberOfFood = 100;
    private Vector3 spawnPosition = new Vector3();

    void Start()
    {
        
        for (int i = 0; i < numberOfFood; i++)
        {
            spawnPosition.y = Random.Range(-System.Math.Abs( height), height);
            spawnPosition.x += Random.Range(minX, maxX) + plataformPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            Instantiate(plataformPrefab, spawnPosition, Quaternion.identity);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
