using System.Collections.Generic;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<Item> Inventory => PlayerData.Instance.Inventory;


}
