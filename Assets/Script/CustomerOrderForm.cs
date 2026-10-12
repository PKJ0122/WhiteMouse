using UnityEngine;

public readonly struct CustomerOrderForm
{
    public CustomerKind CustomerKind { get; }
    public int CustomerId { get; }
    public int CustomerLevel { get; }

    public CustomerOrderForm(CustomerKind customerKind, int customerId, int customerLevel)
    {
        CustomerKind = customerKind;
        CustomerId = customerId;
        CustomerLevel = customerLevel;
    }
}
