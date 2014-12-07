﻿using UnityEngine;
using System.Collections;

public class BloodDecalManager : MonoBehaviour 
{
    /// <summary>
    /// Singleton instance
    /// </summary>
    static private BloodDecalManager s_instance = null;

    /// <summary>
    /// Public access to the blood decal manager
    /// </summary>
    public static BloodDecalManager Instance
    {
        get { return s_instance; }
    }

    /// <summary>
    /// Array of blood decals
    /// </summary>
    public GameObject[] BloodDecals = null;

	// Use this for initialization
	void Awake () 
    {
	    if (s_instance != null)
        {
            Debug.LogError("Multiple blood decal managers have been created!");
            return;
        }

        s_instance = this;
	}
	
    public void AddBloodDecal(Vector3 position)
    {
        var bloodDecal = this.BloodDecals[Random.Range(0, BloodDecals.Length)];
        var newDecal = (GameObject) GameObject.Instantiate(bloodDecal);
        newDecal.transform.parent = this.transform;
        newDecal.transform.position = position;
        newDecal.transform.localEulerAngles = new Vector3(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    public void AddDeathDecal()
    {

    }
}
