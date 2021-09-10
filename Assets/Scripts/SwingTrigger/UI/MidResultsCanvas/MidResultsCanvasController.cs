using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SwingTriger
{
public class MidResultsCanvasController : MonoBehaviour
{
    public TextMeshProUGUI pitchTypeTextObject, decisionModeTextObject, resultTextObject, timingTextObject;

    public static MidResultsCanvasController instance;
    void Awake()
    {
        instance=this;
    }
    void Start()
    {
        
    }
    public void SetPitchTypeText(PitchType pitchType)
    {
        var str=GameplayController.instance.GetPitchString(pitchType);
        pitchTypeTextObject.text=str;
    }
    public void SetDecisionModeTypeText(bool isSwing)
    {
        if(isSwing==true)
            decisionModeTextObject.text="Swing";
        else
            decisionModeTextObject.text="Not Swing";
    }
    public void SetResultTypeText(bool isResult)
    {
        if(isResult==true)
            resultTextObject.text="Correct";
        else
            resultTextObject.text="Incorrect";
    }
    public void SetTimingText(float time)
    {
        timingTextObject.text=time.ToString("0.000")+ " milliseconds";
    }
}

}