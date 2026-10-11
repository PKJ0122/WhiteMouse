using UnityEngine;

public static class CustomerFactory
{
    public static Customer CreateCustomer(CustomerKind customerKind)
    {
        Customer customer = null;

        switch (customerKind)
        {
            case CustomerKind.Seller:
                break;
            case CustomerKind.Buyer:
                break;
        }

        return customer;
    }
}