using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPattern : MonoBehaviour {

    public AnimationCurve spawnCurve;
    public GameObject spawnMob;
    private float lastSpawnTime = 0;

	// Update is called once per frame
	void Update () {
        if(lastSpawnTime + spawnCurve.Evaluate(Time.time) <= Time.time)
        {
            lastSpawnTime = Time.time;
            Instantiate(spawnMob);
        }
	}
}
