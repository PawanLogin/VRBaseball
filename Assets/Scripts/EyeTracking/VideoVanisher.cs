using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoVanisher : MonoBehaviour
{
    public MeshRenderer rend;
    public int vidNum;

    // Update is called once per frame
    void Update()
    {
        if (RayCasting.pitcher == vidNum)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
    }
}
