﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RenderOrderSorter : MonoBehaviour
{
    /// <summary>
    /// The initial sorting orders of all sprite renderers
    /// </summary>
    protected Dictionary<SpriteRenderer, int> m_initialSortingOrders = new Dictionary<SpriteRenderer, int>();

	// Use this for initialization
	void Start () 
    {
        // Store renderer sorting orders
        var renderers = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers)
        {
            m_initialSortingOrders.Add(renderer, renderer.sortingOrder);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        int orderOffset = (int)(this.transform.position.y * 100.0f);

        var renderers = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.sortingOrder = m_initialSortingOrders[renderer] - orderOffset;
        }
	}
}
