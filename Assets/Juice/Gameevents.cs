using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    void Awake()
    {
        Instance = this;
    }

    // EVENTY
    public event Action<Vector3> OnCollect;
    public event Action<Vector3> OnHit;

    // WYWOŁANIA
    public void Collect(Vector3 pos)
    {
        OnCollect?.Invoke(pos);
    }

    public void Hit(Vector3 pos)
    {
        OnHit?.Invoke(pos);
    }
}