using UnityEngine;

public static class ItemFactory
{



    public static Item CreateItem(CustomerKind customerKind)
    {
        Item customer = null;


        switch (customerKind)
        {
            case CustomerKind.Seller:
                break;
            case CustomerKind.Buyer:
                break;
        }

        return customer;
    }

    static Item CreateSellerItem()
    {


        return null;
    }

    static Item CreateBuyerItem()
    {
        return null;
    }
}
