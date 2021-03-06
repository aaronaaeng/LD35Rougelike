﻿using UnityEngine;
using System.Collections;
using System;

public abstract class Ability : MonoBehaviour, ILevelable {

    private const string DEFAULT_ABILITY_FOLDER = "Ability/"; 

    private const float COOLDOWN_UPATE_RATE = 0.1f;

	public int level;

	public float baseCooldown;

    public float cooldown;

    protected float cooldownReduction;

    public PlayerUnit playerUnit;

    public abstract void OnCast();

    public abstract void ForceLoadIcon();

    public int staminaCost;
    public int healthCost;

    private Sprite icon;

    public void loadIcon(String name)
    {
        icon = Resources.Load<Sprite>(name);
    }

    public void SetCooldownReducation(float cdr)
    {
        this.cooldownReduction = cdr;
    }

    public void SetCooldown(float cooldown)
    {
        this.cooldown = cooldown;
    }

    public void StartCooldown()
    {
        cooldown = baseCooldown;
        InvokeRepeating("IncrementCooldown", 0, COOLDOWN_UPATE_RATE);
    }

    private void IncrementCooldown()
    {
        cooldown -= COOLDOWN_UPATE_RATE;
        if (cooldown <= 0.0)
        {
            CancelInvoke("IncrementCooldown");
            cooldown = 0;
        }
    }

    public bool OffCooldown()
    {
        return cooldown == 0;
    }

    public float BaseCooldown
    {
        get
        {
            return baseCooldown;
        }
    }

    public float Cooldown
    {
        get
        {
            return cooldown;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    public abstract string Description
    {
        get;
    } 

    public abstract string Title
    {
        get;
    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

    public int StaminaCost
    {
        get
        {
            return staminaCost;
        }
    }

    public bool IsIconLoaded()
    {
        return icon != null;
    }
}
