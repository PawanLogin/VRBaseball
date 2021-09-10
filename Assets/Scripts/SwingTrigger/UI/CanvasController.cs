using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Canvas midResultsCanvas, finalResultsCanvas;
    public static CanvasController instance;

    void Awake()
    {
        instance=this;
        SetMidResultsCanvasActive(false);
        SetFinalResultsCanvasActive(false);
    }
    void Start()
    {

    }
    void Update()
    {
        
    }
    public void SetMidResultsCanvasActive(bool status)
    {
        midResultsCanvas.enabled=status;
    }
    public void SetFinalResultsCanvasActive(bool status)
    {
        finalResultsCanvas.enabled=status;
    }
}
