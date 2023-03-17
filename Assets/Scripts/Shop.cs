using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour, IDataPersistence
{

    private int coins;
    public Text coinsText;
    public ShopItem currentlySelected;
    public void Start()
    {
        coinsText.text = coins.ToString() + " coins";
        
        
    }

    public void LoadData(GameData data)
    {
        this.coins = data.coins;
    }

    public void SaveData(ref GameData data)
    {
        data.coins = this.coins;
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
        if (item.owned)
        {
            Debug.Log("already own: " + item.name);
            return;
        }

        if(item.cost < coins)
        {
            Debug.Log("bought " + item.name + " for " + item.cost + " coins");
            coins -= item.cost;
            coinsText.text = coins.ToString() + " coins";
            item.owned = true;
        }
        else
        {
            Debug.Log("cannot afford " + item.name);
        }

        


    }




}
