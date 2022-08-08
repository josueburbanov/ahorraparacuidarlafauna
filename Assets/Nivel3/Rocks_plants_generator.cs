using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks_plants_generator : MonoBehaviour
{
    public List<GameObject> plataformPrefabs;
    public GameObject min_plataformPrefab;
    public GameObject last_plataformPrefab;
    public GameObject food;
    private float height = 2f;
    public float width;
    public int numberOfPlataforms = 100;
    private static bool needRock = false;
    public GameObject vasija;
    public GameObject aguacatillo;
    private bool oneTimeCheck1;
    private bool oneTimeCheck2;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        Vector3 spawnPositionFood = new Vector3();
        for (int i = 0; i < numberOfPlataforms; i++)
        {
            //checkpointstuff
            if (790f < spawnPosition.x && 828f > spawnPosition.x && !oneTimeCheck1)
            {
                spawnPosition.x = 828f;
                oneTimeCheck1 = true;
            }

            if (280f < spawnPosition.x && 306f > spawnPosition.x && !oneTimeCheck1)
            {
                spawnPosition.x = 308f;
                oneTimeCheck1 = true;
            }
            //

            int indexPlatform = Random.Range(0, plataformPrefabs.Count);
            spawnPosition.y = -1f;
            spawnPosition.x += 10f;
            if (needRock)
            {
                indexPlatform = Random.Range(2, plataformPrefabs.Count);
                needRock = false;
            }

            Instantiate(plataformPrefabs[indexPlatform], spawnPosition, Quaternion.identity);
            if(indexPlatform == 0 || indexPlatform == 1)
            {
                needRock = true;
            }
            spawnPositionFood = spawnPosition;
            spawnPositionFood.x += Random.Range(1,3);
            spawnPositionFood.y += Random.Range(1, 3);
            Instantiate(food, spawnPositionFood, Quaternion.identity);
            spawnPositionFood.x += Random.Range(1, 3);
            spawnPositionFood.y += Random.Range(1, 4);
            Instantiate(food, spawnPositionFood, Quaternion.identity);

            if (i % 5 == 0  && indexPlatform != 0 && indexPlatform != 1)
            {
                spawnPosition.y += 0.2f;
                Instantiate(vasija, spawnPosition, Quaternion.identity);
            }

            if (i % 7 == 0)
            {
                spawnPosition.y += 1.5f;
                Instantiate(aguacatillo, spawnPosition, Quaternion.identity);
            }

        }
        spawnPosition.x += 26f;
        Instantiate(last_plataformPrefab, spawnPosition, Quaternion.identity);

    }
}
