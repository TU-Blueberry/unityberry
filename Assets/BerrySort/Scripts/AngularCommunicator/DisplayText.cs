using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{

    float elapsed = 0f;
    public TextMesh count;
    public TextMesh display;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            OutputTime();
            count.text = "Count:" + elapsed;
        }
    }
    void OutputTime()
    {

    }

    void RenderText(string text)
    {
        display.text = text;
    }
}
