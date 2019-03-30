using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Waypoint startPoint;
    private Waypoint currentPoint;

    void Start()
    {
        currentPoint = startPoint ?? GameObject.Find("Waypoint").GetComponent<Waypoint>();
        if (currentPoint == null)
        {
            GetComponent<MoveToward>().target = transform;
            return;
        }
        GetComponent<MoveToward>().target = currentPoint.transform;
    }

    void Update()
    {
        if (currentPoint == null)
        {
            return;
        }

        if (transform.position == GetComponent<MoveToward>().target.position)
        {
            currentPoint = currentPoint.GetNextPoint();
            if (currentPoint == null)
            {
                GetComponent<MoveToward>().target = transform;
                return;
            }
            GetComponent<MoveToward>().target = currentPoint.transform;
        }
    }
}
