using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Berries;
using DTO;


public class BerrySpawner : MonoBehaviour

{
    float elapsed = 0f;

    public bool active = true;

    //Decides if Berries are produced by Hand
    public bool manual = true;

    public float spawnRate = 0.5f;
    public Transform spawner;

    public Transform queuespot;
    public Transform goodBerry;
    public Transform badBerry;

    public int berryLifetime;

    public int current = 0;
    // Will be passed later.
    public List<int> berryClassList = new List<int>();

    public List<int> berryTraitList = new List<int>();

    public List<BerryData> berryQueue = new List<BerryData>();

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

            if (berryQueue.Count > 0)
            {

                if (this.berryQueue[0].image != null)
                {
                    this.produceBerry(berryQueue[0]);

                    this.berryQueue.RemoveAt(0);
                    this.current++;
                }
            }

        }
        elapsed = elapsed % spawnRate;

    }
    public void receiveResult(List<int> traits, List<int> classification)
    {
        this.current = 0;
        this.berryTraitList = traits;
        this.berryClassList = classification;

    }

    public void queueBerry(int trait, int classification, string imagePath)
    {

        this.berryQueue.Add(new BerryData(trait, classification, imagePath, null));
    }

    public void produceBerry(BerryData berry)
    {

        Vector3 spawnerPosition = spawner.position;
        Transform berryGameObject;

        if (berry.trait.Equals(0))
        { berryGameObject = Instantiate(badBerry, spawnerPosition, Quaternion.identity); }
        else
        {
            berryGameObject = Instantiate(goodBerry, spawnerPosition, Quaternion.identity);
        }

        Berry berryInstance = (Berry)berryGameObject.GetComponent<Berry>();
        berryGameObject.position = spawnerPosition;
        berryGameObject.rotation = Random.rotation;
        berryInstance.classification = berry.classification;
        berryInstance.trait = berry.trait;
        berryInstance.imagePath = berry.imagePath;
        berryInstance.image = berry.image;
        Destroy(berryInstance.gameObject, this.berryLifetime);

    }

    public void acceptImage(string imagepath, string image)
    {
        /*         foreach (BerryData berry in this.berryQueue)
                {
                    if (berry.imagePath == imagepath)
                    {
                        berry.image = image;
                        break;
                    }
                } */

        foreach (BerryData berry in this.berryQueue)
        {
            if (berry.image == null || berry.image == "" || berry.image == "0")
            {
                berry.image = image;
                break;
            }
        }

    }

    public void reset()
    {

        this.berryQueue.Clear();
        this.berryClassList.Clear();
        this.berryClassList.Clear();


    }

}
