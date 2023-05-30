using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{

    public ShopItem shopItem;

    public Text nameText;
    public Image img;
    public Text costText;
    //public int cost;
    public Text buttonText;
    //public List<int> ownedShopIds;

    
    void Start()
    {
        
        

        nameText.text = shopItem.name;
        costText.text = "Cost: " + shopItem.cost;
        img.sprite = shopItem.sprite;

        UpdateOwned();

    }

    public void UpdateOwned()
    {
        
        
        if (Shop.ownedShopIds.Contains(shopItem.id))
        {
            shopItem.owned = true;
        }

        if (shopItem.owned)
        {
            buttonText.text = "Equip";
        }
    }

    
    
    
    
}
