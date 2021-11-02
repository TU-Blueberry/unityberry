using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This should extend Berries
public class BerryBad : Berry
{

    // Start is called before the first frame update
    void Start()
    {
        /*         this.classification = 0;
                this.berryTrait = 0; */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public BerryBad(int classification) : base(0)
    {
        this.classification = 0;
    }

}
