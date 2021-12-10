using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwingTriger
{

    public class BallRotator : MonoBehaviour
    {
        public static BallRotator instance;
        public float speedMultiplier = 1;
        public GameObject ball;
        GameObject _ball;

        // Start is called before the first frame update


        void Awake()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Random.Range(1, 2) * speedMultiplier, Random.Range(1, 2) * speedMultiplier, Random.Range(1, 2) * speedMultiplier);
            if (Input.GetMouseButtonDown(0))
            {
                if (SwingTriger.BaseballController.instance.isballthrough && (SwingTriger.BaseballController.instance.isStrikes))
                {
                    SwingTriger.BaseballController.instance.isSwing = true;
                    Vector3 ballPos = this.transform.position;
                    Debug.Log($"this is ball Pos {ballPos}");
                    ballPos = new Vector3(ballPos.x, ballPos.y - 0.08f, ballPos.z);
                    Debug.Log($"this is ball Pos {ballPos}");
                    _ball = Instantiate(ball, ballPos, Quaternion.identity);
                    //StartCoroutine(DestroyObject());
                }
                if (SwingTriger.BaseballController.instance.isballthrough && SwingTriger.BaseballController.instance.isBall)
                {
                    SwingTriger.BaseballController.instance.isSwing = true;
                }

            }
        }

       public IEnumerator DestroyObject()
        {
            yield return new WaitForSeconds(0f);
            if (_ball != null)
            {
                Destroy(_ball);
            }
        }
    }
}