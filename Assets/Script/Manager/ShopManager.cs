using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class ShopManager : Singleton<ShopManager>
{
    TalkDatas _talkDatas;

    Customer _currentCustomer;
    public Customer CurrentCustomer
    {
        get => _currentCustomer;
        set => _currentCustomer = value;
    }

    CustomerUI _customerUI;
    TalkUI _talkUI;
    AnswerUI _answerUI;

    Stack<CustomerData> _customerData = new Stack<CustomerData>();
    public Stack<CustomerData> CustomerData
    {
        get => _customerData;
        set => _customerData = value;
    }


    protected override void Awake()
    {
        base.Awake();
        _talkDatas = (TalkDatas)Resources.Load("TalkDatas");
    }

    private void Start()
    {
        _customerUI = UIManager.Instance.Get<CustomerUI>();
        _talkUI = UIManager.Instance.Get<TalkUI>();
        _answerUI = UIManager.Instance.Get<AnswerUI>();
    }

    public void CustomerInStore()
    {
        Customer customer = _customerUI.transform.Find("Human16").GetComponent<Customer>();
        CurrentCustomer = customer;
        RectTransform rect = CurrentCustomer.Rect;

        float duration = 2f;
        float insertTime = 1.5f;

        NPCState npcState = CurrentCustomer.NPCState;

        Sequence inStoreSequence = DOTween.Sequence();
        inStoreSequence.OnStart(() =>
        {
            rect.anchoredPosition = _customerUI.stratLocation.localPosition;
            CurrentCustomer.SetRunState(1f);
        });
        inStoreSequence.Join(rect.DOAnchorPos(_customerUI.customerLocation.anchoredPosition, duration));
        inStoreSequence.Insert(insertTime, DOTween.To(() => 1f, x => CurrentCustomer.SetRunState(x), 0f, duration - insertTime));
        inStoreSequence.Play().onComplete += () =>
        {
            Sequence actingSequence = DOTween.Sequence();
            _talkUI.Show(TalkDtail(npcState), actingSequence);
            actingSequence.Play().onComplete += () =>
            {
                _answerUI.Show(npcState);
            };
        };
    }

    public void TalkToCustomer(bool passCustomer)
    {
        CurrentCustomer.TalkToCustomer(passCustomer);
    }

    public void TalkToCustomer(long proposalPrice)
    {
        CurrentCustomer.TalkToCustomer(proposalPrice);
    }

    string TalkDtail(NPCState npcState)
    {
        TalkData talkData = _talkDatas.TalkData[npcState];
        int talkDataCount = talkData.Details.Count;
        string talkDtail = talkData.Details[Random.Range(0, talkDataCount)];

        return talkDtail;
    }

    void Talk()
    {
        NPCState npcState = CurrentCustomer.NPCState;

        Sequence actingSequence = DOTween.Sequence();
        _talkUI.Show(TalkDtail(npcState), actingSequence);
        actingSequence.Play().onComplete += () =>
        {
            _answerUI.Show(npcState);
        };
    }
}