using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO;


public class SpawnBerries : MonoBehaviour

{
    float elapsed = 0f;
    public Transform spawner;
    public Transform goodBerry;
    public Transform badBerry;

    public int current = 0;
    // Will be passed later.
    public ArrayList berries;

    public ArrayList berriesClassification;

    public string berryJson;

    public Vector3 position;
    void Start()
    {
        this.position = spawner.transform.position;
        this.receiveResult("This Could be Your Result");
        this.berries = new ArrayList() { 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1 };
        //Debug.Log(this.berries[0]);

    }

    void Update()
    {
        berries = new ArrayList() { 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1 };
        elapsed += Time.deltaTime;

        if (elapsed >= 1f)
        {

            // Debug.Log(berries[current]);
            int berry = (int)berries[current];

            elapsed = elapsed % 1f;
            SpawnObject(berry);
            //Debug.Log(current);
            //OutputTime();
            current++;
            if (current > 8)
            {
                current = 0;
            }
        }
    }
    void OutputTime()
    {
        Debug.Log(Time.time);
    }


    void receiveResult(string jsonString)
    {
        string berries = "[1,0,1,1,0,1,0,0,0,1,1,0,1,1,1]";
        string classification = "[1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1]";
        // this.berriesClassification = JsonUtility.FromJson<ArrayList>(classification);
        // this.berries = JsonUtility.FromJson<BerryResultDTO>(berries).berries;

    }


    void SpawnObject(int type)
    {
        if (type == 1)
        {
            Instantiate(goodBerry, position, Quaternion.identity);
        }
        else
        {
            Instantiate(badBerry, position, Quaternion.identity);
        }

    }
}
