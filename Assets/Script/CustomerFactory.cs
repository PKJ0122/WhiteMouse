using UnityEngine;

public class CustomerFactory : Singleton<CustomerFactory>
{
    public Customer CreateCustomer(CustomerOrderForm customerOrderForm)
    {
        switch (customerOrderForm.CustomerKind)
        {
            case CustomerKind.Seller:
                return CreateSeller(customerOrderForm);

            case CustomerKind.Buyer:
                return CreateBuyer(customerOrderForm);
            default:
                Debug.LogError("Unknown CustomerKind");
                return null;
        }
    }

    Customer CreateSeller(CustomerOrderForm customerOrderForm)
    {
        SellCustomer customer = new(customerOrderForm.CustomerId,
                                    null,
                                    1,
                                    1);

        return customer;
    }

    Customer CreateBuyer(CustomerOrderForm customerOrderForm)
    {
        BuyCustomer customer = new(customerOrderForm.CustomerId,
                                    null,
                                    1,
                                    1);

        return customer;
    }
}