using UnityEngine;

public class Falling : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }
}