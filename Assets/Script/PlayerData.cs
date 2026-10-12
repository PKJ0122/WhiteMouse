using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData : Singleton<PlayerData>
{
    #region CustomerSavaDatas
    public CustomerSaveData[] CustomerSaveDatas;

    Dictionary<int, CustomerSaveData> _customerSaveDataDic;
    public Dictionary<int, CustomerSaveData> CustomerSaveDataDic
    {
        get
        {
            if (_customerSaveDataDic == null)
            {
                _customerSaveDataDic = new ();

                if (CustomerSaveDatas != null)
                {
                    foreach (var data in CustomerSaveDatas)
                    {
                        if (!_customerSaveDataDic.TryAdd(data.Id, data))
                        {
                            Debug.LogError("CustomerSaveData Add Fail");
                        }
                    }
                }
            }

            return _customerSaveDataDic;
        }
    }
    #endregion
}
