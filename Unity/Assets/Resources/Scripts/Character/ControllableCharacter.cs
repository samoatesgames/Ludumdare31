﻿using UnityEngine;using System.Collections;public class ControllableCharacter : ICharacter {
    /// <summary>
    /// The number of seconds between spell casts
    /// </summary>
    public float FireRate = 1.0f;

    /// <summary>
    /// The last time a spell was cast
    /// </summary>
    private float m_lastFireTime = 0.0f;    /// <summary>    /// The identity of this character    /// </summary>    public PlayerIdentity Identity = PlayerIdentity.Owen;    /// <summary>    /// WHere the player is aiming    /// </summary>    private Vector2 m_aimTarget = Vector2.zero;	// Use this for initialization	protected override void Start ()     {        base.Start();	}    // Update is called once per frame    protected override void Update()    {        base.Update();    }		// Fixed updates is called once per physics update    protected override void FixedUpdate()    {        base.FixedUpdate();        var initialPosition = this.transform.position;        var movement = Vector3.zero;        const float movementAmount = 0.1f;        var controls = ControllerManager.Instance;        // Test input for movement        if (controls.IsButtonPressed(this.Identity, ControlButton.Up))        {            movement.y += movementAmount;        }        if (controls.IsButtonPressed(this.Identity, ControlButton.Down))        {            movement.y -= movementAmount;        }        if (controls.IsButtonPressed(this.Identity, ControlButton.Left))        {            movement.x -= movementAmount;        }        if (controls.IsButtonPressed(this.Identity, ControlButton.Right))        {            movement.x += movementAmount;        }        this.transform.position = initialPosition + (movement * GetSpeedScale());        var animController = GetAnimationController();        if (movement.sqrMagnitude != 0.0f)        {            animController.PlayWalkAnimation();        }        else        {            animController.PlayIdleAnimation();        }        // Test for shooting input        if (CanShoot() && controls.IsButtonPressed(this.Identity, ControlButton.Shoot))        {            this.FireBullet(controls.GetAimDirection(this.Identity));
            m_lastFireTime = Time.time;        }	}    /// <summary>
    /// Is the player allowed to shoot
    /// </summary>
    /// <returns></returns>    private bool CanShoot()
    {
        return Time.time - m_lastFireTime >= this.FireRate;
    }    /// <summary>    ///     /// </summary>    /// <returns></returns>    private float GetSpeedScale()    {        return this.Speed;    }    /// <summary>    ///     /// </summary>    /// <returns></returns>    private ControllableCharacterAnimationController GetAnimationController()    {        return m_animationController as ControllableCharacterAnimationController;    }    // Called when the player enters a collision    protected override void OnCollisionEnter2D(Collision2D collision)    {    }}