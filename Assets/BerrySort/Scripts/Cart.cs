using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public int limit;
    public float speed;
    public Transform loadPoint;
    public Transform endPoint;
    public GameObject text;

    private Transform goal;
    private int load = 0; //Number of berries loaded
    private int good = 0;
    private int bad = 0;
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
        if (other.gameObject.CompareTag("Berry"))
        {
            var berry = (Berry)other.gameObject.GetComponent<Berry>();
            if (berry.trait == 0)
            {
                bad++;
            }
            else
            {
                good++;
            }
            load++;
            if (load == limit)
            {
                goal = endPoint;
                var newText = System.String.Format("Good: {0} | Bad: {1}", good, bad) + "\n" + text.GetComponent<TextMesh>().text;
                var splitted = newText.Split('\n');
                if (splitted.Length > 3)
                {
                    newText = splitted[0] + "\n" + splitted[1] + "\n" + splitted[2];
                }
                text.GetComponent<TextMesh>().text = newText;
            }
        }
    }
}
