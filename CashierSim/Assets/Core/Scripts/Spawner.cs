using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemsToSpawn;
    public float respawnTime = 1.0f;
    private Vector2 screenbounds;
    public bool isRandomized;

    private void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(itemWave());
    }
    private void spawnItems()
    {
      

        GameObject a = Instantiate(itemsToSpawn) as GameObject;
        a.transform.position = new Vector3(screenbounds.x * 0, 5, 0);
    }

    IEnumerator itemWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnItems();
        }

    }
}
