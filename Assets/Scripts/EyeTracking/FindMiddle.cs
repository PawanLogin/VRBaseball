using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMiddle : MonoBehaviour
{

    public Transform pitchLoc;
    public Transform endPos;

    
    void Start()
    { 

    }

    
    void Update()
    {
        Vector3 newLoc = (pitchLoc.position + endPos.position) / 2;
        transform.position = newLoc;
    }

}
