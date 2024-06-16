using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject bird;
    public GameObject birdstatic;
    public GameObject birdfly;
    public GameObject GetReady;
    private float flytime = 0;

    private void Start()
    {
        StartCoroutine(Ready());
        StartCoroutine(FPS());
    }
    public bool DidStart = false;
    public IEnumerator Ready()
    {
        yield return new WaitForSeconds(2.5f);
        DidStart = true;
        GetReady.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            if (Colid.GameEnded == false && DidStart == true)
                StartCoroutine(MoveUp());

        if (flytime != -1 && DidStart == true)
        {
            flytime += Time.deltaTime;

            Vector3 pos = bird.transform.position;
            Vector3 rot = bird.transform.rotation.eulerAngles;

            if (rot.z >= -15f) rot.z -= (flytime / 75 - 0.004f) * Time.deltaTime * 5000;

            pos.y -= (flytime/75 - 0.004f) * Time.deltaTime * 520;
            bird.transform.position = pos;
            bird.transform.rotation = Quaternion.Euler(rot);
        }
    }

    private IEnumerator MoveUp()
    {
        flytime = -1;
        StartCoroutine(ChangeAnim());

        Vector3 pos = bird.transform.position;
        float newposy = pos.y - 0.01f;

        StartCoroutine(RotateUp());
        while(pos.y - newposy <= 1.2f)
        {
            pos.y += 0.05f;

            bird.transform.position = pos;
            yield return new WaitForSeconds(0.01f);
        }

        flytime = 0;
    }

    public IEnumerator RotateUp()
    {
        Vector3 rot = bird.transform.rotation.eulerAngles;
        float newrot = rot.z - 0.01f;
        while (rot.z - newrot <= 11f)
        {
            rot.z += 0.05f;
            bird.transform.rotation = Quaternion.Euler(rot);
            yield return new WaitForSeconds(0.002f);
        }
    }

    private IEnumerator ChangeAnim()
    {
        birdstatic.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        birdfly.SetActive(true);
        yield return new WaitForSeconds(0.225f);
        birdfly.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        birdstatic.SetActive(false);
    }

    private float count;
    public TMP_Text FPSDisplay;
    private IEnumerator FPS()
    {
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            FPSDisplay.SetText(Decimal.Round((decimal)count, 0) + " fps");
            yield return new WaitForSeconds(0.1f);
        }
    }
}
