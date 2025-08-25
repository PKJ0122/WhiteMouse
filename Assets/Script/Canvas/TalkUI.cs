using DG.Tweening;
using TMPro;
using UnityEngine;

public class TalkUI : UIBase
{
    RectTransform bubbleRect;
    TMP_Text _detail;


    protected override void Awake()
    {
        base.Awake();
        bubbleRect = transform.Find("Image - SpeechBubble").GetComponent<RectTransform>();
        _detail = transform.Find("Image - SpeechBubble/Text (TMP) - Detail").GetComponent<TMP_Text>();
    }

    public void Show(string detail , Sequence sequence)
    {
        base.Show();
        bubbleRect.localScale = Vector3.zero;
        _detail.text = detail;
        sequence.Append(bubbleRect.DOScale(Vector3.one, 0.5f));
    }
}
