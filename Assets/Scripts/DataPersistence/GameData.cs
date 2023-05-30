using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coins;
    //public List<ShopItem> ownedShopItems; //perhaps a list of all the shop items the player owns
    
    public List<int> ownedShopIds;
    public string equippedButtonSkinName;
    public string equippedColorName;
    


    public GameData()
    {
        
        this.coins = 0;
        //this.ownedShopItems = new List<ShopItem>();


        this.ownedShopIds = new List<int>();

        this.equippedButtonSkinName = "SquareButton";
        this.equippedColorName = "BlackColor";
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