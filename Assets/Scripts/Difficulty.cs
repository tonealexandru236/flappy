using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    float time = 0;
    void Update()
    {
        if (Colid.GameEnded == false)
        {
            time += Time.deltaTime;
            if (Time.timeScale > 99f) Time.timeScale = 99f;
            else Time.timeScale = 1 + time / 100f;
        }
    }
}
