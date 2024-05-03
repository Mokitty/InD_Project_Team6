using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skill_Information_View : MonoBehaviour
{
    public GameObject view_Ob;
    public TextMeshProUGUI name_Text;
    public TextMeshProUGUI power_Text;
    public TextMeshProUGUI count_Text;
    public TextMeshProUGUI information_Text;

    public string ex_Name;
    public int ex_Power;
    public int ex_Count;
    public string ex_Information;

    public void Show_Information()
    {
        view_Ob.SetActive(true);
        view_Ob.transform.position = new Vector2(transform.position.x - 370, transform.position.y);
        name_Text.text = ex_Name;
        power_Text.text = "���ݷ� : " + ex_Power.ToString();
        count_Text.text = "��� �ִ� Ƚ�� " + ex_Count.ToString();


        string[] split_text;

        split_text = ex_Information.Split('.');

        for (int i = 0; i < split_text.Length; i++)
        {
            information_Text.text += split_text[i];
            information_Text.text += "\n";
        }

    }
    public void Off_Information()
    {
        view_Ob.SetActive(false);
        information_Text.text = " ";
    }
}
