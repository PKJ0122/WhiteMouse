using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerManager : SingletonMono<CustomerManager>
{
    TradeState _currentTradeState;

    public event Action<List<Customer>> OnCustomerListChanged;

    CustomerKindProbabilityDatas _currentCustomerKindProbabilityDatas;

    void Start()
    {
        _currentCustomerKindProbabilityDatas = Resources.Load<CustomerKindProbabilityDatas>("CustomerKindProbabilityDatas");
    }

    void CreateCustomer()
    {
        CustomerKind customerKind = RandomCustomerKind();
    }

    CustomerKind RandomCustomerKind()
    {
        float maxProbabilitynNum = _currentCustomerKindProbabilityDatas.MaxProbabiliNum;
        float randomNum = Random.Range(0, maxProbabilitynNum);
        float beforeProbability = 0;
        float currentProbability = 0;
        CustomerKind customerKind = CustomerKind.Seller;

        foreach (var item in _currentCustomerKindProbabilityDatas.customerKindProbabilityDatas)
        {
            currentProbability += item.probability;

            if (beforeProbability <= randomNum &&
                randomNum < currentProbability)
            {
                customerKind = item.customerKind;
                break;
            }

            beforeProbability += item.probability;
        }

        return customerKind;
    }
}