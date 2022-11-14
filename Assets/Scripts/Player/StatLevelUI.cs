using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatLevelUI : MonoBehaviour
{
    public StarterAssets.ThirdPersonController controller;
    public PlayerStats playerStats;
    public Button confirmPlayerStatsButton;

    public int currentPlayerLevel;
    public int newPlayerLevel;
    public Text currentPlayerLevelText;
    public Text newPlayerLevelText;

    public Text currentSPText;
    public Text newSPText;
    public int baseStatUpCost = 3;
    private int spRequired;

    public Slider healthSlider;
    public Text currentHealthText;
    public Text newHealthText;

    public Slider strengthSlider;
    public Text currentStrengthText;
    public Text newStrengthText;

    public Slider defenseSlider;
    public Text currentDefenseText;
    public Text newDefenseText;

    //public Slider intelligenceSlider;
    //public Text currentIntelligenceText;
    //public Text newIntelligenceText;


    private void OnEnable()
    {
        currentPlayerLevel = playerStats.playerLevel;
        currentPlayerLevelText.text = currentPlayerLevel.ToString();

        newPlayerLevel = playerStats.playerLevel;
        newPlayerLevelText.text = newPlayerLevel.ToString();

        healthSlider.value = playerStats.healthLevel;
        healthSlider.minValue = playerStats.healthLevel;
        healthSlider.maxValue = 20;
        currentHealthText.text = playerStats.healthLevel.ToString();
        newHealthText.text = playerStats.healthLevel.ToString();

        strengthSlider.value = playerStats.strengthLevel;
        strengthSlider.minValue = playerStats.strengthLevel;
        strengthSlider.maxValue = 20;
        currentStrengthText.text = playerStats.strengthLevel.ToString();
        newStrengthText.text = playerStats.strengthLevel.ToString();

        defenseSlider.value = playerStats.defenseLevel;
        defenseSlider.minValue = playerStats.defenseLevel;
        defenseSlider.maxValue = 20;
        currentDefenseText.text = playerStats.defenseLevel.ToString();
        newDefenseText.text = playerStats.defenseLevel.ToString();

        //intelligenceSlider.value = playerStats.intelligenceLevel;
        //intelligenceSlider.minValue = playerStats.intelligenceLevel;
        //intelligenceSlider.maxValue = 30;
        //currentIntelligenceText.text = playerStats.intelligenceLevel.ToString();
        //newIntelligenceText.text = playerStats.intelligenceLevel.ToString();

        currentSPText.text = playerStats.spCount.ToString();

        UpdateProjectedPlayerLevel();
    }

    private void UpdateProjectedPlayerLevel()
    {
        spRequired = 0;

        newPlayerLevel = currentPlayerLevel;
        newPlayerLevel = newPlayerLevel + Mathf.RoundToInt(healthSlider.value) - playerStats.healthLevel;
        newPlayerLevel = newPlayerLevel + Mathf.RoundToInt(strengthSlider.value) - playerStats.strengthLevel;
        newPlayerLevel = newPlayerLevel + Mathf.RoundToInt(defenseSlider.value) - playerStats.defenseLevel;
        //newPlayerLevel = newPlayerLevel + Mathf.RoundToInt(intelligenceSlider.value) - playerStats.intelligenceLevel;
        newPlayerLevelText.text = newPlayerLevel.ToString();

        CalculateSPCost();
        newSPText.text = spRequired.ToString();

        if (playerStats.spCount < spRequired)
        {
            confirmPlayerStatsButton.interactable = false;
        }
        else
        {
            confirmPlayerStatsButton.interactable = true;
        }
    }

    private void CalculateSPCost()
    {
        for (int i = 0; i < newPlayerLevel; i++)
        {
            spRequired = spRequired + Mathf.RoundToInt((newPlayerLevel * baseStatUpCost) * 0.5f);
        }

    }

    public void UpdateHealthLevelSlider()
    {
        newHealthText.text = healthSlider.value.ToString();
        UpdateProjectedPlayerLevel();
    }

    public void UpdateStrengthLevelSlider()
    {
        newStrengthText.text = strengthSlider.value.ToString();
        UpdateProjectedPlayerLevel();
    }

    public void UpdateDefenseLevelSlider()
    {
        newDefenseText.text = defenseSlider.value.ToString();
        UpdateProjectedPlayerLevel();
    }

    //public void UpdateIntelligenceLevelSlider()
    //{
    //    newIntelligenceText.text = intelligenceSlider.value.ToString();
    //    UpdateProjectedPlayerLevel();
    //}

    public void ConfirmPlayerStats()
    {
        playerStats.playerLevel = newPlayerLevel;
        playerStats.healthLevel = Mathf.RoundToInt(healthSlider.value);
        playerStats.strengthLevel = Mathf.RoundToInt(strengthSlider.value);
        playerStats.defenseLevel = Mathf.RoundToInt(defenseSlider.value);
        //playerStats.intelligenceLevel = Mathf.RoundToInt(intelligenceSlider.value);

        playerStats.maxHealth = playerStats.SetMaxHealthFromHealthLevel();
        //playerStats.maxMana = playerStats.SetMaxManaFromHealthLevel();

        playerStats.attackDamage = playerStats.setAttackDamage();

        // Restore player's health to full each time level up
        playerStats.currentHealth = playerStats.maxHealth;
        playerStats.healthBar.SetMaxHealth(playerStats.maxHealth);

        playerStats.spCount = playerStats.spCount - spRequired;

        gameObject.SetActive(false);
        controller.StatsClosed();
    }
}
