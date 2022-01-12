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
    public List<Transform> goodBerry;
    public List<Transform> badBerry;

    public int berryLifetime;

    public int current = 0;
    // Will be passed later.

    public List<BerryData> berryQueue = new List<BerryData>();

    public Vector3 position;

    void Start()
    {
        this.position = spawner.transform.position;

    }

    void Update()
    {

        elapsed += Time.deltaTime;

        if (elapsed >= spawnRate)
        {

            this.produceBerry();

        }
        elapsed = elapsed % spawnRate;

    }
    public void queueBerry(int trait, int classification, string imagePath)
    {

        this.berryQueue.Add(new BerryData(trait, classification, imagePath, null));
    }

    public void queueBerry(int trait, int classification, string imagePath, string image)
    {

        this.berryQueue.Add(new BerryData(trait, classification, imagePath, image));
    }

    public void produceBerry()
    {


        if (berryAvailable())
        {
            BerryData berry = berryQueue[0];
            Vector3 spawnerPosition = spawner.position;
            Transform berryGameObject;

            if (berry.trait.Equals(0))
            { berryGameObject = Instantiate(badBerry[Random.Range(0, badBerry.Count)], spawnerPosition, Quaternion.identity); }
            else
            {
                berryGameObject = Instantiate(goodBerry[Random.Range(0, badBerry.Count)], spawnerPosition, Quaternion.identity);
            }

            Berry berryInstance = (Berry)berryGameObject.GetComponent<Berry>();
            berryGameObject.position = spawnerPosition;
            berryGameObject.rotation = Random.rotation;
            berryInstance.classification = berry.classification;
            berryInstance.trait = berry.trait;
            berryInstance.imagePath = berry.imagePath;
            berryInstance.image = berry.image;
            Destroy(berryInstance.gameObject, this.berryLifetime);
            this.berryQueue.RemoveAt(0);
            this.current++;
        }

    }

    public bool berryAvailable()
    {

        if (berryQueue.Count > 0)
        {

            if (this.berryQueue[0].image != null)
            {
                return true;
            }
        }
        return false;
    }

    public void acceptImage(string imagepath, string image)
    {
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
    }


    public void setActive(bool active)
    {
        this.active = active;
    }

    public void setManual(bool manual)
    {
        this.manual = manual;
    }

}
