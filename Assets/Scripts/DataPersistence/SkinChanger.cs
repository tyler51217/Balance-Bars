using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkinChanger : MonoBehaviour, IDataPersistence
{
    public Button button;
    public SpriteRenderer fill;

    private string buttonKey  = "";
    private string colorKey = "";

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
