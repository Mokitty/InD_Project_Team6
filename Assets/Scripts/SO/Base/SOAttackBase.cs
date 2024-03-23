using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOAttackBase : ScriptableObject , IAttackBehavior
{
    public GameManager.Type SkillType;
    public float m_fAttackMag;
    public string m_sAttackName;
    //������ ������ �������̽��� ScriptableObject�� ��ӹ��� SOBase �����Դϴ�.
    public abstract string ExecuteAttack(UnitEntity Atker, UnitEntity Defender);
}
