using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesFirstPhase; // three easy, one normal
    public GameObject[] enemiesSecondPhase; // one easy, two normal, one hard
    public GameObject[] enemiesThirdPhase; // one normal, two hard

    private const float start = 1.0f;
    private const float interval = 2.0f;

    private float initTime;
    private float firstPhaseDuration = 5.0f;
    private float secondPhaseDuration = 10.0f;

    private const float verticalPos = 3.0f;

    private const float horizontalRange = 15.0f;
    private const float topRange = 20.0f;
    private const float bottomRange = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.time;
        InvokeRepeating("Spawn", start, interval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        float x = Random.Range(-horizontalRange, horizontalRange);
        float z = Random.Range(bottomRange, topRange);
        Vector3 pos = new Vector3(x, verticalPos, z);

        int phase = CalculatePhase();
        if (phase == 1)
        {
            int i = Random.Range(0, enemiesFirstPhase.Length - 1);
            Instantiate(enemiesFirstPhase[i], pos, enemiesFirstPhase[i].transform.rotation);
        }
        else if (phase == 2)
        {
            int i = Random.Range(0, enemiesSecondPhase.Length - 1);
            Instantiate(enemiesSecondPhase[i], pos, enemiesSecondPhase[i].transform.rotation);
        }
        else
        {
            int i = Random.Range(0, enemiesThirdPhase.Length - 1);
            Instantiate(enemiesThirdPhase[i], pos, enemiesThirdPhase[i].transform.rotation);
        }
    }

    int CalculatePhase()
    {
        float currentTime = Time.time;
        float secondPhaseStart = initTime + firstPhaseDuration;
        float thirdPhaseStart = initTime + firstPhaseDuration + secondPhaseDuration;

        if (currentTime < secondPhaseStart)
        {
            return 1;
        }
        else if (currentTime >= secondPhaseStart && currentTime < thirdPhaseStart)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}
