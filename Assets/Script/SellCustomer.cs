public sealed class SellCustomer : Customer
{
    public SellCustomer(
        int customerId,
        int itemId,
        int askingPrice,
        int acceptablePrice)
        : base(customerId, itemId, askingPrice, acceptablePrice)
    {
    }

    public override bool Tradable(int playerOffer)
    {
        return playerOffer >= _acceptablePrice;
    }
}