using UnityEngine;
using System;

// Abhiwan added the namespace
namespace SwingTriger
{
    public class RemoveComponant : MonoBehaviour
    {
        public GameObject textMeshPro;
        
        // Start is called before the first frame update
        void OnDisable()
        {
           // Debug.Log("I'm called to vanish value ...");
           // textMeshPro.GetComponent<TMPro.TMP_Text>().text = "0:000 milliseconds";
        }

    }
}
