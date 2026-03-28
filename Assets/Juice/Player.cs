using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;

    public float range = 5f;


    [Header("Juice")]
    public bool use_smooth = false;
    public float smooth_value = 10f;
    public float tiltAmount = 15f;

    private float targetX;

    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        // target position
        targetX += input * speed * Time.deltaTime;

        // clamp (żeby nie wyjechał poza ekran)
        targetX = Mathf.Clamp(targetX, -range, range);

        // smooth movement
        Vector3 pos = transform.position;
        if (use_smooth)
            pos.x = Mathf.Lerp(pos.x, targetX, Time.deltaTime * smooth_value);
        else
            pos.x = targetX;
        transform.position = pos;

        // tilt (juice 🔥)
        float tilt = -input * tiltAmount;
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, tilt),
            Time.deltaTime * 10f
        );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Collect"))
        {
            GameEvents.Instance.Collect(col.transform.position);
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Obstacle"))
        {
            GameEvents.Instance.Hit(transform.position);
            Destroy(col.gameObject);
            // tutaj możesz dodać Game Over
        }
    }
    
}