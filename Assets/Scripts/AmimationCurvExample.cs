using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmimationCurvExample : MonoBehaviour
{

   public Transform targetA;
   public Transform targetB;
    public Transform TargetMid;
    public Transform TargetMid1;

    public AnimationCurve animCurv;

    public Vector3 lerpOffset;

    public int learTime;

    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > learTime)
        {
            timer = learTime;
        }

        float lerpRatio = timer / learTime;

        float percent = animCurv.Evaluate(lerpRatio);

       // transform.position = Vector3.Lerp(targetA.position, targetB.position, lerpRatio) + postionOffset;


        if (percent > 0)
        {
            transform.position = CalcPositionOnCurve(percent);
        }
    }

    private Vector3 CalcPositionOnCurve(float percent)
    {
        Vector3 c = AnimMath.Lerp(targetA.position, TargetMid.position, percent);
        Vector3 d = AnimMath.Lerp(TargetMid.position, targetB.position, percent);
       // Vector3 e = AnimMath.Lerp(TargetMid1.position, targetB.position, percent);

        Vector3 f = AnimMath.Lerp(c, d, percent);
       // Vector3 g = AnimMath.Lerp(d, e, percent);


       // Vector3 h = AnimMath.Lerp(f, g, percent);


        return f;
       // return h;
    }
}
