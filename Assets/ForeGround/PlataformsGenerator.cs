using System.Collections.Generic;
using UnityEngine;

public class PlataformsGenerator : MonoBehaviour
{
    public List<GameObject> plataformPrefabs;
    public GameObject min_plataformPrefab;
    public GameObject last_plataformPrefab;
    public GameObject food;
    public GameObject vasija;
    public GameObject aguacatillo;
    private float previousPlataformX;
    //private float height = 1f;
    public float width;
    public int numberOfPlataforms = 100;
    private bool oneTimeCheck1;
    private bool oneTimeCheck2;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x += 10;
        Vector3 spawnPositionFood = new Vector3();
        int ochenta20 = (int)(numberOfPlataforms * 0.8);
        for (int i = 0; i < numberOfPlataforms; i++)
        {
            float posPrefbs = Random.Range(0, plataformPrefabs.Count - 2);
            if (ochenta20 <= i)
            {
                posPrefbs = Random.Range(2, plataformPrefabs.Count);
            }

            if (428f < spawnPosition.x && 448f > spawnPosition.x && !oneTimeCheck1)
            {
                spawnPosition.x = 460f;
                oneTimeCheck1 = true;
            }

            if (868f < spawnPosition.x && 892f > spawnPosition.x && !oneTimeCheck2)
            {
                spawnPosition.x = 892f;
                oneTimeCheck2 = true;
}



            int indexPlatform = (int)System.Math.Round(posPrefbs);
            spawnPosition.y = Random.Range(-9f, -3f);
            spawnPosition.x += Random.Range(0, plataformPrefabs[indexPlatform].GetComponent<SpriteRenderer>().bounds.size.x / 2) + previousPlataformX + 1f;
            previousPlataformX = plataformPrefabs[indexPlatform].GetComponent<SpriteRenderer>().bounds.size.x;
            Instantiate(plataformPrefabs[indexPlatform], spawnPosition, Quaternion.identity);

            //Instantiation of food
            if (indexPlatform != 3 && indexPlatform != 2)
            {
                spawnPositionFood = spawnPosition;
                spawnPositionFood.y += plataformPrefabs[indexPlatform].GetComponent<SpriteRenderer>().bounds.size.y - 2f;
                spawnPositionFood.x += 6f;
                Instantiate(food, spawnPositionFood, Quaternion.identity);
                spawnPositionFood.x += Random.Range(1, 4);
                spawnPositionFood.y += Random.Range(1, 3);
                Instantiate(food, spawnPositionFood, Quaternion.identity);
            }

            if (i % 5 == 0 && indexPlatform != 3 && indexPlatform != 2)
            {
                spawnPosition.y += 0.1f;
                Instantiate(vasija, spawnPosition, Quaternion.identity);
            }

            if (i % 7 == 0 && indexPlatform != 3 && indexPlatform != 2)
            {
                //spawnPosition.y += 4.5f;
                //Instantiate(aguacatillo, spawnPosition, Quaternion.identity);
            }

            if(indexPlatform == 3 || indexPlatform == 2)
            {
                spawnPositionFood = spawnPosition;
                spawnPositionFood.y += plataformPrefabs[indexPlatform].GetComponent<SpriteRenderer>().bounds.size.y - 4f;
                spawnPositionFood.x += 2f;
                Instantiate(food, spawnPositionFood, Quaternion.identity);
                spawnPositionFood.x += 2f;
                Instantiate(food, spawnPositionFood, Quaternion.identity);
            }
        }
        spawnPosition.x += plataformPrefabs[plataformPrefabs.Count - 1].GetComponent<SpriteRenderer>().bounds.size.x + last_plataformPrefab.GetComponent<SpriteRenderer>().bounds.size.x + 1f;
        spawnPositionFood.y -= 6f;
        Instantiate(last_plataformPrefab, spawnPosition, Quaternion.Euler(0f,0f,20f));

    }


}

