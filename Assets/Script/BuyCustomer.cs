public sealed class BuyCustomer : Customer
{
    public BuyCustomer(
        int customerId,
        Item item,
        int askingPrice,
        int acceptablePrice)
        : base(customerId, item, askingPrice, acceptablePrice)
    {
    }

    public override bool Tradable(int playerOffer)
    {
        return playerOffer <= _acceptablePrice;
    }
}
