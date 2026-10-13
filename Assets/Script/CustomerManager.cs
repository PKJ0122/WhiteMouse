using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerManager : Singleton<CustomerManager>
{
    public event Action<List<Customer>> OnCustomerListChanged;

    CustomerDatas _customerDatas;
    CustomerKindProbabilityDatas _currentCustomerKindProbabilityDatas;

    void Start()
    {
        _customerDatas = Resources.Load<CustomerDatas>("CustomerDatas");
        _currentCustomerKindProbabilityDatas = Resources.Load<CustomerKindProbabilityDatas>("CustomerKindProbabilityDatas");
    }

    void CreateCustomer()
    {
        CustomerKind customerKind = RandomCustomerKind();
        
        int customerId = RandomCustomerId();
        int customerLevel = GetTryCustomerLevelData(customerId);

        CustomerOrderForm customerOrderForm = new(customerKind,
                                                  customerId,
                                                  customerLevel);

        Customer customer = CustomerFactory.CreateCustomer(customerOrderForm);
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

    int RandomCustomerId()
    {
        int customerMaxCount = _customerDatas.CustomerDataList.Length;
        int randomCustomerNum = Random.Range(0, customerMaxCount);
        int randomCustomerId = _customerDatas.CustomerDataList[randomCustomerNum].CustomerId;

        return randomCustomerId;
    }

    int GetTryCustomerLevelData(int customerId)
    {
        return PlayerData.Instance.CustomerSaveDataDic.TryGetValue(customerId, out var data) ? data.Level : 1;
    }
}