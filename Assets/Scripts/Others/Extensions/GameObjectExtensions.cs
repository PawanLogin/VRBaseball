using System.Collections;
using System.Collections.Generic;
using UnityEngine;


static public class GameObjectExtensions
{    
    static public void Clear(this GameObject go)
    {
        for (int i = go.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(go.transform.GetChild(i).gameObject);
        }
    }   
    static public void ClearImmediate(this GameObject go)
    {
        for (int i = go.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(go.transform.GetChild(i).gameObject);
        }
    }
}
