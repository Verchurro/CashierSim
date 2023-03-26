using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //call exitstore function when randomMax = 10 here. donc if randomMax is reached, exitstore = true

    public GameObject[] itemsToSpawn;
    public float respawnTime = 1.0f;
    private Vector2 screenbounds;
    public bool isRandomized;
    [SerializeField] int randomMin = 5, randomMax = 10;

    private void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(itemWave());
    }
    private void spawnItems()
    {
        int randomIndex = Random.Range(randomMin, randomMax);

        Instantiate(itemsToSpawn[randomIndex]);
        Vector3 spawnPosition = new Vector3(screenbounds.x * 0, 5, 0);
    }

    IEnumerator itemWave()
    {
        while (true)
        {
            //interval between diff items
            yield return new WaitForSeconds(respawnTime);
            spawnItems();
        }

    }
}