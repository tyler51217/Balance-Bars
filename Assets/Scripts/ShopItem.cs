using UnityEngine;

[CreateAssetMenu(fileName ="ShopItem", menuName ="ScriptableObjects/ShopItem")]
public class ShopItem : ScriptableObject
{
    public int id;
    public int cost;
    public new string name;
    public bool owned;
    public Sprite sprite;




}
