public abstract class Customer
{
    public int CustomerId { get; }
    public Item Item { get; set; }
    public int AskingPrice { get; }

    protected readonly int _acceptablePrice;

    protected Customer(
        int customerId,
        Item item,
        int askingPrice,
        int acceptablePrice)
    {
        CustomerId = customerId;
        Item = item;
        AskingPrice = askingPrice;
        _acceptablePrice = acceptablePrice;
    }

    public abstract bool Tradable(int playerOffer);
}