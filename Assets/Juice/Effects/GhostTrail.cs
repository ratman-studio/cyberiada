using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float spawnRate = 0.05f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnGhost();
            timer = 0f;
        }
    }

    void SpawnGhost()
    {
        GameObject g = Instantiate(ghostPrefab, transform.position, transform.rotation);

        Destroy(g, 0.5f);
    }
}