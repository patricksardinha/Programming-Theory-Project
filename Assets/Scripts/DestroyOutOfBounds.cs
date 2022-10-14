using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float zDestroyBound = -300;
    private float zFastDestroy = -60;

    void Update()
    {
        if (gameObject.CompareTag("FastDestroy") && transform.position.z < zFastDestroy)
        {
            // Destroy the gameObject
            Destroy(gameObject);
        }

        else if (transform.position.z < zDestroyBound)
        {
            // Deactivate the gameObject
            gameObject.SetActive(false);

        }
    }
}
