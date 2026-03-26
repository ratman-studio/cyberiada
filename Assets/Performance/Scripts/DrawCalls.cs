using UnityEngine;

public class DrawCallModes : MonoBehaviour
{
    public int objectCount = 1000;
    public Vector3 areaSize = new Vector3(20, 5, 20);

    public enum Mode
    {
        UniqueMaterial,
        SharedMaterial,
        GPUInstancing
    }

    public Mode mode;

    public Material sharedMaterial;

    void Start()
    {
        // włącz instancing jeśli trzeba
        if (mode == Mode.GPUInstancing && sharedMaterial != null)
        {
            sharedMaterial.enableInstancing = true;
        }
        QualitySettings.shadows = ShadowQuality.Disable;
        for (int i = 0; i < objectCount; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

            obj.transform.position = new Vector3(
                Random.Range(-areaSize.x, areaSize.x),
                Random.Range(-areaSize.y, areaSize.y),
                Random.Range(-areaSize.z, areaSize.z)
            );

            Renderer renderer = obj.GetComponent<Renderer>();

            switch (mode)
            {
                case Mode.UniqueMaterial:
                    renderer.material = new Material(sharedMaterial);
                    break;

                case Mode.SharedMaterial:
                    renderer.sharedMaterial = sharedMaterial;
                    break;

                case Mode.GPUInstancing:
                    renderer.sharedMaterial = sharedMaterial;
                    break;
            }
        }
    }
}