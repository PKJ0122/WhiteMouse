using System.Collections.Generic;
using UnityEngine;

public class CustomerDatas : ScriptableObject
{
    [SerializeField] CustomerData[] _customerDatas;
    public CustomerData[] CustomerDataList => _customerDatas;

    Dictionary<int, CustomerData> _customerDataDic;
    public IReadOnlyDictionary<int, CustomerData> CustomerDataDic
    {
        get
        {
            if (_customerDataDic == null)
            {
                _customerDataDic = new();
                foreach (var item in _customerDatas)
                {
                    if (!_customerDataDic.TryAdd(item.CustomerId, item))
                    {
                        Debug.LogWarning("CustomerDatas Dic Warning");
                    }
                }
            }

            return _customerDataDic;
        }
    }
}
