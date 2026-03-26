using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;      // punkt wokół którego orbitujemy
    public float distance = 20f;  // odległość od środka
    public float speed = 20f;     // prędkość obracania (stopnie/s)

    private float angle = 0f;

    void Update()
    {
        if (target == null) return;

        // aktualizujemy kąt w czasie
        angle += speed * Time.deltaTime;

        // przeliczamy pozycję kamery
        float rad = angle * Mathf.Deg2Rad;
        float x = target.position.x + Mathf.Cos(rad) * distance;
        float z = target.position.z + Mathf.Sin(rad) * distance;
        float y = target.position.y + distance * 0.01f; // lekko nad sceną

        transform.position = new Vector3(x, y, z);
        transform.LookAt(target);
    }
}