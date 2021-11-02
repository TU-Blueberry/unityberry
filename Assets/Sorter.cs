using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{


    float elapsed = 0f;
    public float backwardsMomentum;
    public float forwardMomentun;
    public Transform endPoint;
    public GameObject piston;
    public Transform startPoint;
    bool move = false;




    // Start is called before the first frame update
    void Start()
    {

        bool move = false;
    }

    // Update is called once per frame
    void Update()
    {

        /*         if (piston.transform.position.z != endPoint.position.z && piston.transform.position.z == startPoint.position.z)
                {
                    move = true;
                } */

        if (piston.transform.position.z == endPoint.position.z && piston.transform.position.z != startPoint.position.z)
        {
            move = false;
        }

        if (move)
        {
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, endPoint.position, forwardMomentun * Time.deltaTime);
        }
        if (!move)
        {
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, startPoint.position, backwardsMomentum * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        // if (other.CompareTag("Building"))
        {
            var berry = (Berry)other.gameObject.GetComponent<Berry>();
            Debug.Log("Classification:" + berry.classification);
            Debug.Log("BerryTrait:" + berry.berryTrait);

            if (berry.classification == 0)
            {
                this.move = true;
            }
        }
    }
}
