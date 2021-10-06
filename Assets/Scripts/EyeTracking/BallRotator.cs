using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallRotator : MonoBehaviour
{
    public float speedMultiplier = 1;
    //public GameObject ball;
   // GameObject _ball;

    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Random.Range(1,2) * speedMultiplier, Random.Range(1, 2) * speedMultiplier, Random.Range(1, 2) * speedMultiplier);
       
    }

  
}
