using UnityEngine;

public class BigUpdate : MonoBehaviour
{
    [SerializeField]
    public int Amount = 10000;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int x = 0;
        for (int i = 0; i < Amount; i++)
        {
            x += i;
        }
    }
}
