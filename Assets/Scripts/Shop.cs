using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour, IDataPersistence
{

    private int coins;
    public Text coinsText;
    
    public static List<int> ownedShopIds;

    //public string equippedButtonSkinName;
    //public string equippedColorName;

    
    

    public void Start()
    {
        coinsText.text = coins.ToString() + " coins";
        //change all the owned shop buttons to say equip instead

        //read json and change the scriptable objects for their bool to be owned or not
        
        
    }

    public void LoadData(GameData data)
    {
        Debug.Log("Shop load called");
        this.coins = data.coins;
        Shop.ownedShopIds = data.ownedShopIds;
    }

    public void SaveData(ref GameData data) //WE MADE SKINSAVER AND THAT IS ON DATAPERSISTENCEMANAGER GAME OBJECT BECAUSE WE ONLY WANT TO MODIFY EQUIPPED SKINS ONCE, WHILE THEY
        //WERE ON THIS SHOP CLASS, ATTTACHED TO EVERY SHOPITEM, IT WOULD RUN SAVE MULTIPLE TIMES AND OVERWRITE ITS OWN DATA
    {
        data.coins = this.coins;
        ownedShopIds.Sort();
        ownedShopIds = ownedShopIds.Distinct().ToList();// remove duplicate check here

        data.ownedShopIds = Shop.ownedShopIds;

        //Debug.Log(equippedButtonSkinName);
        

        
        Debug.Log("Saved data from Shop");
        //data.equippedButtonSkinId = this.equippedButtonSkinId;
        //data.equippedColorId = this.equippedColourId;
        

    }



    public void PurchaseButton(ShopItem item)
    {
        

        //iterate through the owned shop items
        for (int i = 0; i < ownedShopIds.Count; i++)
        {
            if(item.id == ownedShopIds[i])
            {
                item.owned = true;
            }
        }

        

        if (item.owned)
        {
            //equip item here
            //equippedButtonSkinId = item.id;
            SkinSaver.ebsn = item.name + "Button";
            
            //need to change this to account for colours too, not just buttons

            //Debug.Log("equippedButtonSkinName is now " + equippedButtonSkinName);
            
        }
        

        else if (item.cost <= this.coins)
        {
            Debug.Log("You have purchased " + item.name);
            this.coins -= item.cost;
            item.owned = true;
            ownedShopIds.Add(item.id);
            coinsText.text = coins.ToString() + " coins";
            

        }
        else if (item.cost > this.coins)
        {
            Debug.Log("Cannot afford " + item.name);
        }
    }

    public void PurchaseColor(ShopColor item)
    {
        //iterate through the owned shop items
        for (int i = 0; i < ownedShopIds.Count; i++)
        {
            if (item.id == ownedShopIds[i])
            {
                item.owned = true;
            }
        }



        if (item.owned)
        {
            //equip item here
            //equippedButtonSkinId = item.id;
            SkinSaver.ecn = item.name + "Color";
            
            //need to change this to account for colours too, not just buttons
            //Debug.Log("equippedColorName is now " + equippedColorName);
        }


        else if (item.cost < this.coins)
        {
            Debug.Log("You have purchased " + item.name);
            this.coins -= item.cost;
            item.owned = true;
            ownedShopIds.Add(item.id);
            coinsText.text = coins.ToString() + " coins";


        }
        else if (item.cost > this.coins)
        {
            Debug.Log("Cannot afford " + item.name);
        }
    }




}
