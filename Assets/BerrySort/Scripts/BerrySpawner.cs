using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO;


public class BerrySpawner : MonoBehaviour

{
    float elapsed = 0f;

    public bool active = true;

    //Decides if Berries are produced by Hand
    public bool manual = false;

    public float spawnRate = 0.5f;
    public Transform spawner;
    public Transform goodBerry;
    public Transform badBerry;

    public int berryLifetime;

    public int current = 0;
    // Will be passed later.
    public List<int> berryClassList;

    public List<int> berryTraitList;


    public List<Transform> berryProductionQueue;
    public List<Transform> berryQueue;

    public List<string> imageQueue;

    public Vector3 position;


    void Start()
    {
        this.position = spawner.transform.position;

    }

    public void setActive(bool active)
    {
        this.active = active;
    }

    public void setManual(bool manual)
    {
        this.manual = manual;
    }

    void Update()
    {

        elapsed += Time.deltaTime;

        if (elapsed >= spawnRate)
        {
            if (current < this.berryClassList.Count && current < this.berryTraitList.Count)
            {
                int trait = this.berryTraitList[current];
                int classification = this.berryClassList[current];

                elapsed = elapsed % spawnRate;

                if (!this.manual)
                {
                    SpawnGenerated(trait, classification);
                }
                else
                {
                    if (berryProductionQueue.Count > 0) { this.spawnCustom(); }
                }

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





    // TODO: Refactor this
    void SpawnGenerated(int trait, int classification)
    {

        if (trait == 1)
        {
            Transform berry = Instantiate(goodBerry, position, Quaternion.identity);
            Berry berryScript = (Berry)berry.GetComponent<Berry>();
            berry.rotation = Random.rotation;
            berryScript.classification = classification;
            Destroy(berry.gameObject, this.berryLifetime);

        }
        else
        {
            Transform berry = Instantiate(badBerry, position, Quaternion.identity);
            Berry berryScript = (Berry)berry.GetComponent<Berry>();
            berryScript.classification = classification;
            Destroy(berry.gameObject, this.berryLifetime);

        }

    }



    /*     public void queueBerry(Berry berry)
        {
            this.berryQueue.Add(berry);
        } */


    public void queueBerry(int trait, int classification, string imagePath)
    {

        Transform berry;
        Vector3 temp = new Vector3(0, 1, 0);
        if (trait.Equals(0))
        { berry = Instantiate(badBerry, temp, Quaternion.identity); }
        else
        {
            berry = Instantiate(goodBerry, temp, Quaternion.identity);
        }

        Berry berryInstance = (Berry)berry.GetComponent<Berry>();
        berry.position = temp;
        berry.rotation = Random.rotation;
        berryInstance.classification = trait;
        berryInstance.trait = classification;
        berryInstance.imagePath = imagePath;
        this.berryQueue.Add(berry);
    }

    public void addImageAndProduce(string img)
    {
        if (berryQueue.Count > 0)
        {
            var nextBerry = this.berryQueue[0];
            this.berryQueue.RemoveAt(0);
            // Do something with the Image String Blob coming in here;
            Berry berryScript = (Berry)nextBerry.GetComponent<Berry>();
            berryScript.image = img;
            this.berryProductionQueue.Add(nextBerry);

        }

    }


    public void spawnCustom()
    {
        if (this.berryProductionQueue.Count > 0)
        {
            var nextBerry = this.berryProductionQueue[0];
            this.berryProductionQueue.RemoveAt(0);
            nextBerry.position = position;
            nextBerry.rotation = Random.rotation;
            Destroy(nextBerry.gameObject, this.berryLifetime);


        }

    }
}
