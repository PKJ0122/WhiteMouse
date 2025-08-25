using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdderUI : UIBase
{
    const float DURATION = 0.5f;
    const string C = "C";
    const string BACK_SPACE = "BACK_SPACE";
    const string DOUBLE_ZERO = "00";
    const long MAX_AMOUNT = 100000000000000;

    long _num;
    public long Num
    {
        get => _num;
        set
        {
            _num = value;
            _numText.text = value == 0 ? string.Empty : value.ToString("#,##0");
        }
    }

    RectTransform _hideLocation;
    RectTransform _adder;

    TMP_Text _numText;


    protected override void Awake()
    {
        base.Awake();
        _hideLocation = transform.Find("Panel/Image - AdderLocation").GetComponent<RectTransform>();
        _adder = transform.Find("Panel/Image - Adder").GetComponent<RectTransform>();

        for (int i = 0; i < 10; i++)
        {
            Button numButton = _adder.Find($"Button - {i}").GetComponent<Button>();
            int count = i;
            numButton.onClick.AddListener(() =>
            {
                AdderButtonClick(count.ToString());
            });
        }

        Button doubleZeroButton = _adder.Find("Button - 00").GetComponent<Button>();
        doubleZeroButton.onClick.AddListener(() =>
        {
            AdderButtonClick(DOUBLE_ZERO);
        });

        Button cButton = _adder.Find("Button - C").GetComponent<Button>();
        cButton.onClick.AddListener(() =>
        {
            AdderButtonClick(C);
        });

        Button backSpaceButton = _adder.Find("Button - BackSpace").GetComponent<Button>();
        backSpaceButton.onClick.AddListener(() =>
        {
            AdderButtonClick(BACK_SPACE);
        });

        Button okButton = _adder.Find("Button - OK").GetComponent<Button>();
        okButton.onClick.AddListener(() =>
        {
            ShopManager.Instance.TalkToCustomer(Num);
            Hide();
        });

        Button xButton = _adder.Find("Button - X").GetComponent<Button>();
        xButton.onClick.AddListener(() =>
        {
            Hide();
        });

        _numText = _adder.Find("Text (TMP) - AdderAmount").GetComponent<TMP_Text>();
    }

    public override void Show()
    {
        base.Show();
        _adder.anchoredPosition = _hideLocation.localPosition;
        _adder.DOAnchorPos(Vector2.zero, DURATION).Play();
        Num = 0;
    }

    public override void Hide()
    {
        base.Hide();
        _adder.DOAnchorPos(_hideLocation.localPosition, DURATION).Play();
    }

    bool AdderButtonClick(string kind)
    {
        long temporary = Num;
        bool inputSuccess = false;

        if (DOUBLE_ZERO.Equals(kind))
        {
            temporary *= 100;
            inputSuccess = MAX_AMOUNT > temporary;
            Num = inputSuccess ? temporary : Num;
            return inputSuccess;
        }

        if (int.TryParse(kind, out int num))
        {
            temporary = (temporary * 10) + num;
            inputSuccess = MAX_AMOUNT > temporary;
            Num = inputSuccess ? temporary : Num;
            return inputSuccess;
        }

        if (BACK_SPACE.Equals(kind))
        {
            int ones = (int)(Num % 10);
            Num = (Num - ones) / 10;
            return true;
        }

        if (C.Equals(kind))
        {
            Num = 0;
            return true;
        }

        return inputSuccess;
    }
}
