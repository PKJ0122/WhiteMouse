using DG.Tweening;
using UnityEngine;

public class DaySystemUI : UIBase
{
    const float LOCATION_AMOUNT = 2000;

    RectTransform _panel;


    protected override void Awake()
    {
        base.Awake();
        _panel = transform.Find("Panel").GetComponent<RectTransform>();
    }

    public override void Show()
    {
        base.Show();

        Vector2 v = new Vector2(0, LOCATION_AMOUNT);
        _panel.anchoredPosition -= v;
        _panel.DOAnchorPos(Vector2.zero, 0.5f);
    }
}