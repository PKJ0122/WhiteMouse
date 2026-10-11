using System;
using System.Collections.Generic;

public class CustomerManager : Singleton<CustomerManager>
{
    TradeState _currentTradeState;

    readonly List<Customer> _customer;
    public event Action<List<Customer>> OnCustomerListChanged;


    void CreateCustomer()
    {

    }
}