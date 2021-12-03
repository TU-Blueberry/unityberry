using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AngularTranslator : MonoBehaviour
{

    float elapsed = 0f;

    public GameObject berryProducer;

    string traitString = "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0";
    string classString = "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1";

    BerrySpawner producer;
    List<int> traitList;
    List<int> classList;

    public string badBerry = "berrybad-";
    public string goodBerry = "berrygood-";
    public string basePath = "berries/";



    void Start()
    {

        this.traitList = this.traitString.Split(',').Select(Int32.Parse).ToList();
        this.classList = this.classString.Split(',').Select(Int32.Parse).ToList();
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setActive(true);
        enableManual();
        string imagePath;

        for (int i = 0; i < traitList.Count(); i++)
        {

            imagePath = traitList.ElementAt(i) == 0 ? this.basePath + this.badBerry : this.basePath + this.goodBerry;
            queueBerry(traitList.ElementAt(i) + "," + classList.ElementAt(i) + "," + imagePath);

        }
        producer.receiveResult(this.traitList, this.classList);

    }
    void Update()
    {

        elapsed += Time.deltaTime;

        if (elapsed >= 1)
        {
            elapsed = elapsed % 1;
            acceptImage("berries/berrybad-", "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAABg2lDQ1BJQ0MgcHJvZmlsZQAAKJF9kT1Iw1AUhU9TpSIVBzuIOGSoThZERRylFYtgobQVWnUweekfNGlIUlwcBdeCgz+LVQcXZ10dXAVB8AfEzc1J0UVKvC8pNIjxweV9nPfO4b77AKFVY6rZMwmommVkknExX1gVQ68II+hUSGKmnsou5uC7vu4R4PtdjGf53/tzDShFkwEBkXie6YZFvEE8u2npnPeJI6wiKcTnxBMGNUj8yHXZ5TfOZYcFnhkxcpkEcYRYLHtY9jCrGCrxDHFUUTXKF/IuK5y3OKu1Buv0yV8YLmorWa5TjSKJJaSQhggZDVRRg4UY7RopJjJ0Hvfxjzj+NLlkclXByLGAOlRIjh/8D37P1ixNT7lJ4TjQ+2LbH2NAaBdoN237+9i22ydA8Bm40rr+eguY+yS92dWiR8DgNnBx3dXkPeByBxh+0iVDcqQglVAqAe9n9E0FYOgW6F9z59Y5x+kDkKNZLd8AB4fAeJmy133e3eed2793OvP7AelhcnCjVS7cAAAACXBIWXMAAC4jAAAuIwF4pT92AAAAB3RJTUUH5QwDDAQDqWcPpAAAABl0RVh0Q29tbWVudABDcmVhdGVkIHdpdGggR0lNUFeBDhcAAAAWSURBVCjPY/zPQBpgYhjVMKph2GoAAEAuAR+xkMJNAAAAAElFTkSuQmCC");
            acceptImage("berries/berrygood-", "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAABg2lDQ1BJQ0MgcHJvZmlsZQAAKJF9kT1Iw1AUhU9TpSIVBzuIOGSoThZERRylFYtgobQVWnUweekfNGlIUlwcBdeCgz+LVQcXZ10dXAVB8AfEzc1J0UVKvC8pNIjxweV9nPfO4b77AKFVY6rZMwmommVkknExX1gVQ68II+hUSGKmnsou5uC7vu4R4PtdjGf53/tzDShFkwEBkXie6YZFvEE8u2npnPeJI6wiKcTnxBMGNUj8yHXZ5TfOZYcFnhkxcpkEcYRYLHtY9jCrGCrxDHFUUTXKF/IuK5y3OKu1Buv0yV8YLmorWa5TjSKJJaSQhggZDVRRg4UY7RopJjJ0Hvfxjzj+NLlkclXByLGAOlRIjh/8D37P1ixNT7lJ4TjQ+2LbH2NAaBdoN237+9i22ydA8Bm40rr+eguY+yS92dWiR8DgNnBx3dXkPeByBxh+0iVDcqQglVAqAe9n9E0FYOgW6F9z59Y5x+kDkKNZLd8AB4fAeJmy133e3eed2793OvP7AelhcnCjVS7cAAAACXBIWXMAAC4jAAAuIwF4pT92AAAAB3RJTUUH5QwDDAQUKrSKYwAAABl0RVh0Q29tbWVudABDcmVhdGVkIHdpdGggR0lNUFeBDhcAAAAYSURBVCjPY2T7z0ASYGJgGNUwqmG4agAAUYkBJXHEPR0AAAAASUVORK5CYII=");

        }
    }

    public void receiveClassification(string result)
    {

        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        Debug.Log("Received Classification: " + result);
        this.classList = result.Split(',').Select(Int32.Parse).ToList();
        producer.receiveResult(this.traitList, this.classList);

    }

    public void receiveTraits(string result)
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        Debug.Log("Received Traits: " + result);
        this.traitList = result.Split(',').Select(Int32.Parse).ToList();
        producer.receiveResult(this.traitList, this.classList);
    }


    public void stop()
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setActive(false);
    }

    public void enableManual()
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setManual(true);
    }

    public void disableManual()
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setManual(false);
    }

    // Berry characteristings separated by comma values "trait,classification,imagepath"
    public void queueBerry(string berry)
    {
        string[] berryParts = berry.Split(',');
        string trait = berryParts[0];
        string classification = berryParts[1];
        string imagePath = berryParts[2];
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        //producer.queueBerry(Int32.Parse(trait), Int32.Parse(classification), imagePath));
        producer.queueBerry(Int32.Parse(trait), Int32.Parse(classification), imagePath);

    }
    public void acceptImage(string imagepath, string image)
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.acceptImage(imagepath, image);

    }

}
