using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO;


public class CartSpawner : MonoBehaviour

{
    public Transform spawn;
    public Cart cart;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CartFront")) {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        Instantiate(cart, spawn.position, Quaternion.identity);
    }
}
