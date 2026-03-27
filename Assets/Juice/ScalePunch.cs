using UnityEngine;

public class ScalePunch : MonoBehaviour
{
    void OnEnable() => GameEvents.Instance.OnCollect += Punch;
    void OnDisable() => GameEvents.Instance.OnCollect -= Punch;

    void Punch(Vector3 pos)
    {
        transform.localScale = Vector3.one * 1.5f;
        Invoke(nameof(ResetScale), 0.5f);
    }

    void ResetScale() => transform.localScale = Vector3.one;
}