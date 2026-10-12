using UnityEngine;

public static class CustomerFactory
{
    public static Customer CreateCustomer(CustomerOrderForm customerOrderForm)
    {
        Customer customer = null;
        
        switch (customerOrderForm.CustomerKind)
        {
            case CustomerKind.Seller:
                break;
            case CustomerKind.Buyer:
                break;
        }

        return customer;
    }
}