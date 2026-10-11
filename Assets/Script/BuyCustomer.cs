public sealed class BuyCustomer : Customer
{
    public BuyCustomer(
        int customerId,
        int itemId,
        int askingPrice,
        int acceptablePrice)
        : base(customerId, itemId, askingPrice, acceptablePrice)
    {
    }

    public override bool Tradable(int playerOffer)
    {
        return playerOffer <= _acceptablePrice;
    }
}
