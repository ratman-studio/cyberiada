using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameEvents>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameEvents");
                    _instance = go.AddComponent<GameEvents>();
                }
            }
            return _instance;
        }
    }
    private static GameEvents _instance;

   
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