using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Z destroy for environment objects
    private float zDestroyBound = -300;

    // Z destroy for prefabs which define schemas to ensure no duplication of schemas
    private float zFastDestroy = -60;

    void Update()
    {
        // Check tags FastDestroy
        if (gameObject.CompareTag("FastDestroy") && transform.position.z < zFastDestroy)
        {
            // In this case, destroy the gameObject
            Destroy(gameObject);
        }

        else if (transform.position.z < zDestroyBound)
        {
            // else, only deactivate the gameObject because this use the object pooler script
            gameObject.SetActive(false);

        }
    }
}
