using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coins;
    //public List<ShopItem> ownedShopItems; //perhaps a list of all the shop items the player owns
    public ActiveSkins activeSkins; //currently selected asset(s)
    public List<int> ownedShopIDs;

    public GameData()
    {
        this.activeSkins = new ActiveSkins();
        this.coins = 0;
        //this.ownedShopItems = new List<ShopItem>();
        this.ownedShopIDs = new List<int>();
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