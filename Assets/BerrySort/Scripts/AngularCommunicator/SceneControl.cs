using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SceneControl : MonoBehaviour
{

    public int target = 24;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }

    void Update()
    {
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }

    void changeRefresh(int fps)
    {
        this.target = fps;
    }

    void changeRefreshAngular(string fps)
    {
        this.target = Int32.Parse(fps);
    }

    // disable WebGLInput.captureAllKeyboardInput so elements in web page can handle keabord inputs
    // A normal Toggle Method didn't seem to work so it got split up.
    void disableWebGLInput()
    {

        WebGLInput.captureAllKeyboardInput = false;
    }

    void enableWebGLInput()
    {

        WebGLInput.captureAllKeyboardInput = true; ;
    }


}