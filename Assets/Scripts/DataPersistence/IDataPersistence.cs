using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence 
{
    /// <summary>
    ///  Start gets called before LoadData
    /// </summary>
    void LoadData(GameData data);

    void SaveData(ref GameData data);
}
