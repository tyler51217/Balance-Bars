using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour, IDataPersistence
{

    private int coins;
    public Text coinsText;
    public ShopItem currentlySelected;
    public List<ShopItem> ownedShopItems = new List<ShopItem>();
    public void Start()
    {
        coinsText.text = coins.ToString() + " coins";
        
        
    }

    public void LoadData(GameData data)
    {
        this.coins = data.coins;
        this.ownedShopItems = data.ownedShopItems;
    }

    public void SaveData(ref GameData data)
    {
        data.coins = this.coins;
        data.ownedShopItems = this.ownedShopItems;
    }


    public void Purchase(ShopItem item) //probably needs a parameter for what to purchase
    {
        /*
        if (!item.owned)
        {
            item.owned = true;
            coins -= item.cost;
        }
        else
        {
            item.currentlySelected = true;
        }
        */
        bool a = false;
        for (int i = 0; i < ownedShopItems.Count; i++)
        {
            if (item == ownedShopItems[i])
            {
                Debug.Log("already own: " + item.name);
                a = true;
                break;
            }
            
        }
        if (a)
        {

        }
        else if(item.cost < coins)
        {
            Debug.Log("bought " + item.name + " for " + item.cost + " coins");
            coins -= item.cost;
            coinsText.text = coins.ToString() + " coins";
            item.owned = true;
            ownedShopItems.Add(item);
        }
        else
        {
            Debug.Log("cannot afford " + item.name);
        }


        

        


    }




}
