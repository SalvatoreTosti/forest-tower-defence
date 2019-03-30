using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickManager : MonoBehaviour
{

    public GameObject tower;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform clickedTransform = Utilities.GetWorldMouseTransform();
            if (clickedTransform != null)
            {
                if (clickedTransform.tag.Equals("test"))
                {
                    GameObject newTower = Instantiate(tower);
                    newTower.transform.position = clickedTransform.position;
                    newTower.transform.parent = GameObject.Find("Tiles").transform;
                    Destroy(clickedTransform.gameObject);
                }
            }
        }
    }
}
