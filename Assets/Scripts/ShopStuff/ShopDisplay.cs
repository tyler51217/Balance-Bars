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
    public Text buttonText;

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
            buttonText.text = "Equip";
        }
    }

    public void CheckEquipped()
    {
        if (Shop.ownedShopIds.Contains(shopItem.id))
        {
            if (SkinSaver.ecn == shopItem.name+"Color")
            {
                buttonText.text = "Equipped";
            }
        }
    }
    
    
    
}
