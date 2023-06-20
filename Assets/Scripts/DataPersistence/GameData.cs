using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coins;
    
    public List<int> ownedShopIds;
    public string equippedButtonSkinName;
    public string equippedColorName;

    public GameData()
    {
        this.coins = 0;
        this.ownedShopIds = new List<int>();
        this.equippedButtonSkinName = "SquareButton";
        this.equippedColorName = "BlackColor";
    }
}