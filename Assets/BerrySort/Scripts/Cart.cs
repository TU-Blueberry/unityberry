using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public int limit;
    public float speed;
    public Transform loadPoint;
    public Transform endPoint;
    
    private Transform goal;
    private int load = 0; //Number of berries loaded
    private Rigidbody cart;
    // Start is called before the first frame update
    void Start()
    {
        goal = loadPoint;
        cart = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, goal.position, speed * Time.deltaTime);
        cart.MovePosition(newPos);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Berry")) {
            load++;
            if (load == limit) {
                goal = endPoint;
            }
        }
    }
}
