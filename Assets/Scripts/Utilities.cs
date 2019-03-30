﻿using System.Collections.Generic;
using UnityEngine;


public static class Utilities
{
    //A place for general utilities

    public static bool HasTags (Collider collider, string[] tags)
    {
        foreach (string tag in tags) {
            if (collider.tag == tag) {
                return true;
            }
        }
        return false;
    }

    public static bool HasTags (GameObject obj, string[] tags)
    {
        foreach (string tag in tags) {
            if (obj.tag == tag) {
                return true;
            }
        }
        return false;
    }

    public static bool Exists (Vector3 location, string[] tags, float marginOfError)
    {
        Collider[] colliders = Physics.OverlapSphere (location, marginOfError);
        foreach (Collider collider in colliders) {
            if (HasTags (collider, tags)) {
                return true;
            }
        }
        return false;
    }

    public static bool Exists (Vector3 location, GameObject obj, float marginOfError)
    {
        Collider[] colliders = Physics.OverlapSphere (location, marginOfError);
        foreach (Collider collider in colliders) {
            if (collider.gameObject.Equals (obj)) {
                return true;
            }
        }
        return false;
    }

    public static Collider[] GetCollidersWithTags (Vector3 location, float overlapSize, string[] tags)
    {
        List<Collider> selectedColliders = new List<Collider> ();
        Collider[] colliders = Physics.OverlapSphere (location, overlapSize);
        foreach (Collider collider in colliders) {
            if (HasTags (collider, tags)) {
                selectedColliders.Add (collider);
            }
        }
        return selectedColliders.ToArray ();
    }

    public static Collider GetNearestCollider (Transform trans, Collider[] colliders)
    {
        if (colliders == null) {
            Debug.Log ("Null collider array passed");
            return null;
        }
        if (colliders.Length == 0) {
            Debug.Log ("Empty collider array passed");
            return null;
        }

        Collider nearest = colliders [0];
        float minDistance = Vector3.Distance (nearest.transform.position, trans.position);
        foreach (Collider collider in colliders) {
            float distance = Vector3.Distance (collider.transform.position, trans.position);
            if (distance < minDistance) {
                nearest = collider;
                minDistance = distance;
            }
        }
        return nearest;
    }

    public static Collider GetRandomCollider (Collider[] colliders)
    {
        if (colliders == null) {
            Debug.Log ("Null collider array passed");
            return null;
        }
        if (colliders.Length == 0) {
            Debug.Log ("Empty collider array passed");
            return null;
        }

        int randomLocation = Random.Range (0, colliders.Length - 1);
        return colliders [randomLocation];
    }

    public static List<Transform> GetDescendentTransforms (Transform parent)
    {
        if (parent == null) {
            return new List<Transform> (); //return empty list if passed null
        }
        List<Transform> transforms = new List<Transform> ();
        foreach (Transform child in parent) {
            transforms.Add (child);
            List<Transform> descendents = GetDescendentTransforms (child);
            transforms.AddRange (descendents);
        }
        return transforms;
    }

    public static List<Transform> GetDescendentTransforms (GameObject obj)
    {
        if (obj == null) {
            return new List<Transform> (); //return empty list if passed null
        }
        Transform parent = obj.transform;
        return GetDescendentTransforms (parent);
    }

    public static GameObject[] GetDescendentObjects (Transform parent)
    {
        if (parent == null) {
            return new GameObject[0]; //return empty array if passed null
        }
        List<Transform> transformList = GetDescendentTransforms (parent);
        List<GameObject> objectList = new List<GameObject> ();
        foreach (Transform t in transformList) {
            objectList.Add (t.gameObject);
        }
        return objectList.ToArray ();
    }

    public static GameObject[] GetDescendentObjects (GameObject obj)
    {
        if (obj == null) {
            return new GameObject[0]; //return empty array if passed null
        }
        Transform parent = obj.transform;
        return GetDescendentObjects (parent);
    }

    public static void Reactivate (GameObject obj, Vector3 position, Vector3 force)
    {
        obj.transform.position = position;
        obj.SetActive (true);
        Rigidbody rigidBody = obj.GetComponent<Rigidbody> ();
        if (rigidBody != null) {
            rigidBody.AddForce (force);
        } else {
            Debug.Log ("Attempted to apply force to an object without Rigidbody");
        }
    }

    public static void Deactivate (GameObject obj)
    {
        obj.SetActive (false);
    }

    public static Vector3 GetNearestPoint (Vector3 location, float gridSize)
    {
        float newX = GetNearestValue (location.x, gridSize);
        float newY = GetNearestValue (location.y, gridSize);
        float newZ = GetNearestValue (location.z, gridSize);
        return new Vector3 (newX, newY, newZ);
    }

    public static float GetNearestValue (float value, float gridValue)
    {
        float remainder = value % gridValue;
        float baseGridCount = Mathf.Floor (value / gridValue);
        float middleGridSize = gridValue / 2.0f;
        float middleValue = baseGridCount * gridValue + middleGridSize;
        if (value < middleValue) {
            return baseGridCount * gridValue;
        } else {
            return (baseGridCount + 1) * gridValue;
        }
    }

    public static Vector3? GetWorldMousePosition ()
    {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit)) {
            Vector3 hitPoint = hit.point;
            return hitPoint;
        }
        return null;
    }

    public static Transform GetWorldMouseTransform()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) ? hit.transform : null;
    }

    public static Vector3? GetWorldMousePosition (string layerMaskName)
    {
        int layerMask = GetLayerMask (layerMaskName);
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)) {
            Vector3 hitPoint = hit.point;
            return hitPoint;
        }
        return null;
    }

    public static int GetLayerMask (string maskName)
    {
        int layerNumber = LayerMask.NameToLayer (maskName);
        return 1 << layerNumber;
    }

    public static Vector3? GetWorldMousePosition (Camera camera)
    {
        Ray ray = camera.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit)) {
            Vector3 hitPoint = hit.point;
            return hitPoint;
        }
        return null;
    }
}