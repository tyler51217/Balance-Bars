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

    public void Start()
    {
        coinsText.text = coins.ToString() + " coins";
    }

    public void LoadData(GameData data)
    {
        Debug.Log("Shop load called");
        this.coins = data.coins;
        Shop.ownedShopIds = data.ownedShopIds;
    }

    public void SaveData(ref GameData data)
    {
        data.coins = this.coins;
        data.ownedShopIds = Shop.ownedShopIds;
    }

    public void PurchaseButton(ShopItem item)
    {
        if (item.owned)
        {
            SkinSaver.ebsn = item.name + "Button";
            return;
        }

        for (int i = 0; i < ownedShopIds.Count; i++) 
        {
            if(item.id == ownedShopIds[i])
            {
                item.owned = true;
            }
        }

        if (item.cost <= this.coins)
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
        for (int i = 0; i < ownedShopIds.Count; i++)
        {
            if (item.id == ownedShopIds[i])
            {
                item.owned = true;
            }
        }

        if (item.owned)
        {
            SkinSaver.ecn = item.name + "Color";
        }


        else if (item.cost < this.coins)
        {
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
