using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class InventorySaveLoad : MonoBehaviour
{
    public static void SaveInventory()
    {
        Dictionary<string, int> ItemSaveDic = new Dictionary<string, int>();

        foreach (Slot slot in Inventory_Controller.g_ICinstance.g_Sslot)
        {
            if (slot != null && slot.g_Ihave_item != null)
            {
                ItemEntity.ItemStats_Save itemStats = new ItemEntity.ItemStats_Save();
                ItemSaveDic.Add(slot.g_Ihave_item.m_sItemName, slot.g_iitem_Number); // ������ �̸� �߰�
                // ����� �α� ���
                Debug.Log("Added item: " + itemStats.m_sItemName + ", Count: " + itemStats.m_iItemCount);
            }
        }

        // itemStatsList�� ��� ���� Ȯ���Ͽ� �����Ͱ� �ִ��� Ȯ��
        Debug.Log("ItemStatsList Count: " + ItemSaveDic.Count);

        // ������ ������ ����ȭ�Ͽ� ���Ϸ� ����
        string path = Path.Combine(Application.persistentDataPath, "inventory_data.json");

        // JSON ���ڿ��� ����ȭ
        string json = JsonConvert.SerializeObject(ItemSaveDic, Formatting.Indented);

        // ���Ͽ� ����
        File.WriteAllText(path, json);

        // ����� �α׷� JSON ���
        Debug.Log("Serialized JSON: " + json);
    }

    public static void LoadInventory()
    {
        // ���Ͽ��� ����� ������ ������ȭ�Ͽ� �ҷ���
        string path = Path.Combine(Application.persistentDataPath, "inventory_data.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            // ����� �α׷� �ҷ��� JSON ���
            Debug.Log("Loaded JSON: " + json);

            Dictionary<string, int> tempDic = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);

            foreach(var item in tempDic)
            {
                GameObject entity = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/ItemEntity"));
                entity.transform.GetComponent<ItemEntity>().m_sItemName = item.Key;
                entity.transform.GetComponent<ItemEntity>().SetItemInfo();

                Inventory_Controller.g_ICinstance.Set_GetItem(entity);
                Inventory_Controller.g_ICinstance.Check_Slot(item.Value);
                
                Debug.Log("Loaded Item:" + item.Key + "Amount:" + item.Value);
            }
        }
    }

}