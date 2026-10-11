public abstract class Customer
{
    public int CustomerId { get; }
    public int ItemId { get; }
    public int AskingPrice { get; }

    protected readonly int _acceptablePrice;

    protected Customer(
        int customerId,
        int itemId,
        int askingPrice,
        int acceptablePrice)
    {
        CustomerId = customerId;
        ItemId = itemId;
        AskingPrice = askingPrice;
        _acceptablePrice = acceptablePrice;
    }

    public abstract bool Tradable(int playerOffer);
}