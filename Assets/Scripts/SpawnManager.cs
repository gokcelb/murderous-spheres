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

    private const float overlapCheckRadius = 2.5f;
    private const int maxSpawnAttempts = 10;
    private const int maxFailedSpawnAttempts = 10;
    private int failedSpawnAttempts = 0;

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
        var posInfo = GetSpawnPositionInfo();
        Vector3 pos = posInfo.Item1;
        bool valid = posInfo.Item2;

        if (valid)
        {
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
        else
        {
            failedSpawnAttempts++;
        }

        if (failedSpawnAttempts == maxFailedSpawnAttempts)
        {
            CancelInvoke("Spawn");
        }
    }

    (Vector3, bool) GetSpawnPositionInfo()
    {
        Vector3 pos = Vector3.zero;
        int spawnAttempts = 0;
        bool valid = false;

        while (!valid && spawnAttempts < maxSpawnAttempts)
        {
            float x = Random.Range(-horizontalRange, horizontalRange);
            float z = Random.Range(bottomRange, topRange);
            pos = new Vector3(x, verticalPos, z);
            spawnAttempts++;

            Collider[] hitColliders = Physics.OverlapSphere(pos, overlapCheckRadius);

            if (hitColliders.Length == 0)
            {
                valid = true;
            }
        }

        return (pos, valid);
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
