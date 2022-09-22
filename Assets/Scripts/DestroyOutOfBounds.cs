﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float zDestroyBound = -50;

    void Update()
    {
        if (transform.position.z < zDestroyBound)
        {
            // Deactivate the gameObject
            gameObject.SetActive(false);

        }
    }
}
