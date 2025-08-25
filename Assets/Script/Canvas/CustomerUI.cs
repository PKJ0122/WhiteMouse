using UnityEngine;

public class CustomerUI : UIBase
{
    public RectTransform customerLocation;
    public RectTransform stratLocation;
    public RectTransform endLocation;


    protected override void Awake()
    {
        base.Awake();
        customerLocation = transform.Find("CustomerLocation").GetComponent<RectTransform>();
        stratLocation = transform.Find("StartLocation").GetComponent<RectTransform>();
        endLocation = transform.Find("EndLocation").GetComponent<RectTransform>();
    }
}