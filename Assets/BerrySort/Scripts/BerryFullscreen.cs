using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class BerryFullscreen : MonoBehaviour
{
    public RawImage image;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showImage(Texture2D texture) {
        image.texture = texture;
        canvas.gameObject.SetActive(true);
    }
}
