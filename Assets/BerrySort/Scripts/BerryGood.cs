using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryGood : Berry
{


    // Start is called before the first frame update
    void Start()
    {
        /*      this.classification = 0;
                this.berryTrait = 0; */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public BerryGood(int classification) : base(1)
    {
        this.classification = 1;
    }

}
