using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public static class ItemManager
{
    static ItemDatas s_itemDatas;
    static RarityProbabillityDatas s_rarityProbabillity;

    static Dictionary<ItemRarity, float> s_rarityProbabillityDic;
    static int s_lastCustmerLevel = -1;
    static float s_maxNum;

    public static Item CreateItem()
    {
        return new Item();
    }

    static ItemData RandomItemKind()
    {
        int maxProbabilitynNum = s_itemDatas.ItemDataDic.Count;
        int randomNum = Random.Range(0, maxProbabilitynNum);

        ItemData randomItemData = s_itemDatas.ItemDataDic.ElementAt(randomNum).Value;

        return randomItemData;
    }

    static ItemRarity RandomRarity(int level)
    {
        if (level == 0)
        {
            Debug.LogWarning("level is not Zero");
            return ItemRarity.None;
        }

        if (s_rarityProbabillityDic == null)
        {
            s_rarityProbabillityDic = new();

            foreach (var item in s_rarityProbabillity.rarityProbabillityDatas)
            {
                if (!s_rarityProbabillityDic.TryAdd(item.itemRarity, 0))
                {
                    Debug.LogWarning("ItemRarity Data Warning");
                }
            }
        }

        if (level != s_lastCustmerLevel)
        {
            s_lastCustmerLevel = level;
            s_maxNum = 0;

            RarityProbabillityData[] rarityProbabillityDatas = s_rarityProbabillity.rarityProbabillityDatas;

            float t = Mathf.InverseLerp(1, 100, level);

            foreach (var item in rarityProbabillityDatas)
            {
                float currentProbabillity = Mathf.Lerp(item.MinLevelRarityProbabillity, item.MaxLevelRarityProbabillity, t);
                s_maxNum += currentProbabillity;
                s_rarityProbabillityDic[item.itemRarity] = currentProbabillity;
            }
        }

        float randomNum = Random.Range(0, s_maxNum);
        float currentProbability = 0;
        ItemRarity itemRarity = ItemRarity.None;

        foreach (var item in s_rarityProbabillityDic)
        {
            currentProbability += item.Value;

            if (randomNum < currentProbability)
            {
                itemRarity = item.Key;

                break;
            }
        }

        if (itemRarity == ItemRarity.None)
        {
            Debug.LogWarning("itemRarity is not None");
        }

        return itemRarity;
    }
}