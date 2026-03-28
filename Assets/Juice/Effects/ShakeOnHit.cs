using UnityEngine;
using DG.Tweening;

public class ShakeOnHit : MonoBehaviour
{
    public float duration = 0.2f;
    public float strength = 0.2f;

    void OnEnable() => GameEvents.Instance.OnHit += Shake;
    void OnDisable() => GameEvents.Instance.OnHit -= Shake;

    void Shake(Vector3 pos) => transform.DOShakePosition(duration, strength, 10, 90f, false, true);
}