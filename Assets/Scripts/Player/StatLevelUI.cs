using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatLevelUI : MonoBehaviour
{
    public PlayerStats playerStats;

    public int currentPlayerLevel;
    public int newPlayerLevel;
    public Text currentPlayerLevelText;
    public Text newPlayerLevelText;

    public Text currentSPText;
    public Text newSPText;

    public Button healthButton;
    public Text currentHealthText;
    public Text newHealthText;

    public Button strengthButton;
    public Text currentStrengthText;
    public Text newStrengthText;

    public Button defenseButton;
    public Text currentDefenseText;
    public Text newDefenseText;

    public Button intelligenceButton;
    public Text currentIntelligenceText;
    public Text newIntelligenceText;

    private void OnEnable()
    {
        currentPlayerLevel = playerStats.playerLevel;
        currentPlayerLevelText.text = currentPlayerLevel.ToString();

        newPlayerLevel = playerStats.playerLevel;
        newPlayerLevelText.text = newPlayerLevel.ToString();

        currentHealthText.text = playerStats.healthLevel.ToString();
        newHealthText.text = playerStats.healthLevel.ToString();

        currentStrengthText.text = playerStats.strengthLevel.ToString();
        newStrengthText.text = playerStats.strengthLevel.ToString();

        currentDefenseText.text = playerStats.defenseLevel.ToString();
        newDefenseText.text = playerStats.defenseLevel.ToString();

        currentIntelligenceText.text = playerStats.intelligenceLevel.ToString();
        newIntelligenceText.text = playerStats.intelligenceLevel.ToString();
    }
}
