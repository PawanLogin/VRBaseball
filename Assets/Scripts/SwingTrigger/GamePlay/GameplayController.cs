using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwingTriger
{
public enum PitchType{FourSeamFastball, TwoSeamFastball, ChangeUp, Slider, Curveball};
public class GameplayController : MonoBehaviour
{
    public int totalQuestions;
    public List<PitchType> myAnswersPitchList, correctAnswersPitchList;
    public List<float> reactionTimeList;
    public static GameplayController instance;

    void Awake()
    {
        instance=this;
    }
    void Start()
    {
        
    }
    void Update()
    {
    }
    public string GetPitchString(PitchType pitchType)
    {
        string str="";
        if(pitchType==PitchType.FourSeamFastball)
            str="4 Seam Fastball";
        else if(pitchType==PitchType.TwoSeamFastball)
            str="2 Seam Fastball";
        else if(pitchType==PitchType.Slider)
            str="Slider";
        else if(pitchType==PitchType.ChangeUp)
            str="Change Up";
        else if(pitchType==PitchType.Curveball)
            str="Curveball";
        
        return str;
    }
    public void ClearAllLists()
    {
        myAnswersPitchList.Clear();
        correctAnswersPitchList.Clear();
        reactionTimeList.Clear();
    }
    public void AddMyAnswersEntry(PitchType pType)
    {
        myAnswersPitchList.Add(pType);
    }
    public void AddCorrectAnswersEntry(PitchType pType)
    {
        correctAnswersPitchList.Add(pType);
    }
    public void AddReactionTimeEntry(float val)
    {
        reactionTimeList.Add(val);
    }
    public void SetTotalQuestions(int totalQuestions)
    {
        this.totalQuestions=totalQuestions;
    }

}

}