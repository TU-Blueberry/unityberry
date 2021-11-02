using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class TalkBack : MonoBehaviour
{

    public TextMesh talkBack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    void TalkBackJS(string message)
    {

        talkBack.text = message;


    }
}
