using System.Collections.Generic;

public class GameData
{
    public GameState GameState = GameState.None;
    public int Year = 1;
    public int Month = 1;
    public int Day = 1;
    public long Gold = 1000;
    public List<CustomerData> CustomerDatas = new List<CustomerData>();
}