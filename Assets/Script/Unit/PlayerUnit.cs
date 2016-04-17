﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerUnit : Unit {

    public Vector2 relativeMouse;

    public Ability abilityOne;
    public Ability abilityTwo;
    public Ability abilityThree;
    public Ability abilityFour;

    protected override void OnStart()
    {
        UpdateRelativeMouse();
        //StartMoving();
    }

    protected override void OnDeath()
    {
        
    }

    protected override void OnUpdate()
    {
        UpdateRelativeMouse();


        HandleAbilityInput();
    }


    private void HandleAbilityInput()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            if (abilityOne != null)
            {
                abilityOne.OnCast();
            }
        }
        if (Input.GetButtonDown("Ability2"))
        {
            if (abilityTwo != null)
            {
                abilityTwo.OnCast();
            }
        }
        if (Input.GetButtonDown("Ability3"))
        {
            if (abilityThree != null)
            {
                abilityThree.OnCast();
            }
        }
        if (Input.GetButtonDown("Ability4"))
        {
            if (abilityFour != null) { 
                abilityFour.OnCast();
            }
        }
    }

    private void UpdateRelativeMouse()
    {
        Vector2 mouseLoc = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        relativeMouse = mouseLoc - new Vector2(transform.position.x, transform.position.y);
    }

    public Vector2 RelativeMouse
    {
        get
        {
            return new Vector2(relativeMouse.x, relativeMouse.y);
        }
    }
    
    protected override void OnMoveStart()
    {

    }   

    protected override void OnMoveEnd()
    {

    }
}
