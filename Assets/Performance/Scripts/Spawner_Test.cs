using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTest : MonoBehaviour
{
    public enum Mode
    {
        Instantiate,
        Pool
    }

    [Header("Setup")]
    public GameObject prefab;
    public int poolSize = 1000;
    public float spawnRate = 0.01f;
    public float objectLifetime = 3f;

    [Header("Pooling Settings")]
    public Mode mode = Mode.Pool;
    public bool prewarm = true;

    private List<GameObject> pool = new List<GameObject>();
    private float timer;

    void Start()
    {
        if (mode == Mode.Pool && prewarm)
        {
            PrewarmPool();
        }
    }

    void Update()
    {
        // Spawn loop
        timer += Time.deltaTime;
        while (timer >= spawnRate)
        {
            Spawn();
            timer -= spawnRate;
        }

        // Zmiana trybu (1 / 2)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mode = Mode.Instantiate;
            Debug.Log("Mode: Instantiate");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mode = Mode.Pool;
            Debug.Log("Mode: Pool");
        }

        // Toggle prewarm (klawisz O)
        if (Input.GetKeyDown(KeyCode.O))
        {
            prewarm = !prewarm;
            Debug.Log("Prewarm: " + prewarm);

            if (mode == Mode.Pool && prewarm && pool.Count == 0)
            {
                PrewarmPool();
            }
        }
    }

    void PrewarmPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    void Spawn()
    {
        GameObject obj;

        if (mode == Mode.Pool)
        {
            obj = GetFromPool();
        }
        else
        {
            obj = Instantiate(prefab);
        }

        obj.transform.position = randomOffset() ;
        obj.transform.rotation = Random.rotation;
        obj.SetActive(true);

        StartCoroutine(DisableAfterTime(obj, objectLifetime));
    }
    Vector3 randomOffset() => new Vector3(
        Random.Range(-0.5f, 0.5f),
        0f,
        Random.Range(-0.5f, 0.5f)
    );
    GameObject GetFromPool()
    {
        // Szukaj wolnego
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        // Jeśli brak i NIE prewarm → dynamiczne rozszerzanie
        if (!prewarm)
        {
            GameObject newObj = Instantiate(prefab);
            newObj.SetActive(false);
            pool.Add(newObj);
            return newObj;
        }

        // Jeśli prewarm → twardy limit
        return null;
    }

    IEnumerator DisableAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);

        if (mode == Mode.Pool)
        {
            obj.SetActive(false);
        }
        else
        {
            Destroy(obj);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 350, 20), "FPS: " + (1f / Time.deltaTime).ToString("F1"));
        GUI.Label(new Rect(10, 30, 350, 20), "Mode: " + mode + " (1=Instantiate, 2=Pool)");
        GUI.Label(new Rect(10, 50, 350, 20), "Prewarm: " + prewarm + " (O to toggle)");
        GUI.Label(new Rect(10, 70, 350, 20), "Pool size: " + pool.Count);
        GUI.Label(new Rect(10, 90, 350, 20), "Active: " + CountActive());
    }

    int CountActive()
    {
        int count = 0;

        foreach (var obj in pool)
        {
            if (obj.activeInHierarchy)
                count++;
        }

        return count;
    }
}