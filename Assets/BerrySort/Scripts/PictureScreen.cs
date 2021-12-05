using System.Collections;
using System.Collections.Generic;
using Berries;
using UnityEngine;

public class PictureScreen : MonoBehaviour
{
    public GameObject screen;
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
        if (other.gameObject.CompareTag("Berry"))
        {
            var berry = (Berry)other.gameObject.GetComponent<Berry>();
            Texture2D texture = new Texture2D(16, 16);

            byte[] b64_bytes = System.Convert.FromBase64String(berry.image);
            texture.LoadImage(b64_bytes);
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = texture;
        }
    }
}
