using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipes : MonoBehaviour
{
    public GameObject player;
    public float speed = 3f;
    void Update()
    {
        if (Colid.GameEnded == false)
        {
            Vector3 pos = transform.position;
            pos.x -= Time.deltaTime * speed;
            transform.position = pos;

            if (pos.x >= -22f && pos.x <= -20f) Destroy(gameObject);
        }
    }
}
