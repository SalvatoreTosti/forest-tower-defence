﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public Waypoint nextPoint;

    public Waypoint GetNextPoint()
    {
        return nextPoint;
    }
}
