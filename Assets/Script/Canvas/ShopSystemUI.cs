using DG.Tweening;
using UnityEngine;

public class ShopSystemUI : UIBase
{
    const float DURATION = 0.5f;
    
    RectTransform _shopSystem;
    RectTransform _shopSystemLocation;


    protected override void Awake()
    {
        base.Awake();
        _shopSystem = transform.Find("Image - Shop").GetComponent<RectTransform>();
        _shopSystemLocation = transform.Find("Image - ShopLocation").GetComponent<RectTransform>();
    }

    public override void Show()
    {
        base.Show();
        _shopSystem.anchoredPosition = _shopSystemLocation.localPosition;
        _shopSystem.DOAnchorPos(Vector2.zero, DURATION);
    }

    public override void Hide()
    {
        base.Hide();
        _shopSystem.DOAnchorPos(_shopSystemLocation.localPosition, DURATION);
    }
}
