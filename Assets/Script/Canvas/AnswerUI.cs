using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerUI : UIBase
{
    Button[] _answerButtons;
    Dictionary<Button, TMP_Text> _texts = new Dictionary<Button, TMP_Text>();


    protected override void Awake()
    {
        base.Awake();
        _answerButtons = transform.GetComponentsInChildren<Button>();
        foreach (Button item in _answerButtons)
        {
            item.gameObject.SetActive(false);
            TMP_Text text = item.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
            _texts.Add(item, text);
        }
    }

    public void Show(NPCState npcState)
    {
        base.Show();

        foreach (Button item in _answerButtons)
        {
            item.gameObject.SetActive(false);
            item.onClick.RemoveAllListeners();
        }

        if (npcState == NPCState.SellerGreet)
        {
            Button button = _answerButtons[0];
            button.gameObject.SetActive(true);
            _texts[button].text = "어떤 물건인가요?";
        }
        else if (npcState == NPCState.BuyerGreet)
        {
            Button button = _answerButtons[0];
            button.gameObject.SetActive(true);
            _texts[button].text = "어떤 물건인가요?";
        }
    }
}
