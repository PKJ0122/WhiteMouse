using UnityEngine;

[CreateAssetMenu(fileName = "CustomerKindProbabilityDatas", menuName = "ScriptableObject/CustomerKindProbabilityDatas")]
public class CustomerKindProbabilityDatas : ScriptableObject
{
    public CustomerKindProbabilityData[] customerKindProbabilityDatas;

    float _maxProbabilitynNum = -1;
    public float MaxProbabiliNum
    {
        get
        {
            if (_maxProbabilitynNum == -1)
            {
                float temp = 0;

                foreach (var item in customerKindProbabilityDatas)
                {
                    temp += item.probability;
                }

                _maxProbabilitynNum = temp;
            }

            return _maxProbabilitynNum;
        }
    }
}
