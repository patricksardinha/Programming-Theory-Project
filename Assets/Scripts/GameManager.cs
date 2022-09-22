using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float environmentSpeed;

    void Update()
    {
        // Continously increase environment speed for difficulty
        //environmentSpeed += 0.01f * Time.deltaTime;
    }
}
