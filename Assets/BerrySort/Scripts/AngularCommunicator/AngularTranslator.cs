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
    //string classString = "1,0,1,1,0,1,0,0,0,1,1,0,1,1,0,0,1,1,0,1,0,0,0,1,1,0,1,0,1";


    string traitString = "1,0,1,0";
    string classString = "1,1,1,0";


    List<int> traitList;
    List<int> classList;
    void Start()
    {

        this.traitList = this.traitString.Split(',').Select(Int32.Parse).ToList();
        this.classList = this.classString.Split(',').Select(Int32.Parse).ToList();
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.receiveResult(this.traitList, this.classList);

    }

    void Update()
    {

    }

    public void receiveClassification(string result)
    {

        Debug.Log("Received Classification: " + result);
        this.classList = result.Split(',').Select(Int32.Parse).ToList();
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.receiveResult(this.traitList, this.classList);

    }

    public void receiveTraits(string result)
    {
        Debug.Log("Received Traits: " + result);
        this.traitList = result.Split(',').Select(Int32.Parse).ToList();
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.receiveResult(this.traitList, this.classList);
    }


}