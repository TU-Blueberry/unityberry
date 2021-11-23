using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{

    public int classification;
    public int trait;
    public string picture; //Base64

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
    public Berry(int classification)
    {
        this.classification = classification;

    }

    public void getSorted()
    {


    }
}
