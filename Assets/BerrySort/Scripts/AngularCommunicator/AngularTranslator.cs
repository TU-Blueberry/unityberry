using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AngularTranslator : MonoBehaviour
{

    float elapsed = 0f;

    public GameObject berryProducer;

    //string traitString = "1,0,1,1,0,1,0,0,0,1,1,0,1,0,1,0,1,1,0,1,0,0,0,1,1,0,1,0,1";
    //string classString = "1,0,1,1,0,1,0,0,0,1,1,0,1,0,1,0,1,1,0,1,0,0,0,1,1,0,1,1,0";


    string traitString = "0";
    string classString = "0";

    BerrySpawner producer;
    List<int> traitList;
    List<int> classList;

    void Start()
    {

        this.traitList = this.traitString.Split(',').Select(Int32.Parse).ToList();
        this.classList = this.classString.Split(',').Select(Int32.Parse).ToList();
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setActive(true);
        producer.receiveResult(this.traitList, this.classList);

    }
    void Update()
    {
        /* 
                elapsed += Time.deltaTime;

                        if (elapsed >= 1)
                        {
                            elapsed = elapsed % 1;
                            enableManual();
                            queueBerry("1, 1,IMAGEPATH");
                            acceptImage("A");

                        } */
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
    public void acceptImage(string image)
    {

        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.addImageAndProduce(image);

    }
}
