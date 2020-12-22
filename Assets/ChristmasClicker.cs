using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChristmasClicker : MonoBehaviour
{


    public Text giftText; //Gift text
    public double gifts; //Gift amount
    public double giftsClickValue; //How many gifts getting per click
    public int clicks; // Physical clicks count

    public Text giftsPerSecText; //Automatic gift production per second text
    public Text clickUpgrade1Text; // Gift clicking upgrade text
    public Text elfUpgradeText; // Automatic gift production by Elves upgrade text
    public Text currentGiftsPerClick; // Shows how many gifts you make per click
    public Text reindeerUpgradeText; // Info about reindeer upgrade
    public Text santaUpgradeText; // Info about santa upgrade
    public Text achievementText; // Player statistics

    public double giftsPerSecond; // Gifts per second number

    public double clickUpgrade1Cost; // Cost of one clicking upgrade
    public int clickUpgrade1Level; // Current level of clicking
    public double clickUpgrade1Power; // Power given by next upgrade

    public double elfUpgradeCost; // Cost of one Elf upgrade
    public int elfUpgradeLevel; // Current level of Elves
    public double elfUpgradePower; // Power given by next upgrade

    public double reindeerUpgradeCost; // Cost of next reindeer upgrade
    public int reindeerUpgradeLevel; // Current reindeer upgrade level
    public double reindeerUpgradePower; // How much power does one upgrade give

    public double santaUpgradeCost; // Cost of next santa upgrade
    public int santaUpgradeLevel; // Current santa upgrade level
    public double santaUpgradePower; // How much power does one upgrade give

    public GameObject Panel; // Upgrades window

    public void Start()
    {

        giftsClickValue = 1;
        gifts = 0;
        clickUpgrade1Cost = 25;
        elfUpgradeCost = 100;
        reindeerUpgradeCost = 1000;
        santaUpgradeCost = 5000;
        clickUpgrade1Power = 1;
        elfUpgradePower = 1;
        reindeerUpgradePower = 50;
        santaUpgradePower = 150;

        
    }

    public void buttonClick() // Adds value of every gift click to gifts count
    {

        gifts += giftsClickValue;
        clicks++;

    }

    public void Update()
    {
        giftsPerSecond = (elfUpgradeLevel*elfUpgradePower) + (reindeerUpgradeLevel * reindeerUpgradePower) + (santaUpgradeLevel * santaUpgradePower);
        
        giftText.text = "Gifts: " + gifts.ToString("F0");
        currentGiftsPerClick.text = "Current gifts per click: " + giftsClickValue;
        elfUpgradeText.text = "Elf Upgrade\nCost: " + elfUpgradeCost.ToString("F0") + " gifts\nPower: +" + elfUpgradePower + " Gifts/s\nLevel: " + elfUpgradeLevel;

        giftsPerSecText.text = giftsPerSecond + " gifts/s"; 
        clickUpgrade1Text.text = "Click Upgrade\nCost: " + clickUpgrade1Cost.ToString("F0") + " gifts\nPower: +" + clickUpgrade1Power + " Gifts per click\nLevel: " + clickUpgrade1Level;

        reindeerUpgradeText.text = "Reindeer Upgrade\n Cost: " + reindeerUpgradeCost.ToString("F0") + " gifts\nPower: +" + reindeerUpgradePower + " Gifts/s\nLevel: " + reindeerUpgradeLevel;
        santaUpgradeText.text = "Santa Upgrade\n Cost: " + santaUpgradeCost.ToString("F0") + " gifts\nPower: +" + santaUpgradePower + " Gifts/s\nLevel: " + santaUpgradeLevel;

        achievementText.text = "Your statistics:\nClicks made all game: " + clicks + "\n";



        gifts += giftsPerSecond * Time.deltaTime;
        
        
    }

    

    public void buyClickUpgrade1() // Clicking upgrade method
    {

        if (gifts >= clickUpgrade1Cost)
        {
            clickUpgrade1Level++;
            gifts -= clickUpgrade1Cost;
            clickUpgrade1Cost *= 1.07;
            giftsClickValue++;
            if (clickUpgrade1Level == 50)
            {
                clickUpgrade1Power *= 1.5;
            }
        }
        
    }

    public void buyElfUpgrade1() // Elf upgrade method
    {

        if (gifts >= elfUpgradeCost)
        {
            elfUpgradeLevel++;
            gifts -= elfUpgradeCost;
            elfUpgradeCost *= 1.07;
            if (elfUpgradeLevel == 50)
            {
                elfUpgradePower *= 1.5;
            }
        }
        
    }

    public void buyReindeerUpgrade() // Reindeer upgrade method
    {
        if (gifts >= reindeerUpgradeCost)
        {
            reindeerUpgradeLevel++;
            gifts -= reindeerUpgradeCost;
            reindeerUpgradeCost *= 1.07;
            if (reindeerUpgradeLevel == 50)
            {
                reindeerUpgradePower *= 1.5;
            }
        }
    }

    public void buySantaUpgrade() // Santa upgrade method
    {
        if (gifts >= santaUpgradeCost)
        {
            santaUpgradeLevel++;
            gifts -= santaUpgradeCost;
            santaUpgradeCost *= 1.07;
            if (santaUpgradeLevel == 50)
            {
                santaUpgradePower *= 1.5;
            }
        }
    }

    public void SaveGame() // Game save method
    {
        saveToDB.SaveData(this);
    }

    public void LoadGame() // Game load method
    {
        LocalDB data = saveToDB.LoadData();

        gifts = data.gifts;
        clickUpgrade1Level = data.clickLevel;
        elfUpgradeLevel = data.elfLevel;
        reindeerUpgradeLevel = data.raindeerLevel;
        santaUpgradeLevel = data.santaLevel;
    }

}
