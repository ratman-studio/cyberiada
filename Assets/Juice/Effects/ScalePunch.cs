using System;
using UnityEngine;

public class ScalePunch : MonoBehaviour
{
    void OnEnable() => GameEvents.Instance.OnCollect += Punch;
    void OnDisable() => GameEvents.Instance.OnCollect -= Punch;

    private Vector3 init_scale;

    private void Awake()
         {
             init_scale = transform.localScale;
         }

    void Punch(Vector3 pos)
    {
        transform.localScale = init_scale * 1.2f;
        Invoke(nameof(ResetScale), 0.1f);
    }

    void ResetScale() => transform.localScale = init_scale;
}