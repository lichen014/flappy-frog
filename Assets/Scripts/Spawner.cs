using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject powerupPrefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    } 

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        GameObject powerup = Instantiate(prefab, transform.position, Quaternion.identity);
        powerup.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosY = Random.Range(minHeight, maxHeight);

        Vector3 randomPos = new Vector3(30, 0, -30);

        return randomPos;
    }
}
