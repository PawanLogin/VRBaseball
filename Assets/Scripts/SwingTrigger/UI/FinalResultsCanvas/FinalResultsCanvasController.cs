using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SwingTriger
{
public class FinalResultsCanvasController : MonoBehaviour
{
    public GameObject myAnswerTextPrefab, expectedAnswerTextPrefab, reactionTimeTextPrefab;
    public GameObject myAnswerTextHolder, expectedAnswerTextHolder, reactionTimeTextHolder;
    public TextMeshProUGUI performanceTextObject, averageTimeTextObject;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void ClearAllHolders()
    {
        myAnswerTextHolder.Clear();
        expectedAnswerTextHolder.Clear();
        reactionTimeTextHolder.Clear();
    }
    public void ClearAndAddEntries()
    {
        ClearAllHolders();
        
        AddMyAnswersEntries();
        AddCorrectAnswersEntries();
        AddReactionTimeEntries();
    }
    public void AddMyAnswersEntries()
    {
        foreach (var item in GameplayController.instance.myAnswersPitchList)
        {
            var instantiatedObject=Instantiate(myAnswerTextPrefab, Vector3.zero, Quaternion.identity, myAnswerTextHolder.transform);
            var textObject=instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
            textObject.text=GameplayController.instance.GetPitchString(item);
        }
    }
    public void AddCorrectAnswersEntries()
    {
        foreach (var item in GameplayController.instance.correctAnswersPitchList)
        {
            var instantiatedObject=Instantiate(expectedAnswerTextPrefab, Vector3.zero, Quaternion.identity, expectedAnswerTextHolder.transform);
            var textObject=instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
            textObject.text=GameplayController.instance.GetPitchString(item);
        }
    }
    public void AddReactionTimeEntries()
    {
        foreach (var item in GameplayController.instance.reactionTimeList)
        {
            var instantiatedObject=Instantiate(expectedAnswerTextPrefab, Vector3.zero, Quaternion.identity, expectedAnswerTextHolder.transform);
            var textObject=instantiatedObject.GetComponentInChildren<TextMeshProUGUI>();
            textObject.text=item.ToString("0.000");
        }
    }
    public void AssignPerformanceTextObject(int myAnswersCount, int totalAnswersCount)
    {
        performanceTextObject.text=myAnswersCount+"/"+totalAnswersCount;
    }
    public void AssignTimeTextObject()
    {
        float totalTime=0;
        foreach (var item in GameplayController.instance.reactionTimeList)
        {
            totalTime+=item;
        }
        var averageVal=totalTime/GameplayController.instance.reactionTimeList.Count;
        averageTimeTextObject.text=averageVal.ToString("0.000");
    }
}

}
