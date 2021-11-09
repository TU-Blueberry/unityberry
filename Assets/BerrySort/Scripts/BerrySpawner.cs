using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO;


public class BerrySpawner : MonoBehaviour

{
    float elapsed = 0f;
    public Transform spawner;
    public Transform goodBerry;
    public Transform badBerry;

    public int current = 0;
    // Will be passed later.
    public List<int> berryClassList;

    public List<int> berryTraitList;


    public Vector3 position;
    void Start()
    {
        this.position = spawner.transform.position;

    }

    void Update()
    {

        elapsed += Time.deltaTime;

        if (elapsed >= 1f)
        {
            if (current < this.berryClassList.Count && current < this.berryTraitList.Count)
            {

                // Debug.Log(berries[current]);
                int trait = this.berryTraitList[current];
                int classification = this.berryClassList[current];

                elapsed = elapsed % 1f;
                SpawnObject(trait, classification);

                this.current++;
            }
            else { this.current = 0; }

        }
    }

    public void receiveResult(List<int> traits, List<int> classification)
    {
        this.current = 0;
        this.berryTraitList = traits;
        this.berryClassList = classification;

    }
    void OutputTime()
    {
        Debug.Log(Time.time);
    }





    void SpawnObject(int trait, int classification)
    {
        if (trait == 1)
        {
            Transform berry = Instantiate(goodBerry, position, Quaternion.identity);
            BerryGood berryScript = (BerryGood)berry.GetComponent<BerryGood>();
            berryScript.classification = classification;
        }
        else
        {
            Transform berry = Instantiate(badBerry, position, Quaternion.identity);
            BerryBad berryScript = (BerryBad)berry.GetComponent<BerryBad>();
            berryScript.classification = classification;

        }

    }
}
