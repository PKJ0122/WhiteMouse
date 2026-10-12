using UnityEngine;

public class ItemData
{
    public int ItemId;
    public string ItemName;
    public long[] ItemPrices;
    public Sprite ItemSprite;

    public ItemData(int itemId, string itemName, long[] itemPrices, Sprite itemSprite)
    {
        ItemId = itemId;
        ItemName = itemName;
        ItemPrices = itemPrices;
        ItemSprite = itemSprite;
    }
}
