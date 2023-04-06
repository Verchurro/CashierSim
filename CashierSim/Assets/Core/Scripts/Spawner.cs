using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //call exitstore function when randomMax = 10 here. donc if randomMax is reached, exitstore = true

    public GameObject[] itemsToSpawn;
    public float respawnTime = 10f;
    private Vector2 screenbounds;
    public bool isRandomized;
    [SerializeField] public float minSpawnTime = 1;
    public int numberObj = 0;

    private void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(itemWave());
    }
    public void spawnItems()
    {
        int randomIndex = Random.Range(0, itemsToSpawn.Length);
      
        if(respawnTime > minSpawnTime)
        {
            respawnTime--;
        }

        if (numberObj < 15)
        {
            Instantiate(itemsToSpawn[randomIndex]);
            Vector3 spawnPosition = new Vector3(screenbounds.x * 0, 5, 0);
            numberObj++;
        }

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

    private void Update()
    {
        
    }

}