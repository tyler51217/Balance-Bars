using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkinChanger : MonoBehaviour, IDataPersistence
{
    //might need a sprite renderer for the color
    public Button button;
    public SpriteRenderer fill;




    //get from json in load data
    public string buttonKey  = "";
    public string colorKey = "";

    void Start()
    {
        //Debug.Log("start from skin changer");
        //Start gets called before load, therefore we change the skins in load rather than start

    }

    private void setButtonSprite(AsyncOperationHandle<ShopItem> operation)
    {
        button.image.sprite = operation.Result.sprite;
        
    }

    private void setColorSprite(AsyncOperationHandle<ShopColor> operation)
    {
        fill.color = operation.Result.color;

    }

    public void LoadData(GameData data)
    {
        //Debug.Log("Load from skin changer");
        buttonKey = data.equippedButtonSkinName;
        colorKey = data.equippedColorName;

        var assetHandle = Addressables.LoadAssetAsync<ShopItem>(buttonKey);
        assetHandle.Completed += setButtonSprite;

        var assetHandle2 = Addressables.LoadAssetAsync<ShopColor>(colorKey);
        assetHandle2.Completed += setColorSprite;
    }

    public void SaveData(ref GameData data)
    {
        
    }
    

    
}
