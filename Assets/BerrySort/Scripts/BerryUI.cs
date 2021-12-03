using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BerryUI : MonoBehaviour
{
    public GameObject image;
    public Transform panel;
    private List<GameObject> images = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        image.GetComponent<RawImage>().enabled = false;
        images.Add(image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Berry"))
        {
            var berry = (Berry)other.gameObject.GetComponent<Berry>();
            if(berry.trait == 1)return;
            GameObject new_image = Instantiate(images.Last(), panel);
            foreach(GameObject go in images) {
                go.GetComponent<RectTransform>().localPosition += Vector3.right*160;   
            }
            Texture2D texture = new Texture2D(64, 64);
            byte[] b64_bytes = System.Convert.FromBase64String(berry.picture);
            texture.LoadImage(b64_bytes);
            new_image.GetComponent<RawImage>().enabled = true;
            new_image.GetComponent<RawImage>().texture = texture;
            images.Add(new_image);
            if(images.Count > 7) {
                Destroy(images[0]);
                images.RemoveAt(0);
            }
        }
    }
}
