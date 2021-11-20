using UnityEngine;


public class VideoVanisher : MonoBehaviour
{
    public MeshRenderer rend;
    public int vidNum;

    // Update is called once per frame
    void Update()
    {
        if (SwingTriger.RayCasting.pitcher == vidNum)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }

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

