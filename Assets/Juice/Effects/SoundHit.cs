using UnityEngine;

public class SoundHit : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    [Header("Pitch Settings")]
    public float basePitch = 1f;
    public float randomOffset = 0.1f; 
    
    void OnEnable() => GameEvents.Instance.OnHit += PlaySound;
    void OnDisable() => GameEvents.Instance.OnHit -= PlaySound;

    void PlaySound(Vector3 pos)
    {
        float orginalPitch = source.pitch;
        float offset = Random.Range(-randomOffset, randomOffset);
        source.pitch = orginalPitch + offset;
        source.PlayOneShot(clip);
       // source.pitch = orginalPitch;
    }
}