using UnityEngine;
using System.Collections.Generic;

public class PhysicsBenchmark : MonoBehaviour
{
    public int objectCount = 1000;
    public bool useRigidbody = false;
    public bool kinematic = true;
    public float moveSpeed = 5f;
    public Vector3 areaSize = new Vector3(50, 50, 50);

    private List<GameObject> objects = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < objectCount; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

            obj.transform.position = new Vector3(
                Random.Range(-areaSize.x, areaSize.x),
                Random.Range(-areaSize.y, areaSize.y),
                Random.Range(-areaSize.z, areaSize.z)
            );

            if (useRigidbody)
            {
                Rigidbody rb = obj.AddComponent<Rigidbody>();
                rb.isKinematic = kinematic;
            }

            objects.Add(obj);
        }
    }

    void Update()
    {
        float time = Time.time;

        for (int i = 0; i < objects.Count; i++)
        {
            GameObject obj = objects[i];

            Vector3 offset = new Vector3(
                Mathf.Sin(time + i),
                Mathf.Cos(time + i * 0.5f),
                Mathf.Sin(time * 0.7f + i)
            );

            obj.transform.position += offset * moveSpeed * Time.deltaTime;
        }
    }
}