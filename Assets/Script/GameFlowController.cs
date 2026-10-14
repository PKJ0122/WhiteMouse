using System.Collections;
using UnityEngine;

public class GameFlowController : SingletonMono<GameFlowController>
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            Customer customer = CustomerManager.Instance.CreateCustomer();
             
            // º’¥‘ ¿‘¿Â ¿Ã∆Â∆Æ



            yield return null;
        }
    }
}
