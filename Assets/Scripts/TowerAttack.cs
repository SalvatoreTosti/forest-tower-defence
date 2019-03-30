using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour {

    public float range = 5;
    public int damage = 2;
    public float speed = 1;

    public string[] targetTags;

    private float lastAttackTime = 0;

    void Update()
    {
        if(lastAttackTime + speed <= Time.time)
        {
            Collider[] targets = Utilities.GetCollidersWithTags(transform.position, range, targetTags);
            if(targets.Length > 0)
            {
                Collider target = Utilities.GetNearestCollider(transform, targets);
                target.GetComponent<Health>().Damage(damage);
                Debug.DrawLine(transform.position + Vector3.up, target.transform.position, Color.magenta, speed);

                lastAttackTime = Time.time;
            }
        }
    }
}
