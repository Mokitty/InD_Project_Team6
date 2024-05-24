using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ȭ �� ĳ���� �ʻ�ȭ�� �����ϴ� ��ũ��Ʈ
public class TalkManager : MonoBehaviour
{
    // ��ȭ �����͸� ������ ��ųʸ�
    Dictionary<int, string[]> talkData;
    // ĳ���� �ʻ�ȭ�� ������ ��ųʸ�
    Dictionary<int, Sprite> portraitData;

    // �ʻ�ȭ ��������Ʈ �迭
    public Sprite[] portraitArr;

    // �ʱ�ȭ �Լ�
    void Awake()
    {
        // ��ųʸ����� �ʱ�ȭ
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        // ������ ���� �Լ� ȣ��
        GenerateData();
    }

    // ��ȭ �� �ʻ�ȭ ������ ���� �Լ�
    void GenerateData()
    {
      

        // ��ȭ ������ �߰�
        talkData.Add(1000, new string[] { "�ȳ�!:0", "������ �ݰ���!:0" });
        talkData.Add(2000, new string[] { "���!:0", "������ �ݰ���!:0" });

        // ������ ��ȭ ������ �߰�
        talkData.Add(10 + 100, new string[] { "�����Ɽ!!"});

        talkData.Add(10 + 200, new string[] {"������ õ�չ����� �ʹ� ���߾�..:0",
                                        "�ѹ��� �̷����� �����µ�, ����������?:0",
                                        "��ż��� ���ϽŰǰ�..? �ϴ� ������ �������߰ڴ�.:0" });

        talkData.Add(20 + 300, new string[] {"�� ���� �������ݾ�..?? ������ �� �̷� ����������?:0",
                                        "�̵��� ����.. �� �̰� ����?:0"});

        talkData.Add(20 + 400, new string[] {
                                        "�༮�� ������� �̰� �����°ǰ�?:0",
                                        "���� ��ģ�Ͱ��ס��ϴ� ȸ������߰ڴ�.:0", "" });

        talkData.Add(20 + 500, new string[] {
                                        "���� ���� ������ �����Ͱ���:0",
                                        "�ٵ� �� �������� �ʴ°���?:0",
                                        "(�������� ���� ������ �ٶ󺻴�.)",
                                        "�� ������ �ϰ���� ���� �ִ�?:0",
                                        "�ű��� �������.. ���� �¼��ϱ⵵ �ϰ�..:0",
                                        "�� �� ������ �Ǽ� ���� �Բ�����!:0",
                                        "(������ �ų��� ǰ������ �ȱ��.)",
                                        "�� �� ���±���? �ű��ϳ�, ���´� ���� ó���̾�!:0" });

        talkData.Add(600, new string[] { "�ϴ� ���� ����� �̸��� ������ �ִ� ��ż� ������ �����߰ھ�.:0",
                                        "��� ��ż��� ������..   �ƴ°� ���� ��ȭ�ϴ�:0",
                                        "�и� �̹��Ͽ� ���ؼ��� �˰������ž� �и���.:0" });

        talkData.Add(700, new string[] { "���ʿ� �ִ� ��¿����� ���� ������ ������ �Ҽ��ְ�,   �ѹ� ���ô� ������ ����� ���� �̵��Ҽ��־���?:0",
                                        "���߿� ��ȸ�� �Ǹ� �ѹ� ����� ����:0" });

        talkData.Add(30 + 800, new string[] { "�̸��� �����̸� �и� ���� ��� �̵��ϸ� �����?:0" });

        talkData.Add(30 + 1200, new string[] { "���Ⱑ �̸��� �����̱���..?:0",
                                                 "Ȯ���� ������ ����� ����:0"});

        talkData.Add(30 + 900, new string[] { "...�̸��� ������ �̷����� �������̾�..ó���˾Ҿ�.:0",
                                              "...!:0",
                                              "������.:0",
                                              "���, ���� �̻���.:0",
                                              "������ ���ε���...��ż����� �ʾ�!:0",
                                              "..!:0"  });

        talkData.Add(30 + 1300, new string[] { "��...�������� �̰��..:0",
                                              "��ġ�� �̰� ���� �̻���.:0",
                                              "��� ��ż���� �������� ������ŭ ��ī�Ӱ� �������� ���..:0",
                                              "�׷� Ʋ������. �̸��� �������� ����ž�!:0",
                                              "�ٸ� ��ż��鵵 ���� �������߰ھ�...!:0"  });

        talkData.Add(1100, new string[] { "�̸��� ������ �����̾���?:0","���� �̵�����!!:0" });




        talkData.Add(1500, new string[] { "��..�̸��� ������ �̷� ���������� �־��ٴ�, �Ƹ��ٿ�!:0",
                                            "����, ���۵� �Ȱ���. �̻��� ���� �ϰ��־�.:0",
                                            "����ü ���� ���ΰ���?:0",
                                            "������ �׷��� �����Ҷ��� �ƴϾ�.:0",
                                            "�� ���� ����!:0"});














        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "���:0",
                                            "�̸����� ���� ������ �ִٴµ�:0"
                                            ,"�˰��ִ�?:0" });

        talkData.Add(11 + 2000, new string[] { "���:0",
                                            "�ʵ� �̸����� ������ ���� �����ִ�?:0"
                                            ,"�˰������ ������ �ִ� ������ ã�ƿ���:0" });

        // ������ ����Ʈ ��� ----------------------------------
        talkData.Add(20 + 1000, new string[] { "�����ʿ� �ִ� ������� �̾߱�����:0" });
        talkData.Add(20 + 2000, new string[] { "ã���� �����ٸ�����:0" });
        talkData.Add(20 + 5000, new string[] { "������ �ݰ���.:0" });
        talkData.Add(21 + 2000, new string[] { "��������༭ ����:0" });

        // �ʻ�ȭ ������ �߰�
        portraitData.Add(100 + 0, portraitArr[0]);
        portraitData.Add(200 + 0, portraitArr[2]);
        portraitData.Add(300 + 0, portraitArr[2]);
        portraitData.Add(400 + 0, portraitArr[2]);
        portraitData.Add(500 + 0, portraitArr[2]);
        portraitData.Add(600 + 0, portraitArr[2]);
        portraitData.Add(700 + 0, portraitArr[2]);
        portraitData.Add(800 + 0, portraitArr[2]);
        portraitData.Add(900 + 0, portraitArr[2]);
        portraitData.Add(1100 + 0, portraitArr[2]);
        portraitData.Add(1200 + 0, portraitArr[2]);
        portraitData.Add(1300 + 0, portraitArr[2]);
        portraitData.Add(1500 + 0, portraitArr[2]);
        portraitData.Add(5000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 0, portraitArr[1]);
    }

    // ������ ��ȭ ID�� ��ȭ �ε����� �ش��ϴ� ��ȭ ��ȯ
    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                // ����Ʈ �� ó�� ��縶�� ���� �� �⺻ ��縦 ��ȯ�մϴ�.
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                // �ش� ����Ʈ ���� ���� ��簡 ���� �� ����Ʈ �� ó�� ��縦 ��ȯ�մϴ�.
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        // ��ȭ �ε����� ��ȭ ������ ���̿� ������ null�� ��ȯ�մϴ�.
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            // �׷��� ������ �ش� ��ȭ�� ��ȯ�մϴ�.
            return talkData[id][talkIndex];
        }
    }


    // ������ ID�� �ʻ�ȭ �ε����� �ش��ϴ� �ʻ�ȭ ��ȯ
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        // ID�� �ε����� ����Ͽ� �ʻ�ȭ ��ȯ
        return portraitData[id + portraitIndex];
    }
}
