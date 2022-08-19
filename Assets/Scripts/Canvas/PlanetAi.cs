using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetAi : MonoBehaviour
{
    [Header("Variables")]
    public int planetHealth;
    public int maxPlanetHealth = 100;
    public int minPlanetHealth = 0;
    
    [Header("Ui Components")]
    public Text planetHealthText;
    public Slider healthBar;
    public Image planetBar;

    public PartyBehaviour partyBehaviour;
    


    private void Start()
    {
        UpdateUI();
    }

    public void Damage(int damageAmount)
    {
        if (partyBehaviour.partyHealth - damageAmount < 0)
        {
            partyBehaviour.partyHealth = 0;
            partyBehaviour.IsDead();
        }
        planetHealth -= damageAmount;
        Debug.Log(planetHealth);
        UpdateUI();
    }

    public void Heal(int healAmount)
    {
        if (planetHealth + healAmount > maxPlanetHealth)
        {
            planetHealth = maxPlanetHealth;
        }
        Damage(-healAmount);
        UpdateUI();
    }

    public void UpdateUI()
    {
        planetHealthText.text = $"{planetHealth} :Health";
        healthBar.value = planetHealth;

        planetBar.color = Color.Lerp(Color.red, Color.green, (float)planetHealth/ maxPlanetHealth);
        if (planetHealth <= 0)
        {
            planetBar.gameObject.SetActive(false);
        }
        else
        {
            planetBar.gameObject.SetActive(true);
        }
        
    }

    public void Poison()
    {
        //damage over time/turns
    }

    public void Flee()
    {
        //enemy flees the fight/encounter and you go back to playing the game. 
        //then maybe the scene goes back to the ai fleeing hiding in the home and waiting 5 secoinds before coming out again.
        //if you can shoot them while they are harvesting "dark matter" then they go into smaller planets, if they can get close enough to the player then it starts the encounter
    }
}
