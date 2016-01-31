using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CatchDropController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int timer;
    public Text textbox;

    void Start()
    {
        StartCoroutine("SpawnWaves");
        timer = 30;
    }

    void Update()
    {

        if (timer == 0)
        {
            StopCoroutine("SpawnWaves");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PLayerController>().SetMoving(false);
        }
        else
        {
            timer = 30 - (int)Time.time;
            textbox.text = "Time: " + timer;
        }
       
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}