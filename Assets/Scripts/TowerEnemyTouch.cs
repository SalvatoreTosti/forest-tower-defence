using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemyTouch : MonoBehaviour {

    public int damageAmount = 1;

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag.Equals("End Tower"))
        {
            col.transform.GetComponent<Health>().Damage(damageAmount);
        }
    }
}
