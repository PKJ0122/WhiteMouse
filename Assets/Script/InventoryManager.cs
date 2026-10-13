using System.Collections.Generic;

public class InventoryManager : Singleton<InventoryManager>
{
    public Item[] Inventory => PlayerData.Instance.Inventory;


}
