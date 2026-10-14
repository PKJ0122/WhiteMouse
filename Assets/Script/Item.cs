using UnityEngine;

public class Item
{
    public Item(ItemData itemData, ItemRarity itemRarity, int durability)
    {
        _itemData = itemData;
        _itemRarity = itemRarity;
        _durability = durability;
    }

    ItemData _itemData;
    ItemRarity _itemRarity;
    int _durability;

    public ItemData ItemData => _itemData;
    public ItemRarity ItemRarity => _itemRarity;
    public int Durability => _durability;
}
