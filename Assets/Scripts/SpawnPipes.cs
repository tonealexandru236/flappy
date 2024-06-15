using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Player;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject pipes;
    public int pipecounter = 0;

    public TMP_Text score;
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    int actualscore = 0;
    private void Update()
    {
        if(pipecounter - 3 < 0) actualscore = 0;
        else actualscore = pipecounter - 3;
        score.SetText(actualscore.ToString());
    }

    // Update is called once per frame
    private IEnumerator SpawnPipe()
    {
        pipecounter++;
        float randtime = Random.Range(1.5f, 2.2f);
        yield return new WaitForSeconds(randtime);
        /// y = -12 - -17.25
        float randy = Random.Range(0f, 5.25f);
        float randsizex = Random.Range(0.95f, 1.05f);
        float randsizey = Random.Range(0.975f, 1f);

        GameObject ist = Instantiate(pipes, new Vector3(10f, -12 - randy, -1f), pipes.transform.rotation);
        Vector3 scale = ist.transform.localScale;
        scale.x = randsizex;
        scale.y = randsizey;
        ist.transform.localScale = scale;

        //StartCoroutine(DestroyPipe(ist1, ist2));
        StartCoroutine(SpawnPipe());
    }



    private IEnumerator DestroyPipe(GameObject pipe1, GameObject pipe2)
    {
        yield return new WaitForSeconds(15f);
        pipe1.SetActive(false);
        pipe2.SetActive(false);
    }
}
