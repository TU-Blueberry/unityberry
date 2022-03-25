using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Berries;

public class BerryUI : MonoBehaviour
{
    public BerryDisplay display;
    public int correctTrait;
    public Color outlineColor;
    public List<GameObject> images = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Berry>() != null)
        {
            var berry = (Berry)other.gameObject.GetComponent<Berry>();
            if (berry.trait == correctTrait) return;
            display.addBerry(berry, outlineColor);
        }
    }
}
