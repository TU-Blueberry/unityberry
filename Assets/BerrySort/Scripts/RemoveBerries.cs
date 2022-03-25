using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Berries;

public class RemoveBerries : MonoBehaviour
{
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
            Destroy(other.gameObject);
        }
    }
}
