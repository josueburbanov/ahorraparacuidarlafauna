using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_generator5 : MonoBehaviour
{
    public List<GameObject> plataformPrefabs;
    public GameObject min_plataformPrefab;
    public GameObject last_plataformPrefab;
    public GameObject food;
    //private float height = 1f;
    public float width;
    public int numberOfPlataforms = 100;


    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = transform.position.x;
        spawnPosition.z = transform.position.z;
        Vector3 spawnPositionFood = new Vector3();
        spawnPositionFood.z = transform.position.z;
        for (int i = 0; i < numberOfPlataforms; i++)
        {
            float posPrefbs = Random.Range(0, plataformPrefabs.Count);
            int indexPlatform = (int)System.Math.Round(posPrefbs);
            spawnPosition.y = Random.Range(2, 4);
            spawnPosition.x += Random.Range(0, plataformPrefabs[indexPlatform].GetComponent<SpriteRenderer>().bounds.size.x) + min_plataformPrefab.GetComponent<SpriteRenderer>().bounds.size.x + 1f;
            Instantiate(plataformPrefabs[indexPlatform], spawnPosition, Quaternion.identity);

            //Instantiation of food
            spawnPositionFood = spawnPosition;
            spawnPositionFood.y += 4f;
            spawnPositionFood.x += 6f;
            Instantiate(food, spawnPositionFood, Quaternion.identity);
            spawnPositionFood.x += 1f;
            spawnPositionFood.y += 1f;
            Instantiate(food, spawnPositionFood, Quaternion.identity);
            spawnPositionFood.x += 1f;
            spawnPositionFood.y -= 1f;
            Instantiate(food, spawnPositionFood, Quaternion.identity);
        }
        spawnPosition.x += Random.Range(0, plataformPrefabs[plataformPrefabs.Count - 1].GetComponent<SpriteRenderer>().bounds.size.x) + min_plataformPrefab.GetComponent<SpriteRenderer>().bounds.size.x + 1f;
        Instantiate(last_plataformPrefab, spawnPosition, Quaternion.identity);

    }


}

