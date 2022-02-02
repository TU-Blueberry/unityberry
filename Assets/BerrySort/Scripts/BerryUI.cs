using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Berries;

public class BerryUI : MonoBehaviour
{
    public GameObject image;
    public Transform panel;
    public int correctTrait;
    public Color outlineColor;
    public List<GameObject> images = new List<GameObject>();
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
        if (other.GetComponent<Berry>() != null)
        {
            var berry = (Berry)other.gameObject.GetComponent<Berry>();
            if (berry.trait == correctTrait) return;
            if (images.Count > 0)
            {
                GameObject new_image = Instantiate(images.Last(), panel);
                new_image.GetComponent<Outline>().effectColor = outlineColor;
                foreach (GameObject go in images)
                {
                    go.GetComponent<RectTransform>().localPosition += Vector3.right * 160;
                }
                Texture2D texture = new Texture2D(16, 16);
                byte[] b64_bytes = System.Convert.FromBase64String(berry.image);
                texture.LoadImage(b64_bytes);
                new_image.GetComponent<RawImage>().enabled = true;
                new_image.GetComponent<RawImage>().texture = texture;
                images.Add(new_image);
                if (images.Count > 7)
                {

                    Destroy(images[0]);
                    images.RemoveAt(0);
                }
            }
        }
    }
}
