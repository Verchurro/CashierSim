using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenbounds;

    private void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void spawnItems()
    {
        GameObject a = Instantiate(itemPrefab) as GameObject;
    }
}
