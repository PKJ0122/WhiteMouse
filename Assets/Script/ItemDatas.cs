using System.Collections.Generic;
using UnityEngine;

public class ItemDatas : ScriptableObject
{
    [SerializeField] Sprite[] sprites;

    Dictionary<int, ItemData> _itemDataDic;
    public IReadOnlyDictionary<int, ItemData> ItemDataDic
    {
        get
        {
            if (_itemDataDic == null)
            {
                _itemDataDic = new();

                // 리소시스에 있는 암호화한 엑셀파일 가져오는 코드


            }

            return _itemDataDic;
        }
    }
}
