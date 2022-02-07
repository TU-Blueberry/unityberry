using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Berries;

public class BerryDisplay : MonoBehaviour
{
    public GameObject image;
    public Transform panel;
    public List<GameObject> images = new List<GameObject>();
    public int limit;

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

    public void addBerry(Berry berry, Color outlineColor) {
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
        if (images.Count > limit)
        {
            Destroy(images[0]);
            images.RemoveAt(0);
        }
    }
}
