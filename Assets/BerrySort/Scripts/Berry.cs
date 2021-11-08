using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{

    public int classification;
    public int berryTrait;

    public Transform endpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public Berry(int berryTrait)
    {
        this.berryTrait = berryTrait;
    }

    public void getSorted()
    {


    }
}
