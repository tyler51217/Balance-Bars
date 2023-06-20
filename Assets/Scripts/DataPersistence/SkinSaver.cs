using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSaver : MonoBehaviour, IDataPersistence
{

    public static string ebsn;
    public static string ecn;
    public void LoadData(GameData data)
    {
        Debug.Log("SkinSaver load called");
        SkinSaver.ebsn = data.equippedButtonSkinName;
        SkinSaver.ecn = data.equippedColorName;
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("SkinSaver save called");
        data.equippedButtonSkinName = SkinSaver.ebsn;
        data.equippedColorName = SkinSaver.ecn;
    }

    
}
