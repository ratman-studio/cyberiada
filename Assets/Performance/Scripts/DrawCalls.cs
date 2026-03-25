using UnityEngine;

public class DrawCallBenchmark : MonoBehaviour
{
    public int objectCount = 2000;
    public Vector3 areaSize = new Vector3(100, 10, 100);

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

            
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Standard"));

            
            obj.isStatic = false;
        }
    }
}