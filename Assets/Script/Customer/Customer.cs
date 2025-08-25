using UnityEngine;

public class Customer : PoolObject
{
    const float MIN_RUNSTATE_AMOUNT = 0f;
    const float MAX_RUNSTATE_AMOUNT = 0.2f;

    private CustomerData _customerData;
    public CustomerData CustomerData
    {
        get => _customerData;
        set => _customerData = value;
    }

    public NPCState NPCState
    {
        get => CustomerData.NPCState;
        set => CustomerData.NPCState = value;
    }

    RectTransform _rect;
    public RectTransform Rect => _rect;


    Animator _animator;


    public void Awake()
    {
        _animator = transform.Find("UnitRoot").GetComponent<Animator>();
        _rect = GetComponent<RectTransform>();
    }

    public void SetRunState(float amount)
    {
        float stateAmount = Mathf.Lerp(MIN_RUNSTATE_AMOUNT, MAX_RUNSTATE_AMOUNT, amount);
        _animator.SetFloat("RunState", stateAmount);
    }

    public NPCState TalkToCustomer(bool passCustomer)
    {
        if (passCustomer)
        {
            NPCState = NPCState.Leave;
        }
        else
        {
            NPCState = NPCState.PriceRefusal;
        }

        return NPCState;
    }

    public NPCState TalkToCustomer(long proposalPrice)
    {
        bool dealSuccess = false;
        long allowedAmount = (long)(CustomerData.FirstProposalPrice * CustomerData.NegotiableValue);
        long allowedPrice = 0;

        if (CustomerData.CustomerCategory == CustomerCategory.Seller)
        {
            allowedPrice = CustomerData.FirstProposalPrice - allowedAmount;

            if (allowedPrice <= proposalPrice)
            {
                dealSuccess = true;
            }
        }
        else if (CustomerData.CustomerCategory == CustomerCategory.Buyer)
        {
            allowedPrice = CustomerData.FirstProposalPrice + allowedAmount;

            if (allowedPrice >= proposalPrice)
            {
                dealSuccess = true;
            }
        }

        if (dealSuccess)
        {
            NPCState = NPCState.DealSuccess;
        }
        else
        {
            if (--CustomerData.Patience <= 0)
            {
                NPCState = NPCState.DealFail;
                return NPCState;
            }

            float randomNumber = Random.Range(0.2f, 1f);
            long nextPrice = Lerp(CustomerData.ProposalPrice, allowedPrice, randomNumber);

            CustomerData.ProposalPrice = nextPrice;
        }

        return NPCState;
    }

    long Lerp(long num1, long num2, float amount)
    {
        long min = 0;
        long max = 0;

        if (num1 <= num2)
        {
            min = num1;
            max = num2;
        }
        else
        {
            min = num2;
            max = num1;
        }

        long difference = (long)((max - min) * amount);

        return min + difference;
    }
}
