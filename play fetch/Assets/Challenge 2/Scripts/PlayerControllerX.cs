using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float lastSend = 2.0f;
    public float spamDelay = 2.0f;

    // Update is called once per frame
    void Update()
    {
        lastSend += Time.deltaTime;
        Debug.Log(lastSend);

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && lastSend >= spamDelay)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastSend = 0;

        }
}   }
