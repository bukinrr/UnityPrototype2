using System;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
        else
        {
            
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    
}
