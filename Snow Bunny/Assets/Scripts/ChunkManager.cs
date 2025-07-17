using UnityEngine;
using System.Collections.Generic;

public class EndlessRoadManager : MonoBehaviour
{
    public Transform player;
    public GameObject[] chunkPrefabs;
    public int initialChunks = 3;

    private List<GameObject> activeChunks = new List<GameObject>();
    private Transform lastExit;

    void Start()
    {
        for (int i = 0; i < initialChunks; i++)
        {
            SpawnChunk();
        }
    }

    void Update()
    {
        // Remove chunks behind the player
        if (activeChunks.Count > 0 && player.position.z - activeChunks[0].transform.position.z > 30f)
        {
            Destroy(activeChunks[0]);
            activeChunks.RemoveAt(0);
        }
    }

    void SpawnChunk()
    {
        GameObject prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
        Vector3 spawnPos = lastExit != null ? lastExit.position : Vector3.zero;
        Quaternion spawnRot = lastExit != null ? lastExit.rotation : Quaternion.identity;

        GameObject newChunk = Instantiate(prefab, spawnPos, spawnRot);
        activeChunks.Add(newChunk);

        // Find the ExitPoint of the new chunk
        lastExit = newChunk.transform.Find("ExitPoint");
    }
}
