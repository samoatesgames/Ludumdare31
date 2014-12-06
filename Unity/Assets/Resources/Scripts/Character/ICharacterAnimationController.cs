﻿using UnityEngine;using System.Collections;public abstract class ICharacterAnimationController : MonoBehaviour {
    /// <summary>
    /// The animator of the character
    /// </summary>
    protected Animator m_animator = null;    // Called on start    protected virtual void Start()    {
        m_animator = this.GetComponent<Animator>();
        if (m_animator == null)
        {
            Debug.LogError(string.Format("The character {0} does not have an animator component.", this.name));
            this.gameObject.SetActive(false);
        }    }}