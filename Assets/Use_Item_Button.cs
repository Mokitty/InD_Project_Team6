using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Item_Button : MonoBehaviour
{
    public static GameObject g_gclick_item; // 사용할 아이템
    int index;

    public void Use_Item()
    {

        g_gclick_item.GetComponent<Slot>().g_Ihave_item.ExecuteItem(index);
        g_gclick_item.GetComponent<Slot>().g_iitem_Number -= 1;
        g_gclick_item.GetComponent<Slot>().Refresh();
        if (g_gclick_item.GetComponent<Slot>().g_iitem_Number == 0)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

}
