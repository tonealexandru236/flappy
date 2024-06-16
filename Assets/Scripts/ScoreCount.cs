using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ScoreCount : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(SpawnPipes.pipecounter);
        if (collision.gameObject.tag == "Player")
            SpawnPipes.pipecounter++;
    }
}
