using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SceneControl : MonoBehaviour
{

    public int target = 30;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    void Update()
    {
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }

    void changeFPS(int fps)
    {
        this.target = fps;
    }
    void toggleWebGLInput()
    {
        // disable WebGLInput.captureAllKeyboardInput so elements in web page can handle keabord inputs
        WebGLInput.captureAllKeyboardInput = !WebGLInput.captureAllKeyboardInput;
    }

    void disableWebGLInput()
    {
        // disable WebGLInput.captureAllKeyboardInput so elements in web page can handle keabord inputs
        WebGLInput.captureAllKeyboardInput = false;
    }


}