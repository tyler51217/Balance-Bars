using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coins;
    public List<string> ownedShopItems; //perhaps a list of all the shop items the player owns
    public ActiveSkins activeSkins; //currently selected asset(s)

    public GameData()
    {
        activeSkins = new ActiveSkins();
        this.coins = 0;
        
    }

    
    
}
/*

[System.Serializable]
public struct ActiveSkin
{
    public string heartSkin;
    public string fillSkin;
    public string topBottomSkin;
    public string buttonSkin;
    public string backgroundSkin;

}
*/