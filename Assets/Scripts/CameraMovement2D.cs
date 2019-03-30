using UnityEngine;
using System.Collections;

public class CameraMovement2D : MonoBehaviour
{

    public AnimationCurve speedCurve;
    //public float speed = 1.0f;

    Vector3 up2D = new Vector3(1,0,0);
    Vector3 down2D = new Vector3(-1, 0, 0);
    Vector3 right2D = new Vector3(0, 0, -1);
    Vector3 left2D = new Vector3(0, 0, 1);
    private float moveTime = 0;

    void Update()
    {
        moveTime += Time.deltaTime;
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(up2D * speedCurve.Evaluate(moveTime));
            return;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(down2D * speedCurve.Evaluate(moveTime));
            return;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(right2D * speedCurve.Evaluate(moveTime));
            return;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(left2D * speedCurve.Evaluate(moveTime));
            return;
        }
        moveTime = 0;
    }
}