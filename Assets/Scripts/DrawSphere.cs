using UnityEngine;
using System.Collections;

public class DrawSphere : MonoBehaviour
{

    public Transform target;
    public float size = 1.0f;
    public Color gizmoColor = Color.green;

    private void Start()
    {
        if(target == null)
        {
            target = transform;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        if (target != null)
        {
            Gizmos.DrawWireSphere(target.position, size);
        }
    }
}