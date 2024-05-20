using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class InventorySaveLoad : MonoBehaviour
{
    public static void SaveInventory()
    {
        List<ItemEntity.ItemStats_Save> itemStatsList = new List<ItemEntity.ItemStats_Save>();

        foreach (Slot slot in Inventory_Controller.g_ICinstance.g_Sslot)
        {
            if (slot != null && slot.g_Ihave_item != null)
            {
                ItemEntity.ItemStats_Save itemStats = new ItemEntity.ItemStats_Save();
                itemStats.m_sItemName = slot.g_Ihave_item.m_sItemName; // ������ �̸� �߰�
                itemStats.m_iItemCount = slot.g_iitem_Number;
                itemStatsList.Add(itemStats);
                // ����� �α� ���
                Debug.Log("Added item: " + itemStats.m_sItemName + ", Count: " + itemStats.m_iItemCount);
            }
        }

        // itemStatsList�� ��� ���� Ȯ���Ͽ� �����Ͱ� �ִ��� Ȯ��
        Debug.Log("ItemStatsList Count: " + itemStatsList.Count);

        // ������ ������ ����ȭ�Ͽ� ���Ϸ� ����
        string path = Path.Combine(Application.persistentDataPath, "inventory_data.json");

        // JSON ���ڿ��� ����ȭ
        string json = JsonConvert.SerializeObject(itemStatsList, Formatting.Indented);

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

            ItemEntity.ItemStats_Save[] itemStatsArray = JsonConvert.DeserializeObject<ItemEntity.ItemStats_Save[]>(json);

            // g_ginventory ������Ʈ�� �ڽ� ���� ���� �����ͼ� �迭�� ���� ����
            int slotCount = Inventory_Controller.g_ICinstance.g_ginventory.transform.childCount;
            Slot[] slots = new Slot[slotCount];
            for (int i = 0; i < slotCount; i++)
            {
                slots[i] = Inventory_Controller.g_ICinstance.g_ginventory.transform.GetChild(i).GetComponent<Slot>();
            }

            for (int i = 0; i < itemStatsArray.Length; i++)
            {
                ItemEntity.ItemStats_Save itemStats = itemStatsArray[i];
                Slot slot = slots[i % slotCount]; // ���� ��ȯ�� ���� ������ ���� ���

                // ������ ������ŭ �������� �����Ͽ� ���Կ� �߰�
                for (int j = 0; j < itemStats.m_iItemCount; j++)
                {
                    Debug.Log("Calling Input_Item method for slot " + i);
                    CreateItemAndAddToSlot(itemStats, slot); // ������ ������Ʈ ���� �� ���Կ� �߰�
                }
            }
        }
    }

    private static void CreateItemAndAddToSlot(ItemEntity.ItemStats_Save itemStats, Slot slot)
    {
        // Resources �������� ������ ������ �ε�
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/" + "ItemEntity");

        // �ε�� �������� �ν��Ͻ�ȭ�Ͽ� ������ ������Ʈ ����
        GameObject itemObject = Instantiate(itemPrefab);
        itemObject.GetComponent<ItemEntity>().m_sItemName = itemStats.m_sItemName;
        itemObject.GetComponent<ItemEntity>().SetItemInfo();
        // ������ ������ ������Ʈ�� ��Ȱ��ȭ
        itemObject.SetActive(false);

        // �ν��Ͻ�ȭ�� ������ ������Ʈ���� ItemEntity ������Ʈ ��������
        ItemEntity itemEntity = itemObject.GetComponent<ItemEntity>();

        // ItemEntity ������Ʈ�� �Ӽ� ����
        itemEntity.m_sItemName = itemStats.m_sItemName;

        // ���Կ� ������ �߰�
        slot.Input_Item(itemEntity, 1); // �� �������� 1���� ������
    }

}