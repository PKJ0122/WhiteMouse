using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkDatas", menuName = "ScriptableObject/TalkDatas")]
public class TalkDatas : ScriptableObject
{
    [SerializeField] TalkData[] _datas;

    Dictionary<NPCState, TalkData> _talkData;

    public Dictionary<NPCState, TalkData> TalkData
    {
        get
        {
            if (_talkData == null)
            {
                _talkData = new Dictionary<NPCState, TalkData>();
                foreach (TalkData data in _datas)
                {
                    _talkData.Add(data.NPCState, data);
                }
            }

            return _talkData;
        }
    }
}