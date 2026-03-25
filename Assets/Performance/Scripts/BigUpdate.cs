using UnityEngine;

public class BigUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for ( var i = 0; i < 10000; i++)
        {
            Debug.Log("");
        }
    }
}
