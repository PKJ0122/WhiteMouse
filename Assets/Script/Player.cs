using UnityEngine.SceneManagement;

public class Player : Singleton<Player>
{
    SaveData _saveData;
    public SaveData SaveData
    {
        get
        {
            if (_saveData == null)
            {
                _saveData = new SaveData();
            }

            return _saveData;
        }
    }

    GameData _currentGameData;
    public GameData CurrentGameData
    {
        get => _currentGameData;
        set
        {
            _currentGameData = value;
        }
    }

    int _currentGameDataNum = -1;
    public int CurrentGameDataNum
    {
        get => _currentGameDataNum;
        set => _currentGameDataNum = value;
    }


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneUnloaded += (name) =>
        {

        };
    }
}