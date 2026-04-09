using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public HealthBar playerStatBar;

    [Header("Listen")]
    public CharacterEvent healthEvent;
    private void OnEnable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
    }
    private void OnDisable()
    {
        healthEvent.OnEventRaised -= OnHealthEvent;
    }

    private void OnHealthEvent(Character character)
    {
        var percentage = character.currentHealth / character.maxHealth;
        playerStatBar.OnHealthChange(percentage);
    }
}

