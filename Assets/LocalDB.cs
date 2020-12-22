using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocalDB
{
    // Start is called before the first frame update

    public double gifts;
    public int clickLevel;
    public int elfLevel;
    public int raindeerLevel;
    public int santaLevel;

    public LocalDB(ChristmasClicker game)
    {
        gifts = game.gifts;
        clickLevel = game.clickUpgrade1Level;
        elfLevel = game.elfUpgradeLevel;
        raindeerLevel = game.reindeerUpgradeLevel;
        santaLevel = game.santaUpgradeLevel;
    }
    
}
