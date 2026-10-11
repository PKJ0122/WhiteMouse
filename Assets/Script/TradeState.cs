public class TradeState
{
    public Customer Customer { get; private set; }
    public string CurrentTextState { get; private set; }


    public TradeState(Customer customer, string currentTextState)
    {
        Customer = customer;
        CurrentTextState = currentTextState;
    }

    public void ChangeTextState(string text)
    {
        CurrentTextState = text;
    }
}
