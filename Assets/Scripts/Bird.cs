using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject bird;
    private float flytime = 0;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            StartCoroutine(MoveUp());

        if (flytime != -1)
        {
            flytime += Time.deltaTime;

            Vector3 pos = bird.transform.position;
            pos.y -= (flytime/75 - 0.003f);
            bird.transform.position = pos;
        }
    }

    private IEnumerator MoveUp()
    {
        flytime = -1;

        Vector3 pos = bird.transform.position;
        float newposy = pos.y - 0.01f;

        while(pos.y - newposy <= 1.2f)
        {
            pos.y += 0.05f;
            bird.transform.position = pos;
            yield return new WaitForSeconds(0.01f);
        }

        flytime = 0;
    }
}
