using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour


{
    public GameObject belt;
    public Transform endpoint;
    public float speed;
    public float animSpeed;
    private Renderer beltRender;
    private float offsetX = 0;

    // Start is called before the first frame update
    void Start()
    {
        beltRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offsetX = (offsetX + Time.deltaTime * animSpeed) % 1;
        beltRender.material.mainTextureOffset = new Vector2(offsetX, 0f);
    } 

    void OnTriggerStay(Collider other)
    {

        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);

    }
}
