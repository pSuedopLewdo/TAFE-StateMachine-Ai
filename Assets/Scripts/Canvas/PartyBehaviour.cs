using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PartyBehaviour : MonoBehaviour
{
    #region Variables

    [Header("Health")] 
    public int partyHealth;
    public int maxPartyHealth = 100;
    public int minPartyHealth = 0;
    [Space(8)] [Header("Mana")] 
    public int mana;
    public int maxMana = 15;
    public int minMana = 0;
    [Space(8)] [Header("References")] public Slider healthBar;
    public Image partyBar;
    public Text manaText;
    public Text partyHealthText;
    public PlanetAi planetAi;
    public StateMachine stateMachine;

    [Space(8)] [Header("Custom Ability Stats")]
    public int abilityOneDamage;

    public int abilityTwoHeal;
    public int abilityThreeRestoreMana;
    public int abilityFourVenomDamage;

    #endregion


    private void Start()
    {
        UpdateHealth();
    }

    public void Damage(int damageAmount)
    {
        if (planetAi.isPlayersTurn == true)
            if (mana >= 2)
            {
                damageAmount = abilityOneDamage;
                if (planetAi.planetHealth - damageAmount <= 0)
                {
                    planetAi.planetHealth = 0;
                    BattleOver();
                }

                planetAi.planetHealth -= damageAmount;
                mana -= 3;
                planetAi.isPlayersTurn = false;
                UpdateHealth();
            }
    }

    public void Heal(int healAmount)
    {
        if (planetAi.isPlayersTurn == true)
            if (mana > 6 && partyHealth < maxPartyHealth)
            {
                healAmount = abilityTwoHeal;

                if (partyHealth + healAmount > maxPartyHealth) partyHealth = maxPartyHealth;
                mana -= 5;
                planetAi.isPlayersTurn = false;
                UpdateHealth();
            }
    }

    public void UpdateHealth()
    {
        //so that we arent the only ones updating when its our turn
        planetAi.UpdateUI();

        partyHealthText.text = $"Health: {partyHealth}";
        manaText.text = $"Mana: {mana}";

        healthBar.value = partyHealth;
        partyBar.color = Color.Lerp(Color.red, Color.green, (float) partyHealth / maxPartyHealth);
        if (partyHealth <= 0)
            partyBar.gameObject.SetActive(false);
        else
            partyBar.gameObject.SetActive(true);
    }

    public void IsDead()
    {
        Application.Quit();
    }

    public void Venom(int venomDamage)
    {
        if (planetAi.isPlayersTurn == true)
        {
        }

        venomDamage = abilityFourVenomDamage;
        //damage over time/turns DONT FORGET planetAI.planetHealth;
        //mana cost 12 or anything over base mana so cant be first ability and you have had to take some damage
    }

    public void RestoreMana(int restoreMana)
    {
        restoreMana = abilityThreeRestoreMana;
        if (planetAi.isPlayersTurn == true)
            if (mana < maxMana)
            {
                mana += restoreMana;
                planetAi.isPlayersTurn = false;
                UpdateHealth();
            }
    }

    public void BattleOver()
    {
        Debug.Log("You have slain an enemy");
        SceneManager.LoadScene(0);
        //ends the battle and retuns to the game
    }
}