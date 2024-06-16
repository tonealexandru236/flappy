using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject pipes;
    static public int pipecounter = 0;

    public TMP_Text score;
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    private void Update()
    {
        score.SetText("Score: " + pipecounter.ToString());
    }

    // Update is called once per frame
    private IEnumerator SpawnPipe()
    {
        /// y = -12 - -17.25
        float randy = Random.Range(0f, 4.85f);
        float randsizex = Random.Range(0.9f, 1.1f);
        float randsizey = Random.Range(0.975f, 1f);

        GameObject ist = Instantiate(pipes, new Vector3(18f, -11.75f - randy, -0.5f), pipes.transform.rotation);
        Vector3 scale = ist.transform.localScale;
        scale.x = randsizex;
        scale.y = randsizey;
        ist.transform.localScale = scale;

        //StartCoroutine(DestroyPipe(ist1, ist2));

        float randtime = Random.Range(1.5f, 2.2f);
        yield return new WaitForSeconds(randtime);

        if (Colid.GameEnded == false)
            StartCoroutine(SpawnPipe());
    }

    private IEnumerator DestroyPipe(GameObject pipe1, GameObject pipe2)
    {
        yield return new WaitForSeconds(15f);
        pipe1.SetActive(false);
        pipe2.SetActive(false);
    }
}
