using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : UIBase
{
    Button _newGame;

    protected override void Awake()
    {
        base.Awake();
        _newGame = transform.Find("Button - NewGame").GetComponent<Button>();
        _newGame.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }
}
