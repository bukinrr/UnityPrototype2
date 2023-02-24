using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float sec = 10;
    public GameObject dogPrefab;

    // Update is called once per frame
    void Update()
    {
        sec += Time.deltaTime;
        Debug.Log($"{sec}");
        if (sec >= 1)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                Debug.Log("Создание");
                sec = 0;
            }
        }
    }
}