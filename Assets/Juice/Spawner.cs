using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject collectPrefab;

    public float spawnRate = 1f;
    public float xRange = 2.5f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnRate);
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(-xRange, xRange), 5f, 0);

        GameObject prefab = Random.value > 0.3f ? obstaclePrefab : collectPrefab;
        Instantiate(prefab, pos, Quaternion.identity);
    }
}