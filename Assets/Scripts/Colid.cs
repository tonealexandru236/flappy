using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colid : MonoBehaviour
{
    static public bool GameEnded = false; 
    public GameObject gameover;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameover.SetActive(true);
            GameEnded = true;
        }
    }
}
