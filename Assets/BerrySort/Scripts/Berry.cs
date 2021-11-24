using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{

    public int classification;
    public int trait;

    // Base
    public string image;

    // Path to the Image
    public string imagePath;

    public GameObject berryObject;
    /* 
        void Start()
        {
            Destroy(berryObject, 1);
        } */

    void Awake()
    {

    }

    void Update()
    {

    }


    // A good Berry will always be generated with a classification 1 and a bad with 0 since they call their parent Constructor.
    // In the two classes which extend the berry they receive their classification.
    // Basic Berry Generator.
    public Berry(int classification)
    {
        this.classification = classification;

    }

    // TODO: Consider Handling Image generation here or in the Spawn script.
    public Berry(int trait, int classification, string imagePath)
    {
        this.classification = classification;
        this.trait = trait;
        this.imagePath = imagePath;

    }

    public void getSorted()
    {


    }
}
