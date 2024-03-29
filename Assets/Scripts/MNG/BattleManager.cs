using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    // �÷��̾�� ���� ������
    public GameObject[] g_PlayerUnits;
    public GameObject g_EnemyUnit;
    public GameObject g_BattleButtons;
    // ���� ���¸� �����ϴ� ������
    public enum BattleState { START, ACTION, PLAYERTURN, PROCESS, ENEMYTURN, RESULT, END }

<<<<<<< Updated upstream
    // �÷��̾�� ���� �����ϴ� ��ġ
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public Transform waitStation;
=======
>>>>>>> Stashed changes

    private Coroutine BattleCoroutine;
    private bool isPlayed = false;
    private GameManager.Action m_ePlayerAction;
    private int m_iPlayerActionIndex;

    // ���� �÷��̾�� ���� ������ ��ũ��Ʈ
    public UnitEntity playerUnit;
    UnitEntity enemyUnit;

<<<<<<< Updated upstream
    // ���� �� �߻��ϴ� ��ȭ�� ǥ���ϴ� UI �ؽ�Ʈ
    public Text dialogueText;

    // �÷��̾�� ���� HUD(Head-Up Display)�� �����ϴ� ��ü
    public BattleHUDCTR playerHUD;
    public BattleHUDCTR enemyHUD;

    // ���� ����
=======
    //다이얼로그 텍스트
    public Text dialogueText;

  //플레이어와 적 UI
    public BattleHUDCTR playerHUD;
    public BattleHUDCTR enemyHUD;

    // 전투 상태
>>>>>>> Stashed changes
    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        BattleInit();
    }


<<<<<<< Updated upstream

    #region ���� ���� �޼���
    void BattleInit()
    {
        //�÷��̾� ���� �ʱ�ȭ
        //g_PlayerUnits = GameManager.Instance.m_UnitManager.g_PlayerUnits;
        //�� ���� �ʱ�ȭ
        g_EnemyUnit = GameManager.Instance.m_UnitManager.SetUnitEntityByName("��������");

        
        state = BattleState.START;
        // ���� ���� ���·� �ʱ�ȭ�ϰ�, ������ �����ϴ� �ڷ�ƾ ����
=======
    #region 전투 메서드
    void BattleInit()
    {
        // 적 유닛 설정
        g_EnemyUnit = GameManager.Instance.m_UnitManager.SetUnitEntityByName(GameManager.Instance.g_sEnemyBattleUnit);
        state = BattleState.START;
>>>>>>> Stashed changes
        BattleCoroutine = StartCoroutine(SetupBattle());
    }


<<<<<<< Updated upstream



    // �÷��̾� �� ���� ó��   ----------------------------------------------------------------------------------------------------------------------
=======
>>>>>>> Stashed changes
    private void PlayerAction()
    {
        //플레이어 액션
        state = BattleState.ACTION;
<<<<<<< Updated upstream
        dialogueText.text = playerUnit.m_sUnitName + "�� ��� �� �� �ΰ�..";
    }
    #region �÷��̾� Action ó��
=======
        dialogueText.text = playerUnit.m_sUnitName + "는 무엇을 할까?";
    }
    #region 플레이어 액션 처리
>>>>>>> Stashed changes
    private void Process()
    {
        if (m_ePlayerAction == GameManager.Action.ATTACK)
            AttackProcess();
        else if (m_ePlayerAction == GameManager.Action.ITEM)
            ItemProcess();
        else if (m_ePlayerAction == GameManager.Action.CHANGE)
            ChangeProcess();
        else if (m_ePlayerAction == GameManager.Action.RUN)
            RunProcess();
    }
    private void AttackProcess()
    {
        if (state != BattleState.ENEMYTURN && state != BattleState.PLAYERTURN)
        {
            if (playerUnit.m_iUnitSpeed > enemyUnit.m_iUnitSpeed)
                BattleCoroutine = StartCoroutine(PlayerTurn_Attack());
            else if (playerUnit.m_iUnitSpeed < enemyUnit.m_iUnitSpeed)
                BattleCoroutine = StartCoroutine(EnemyTurn());
            else
            {
                if (playerUnit.m_iUnitLevel < enemyUnit.m_iUnitLevel)
                    StartCoroutine(EnemyTurn());
                else
                    StartCoroutine(PlayerTurn_Attack());
            }
        }
        else if (state == BattleState.ENEMYTURN)
            StartCoroutine(PlayerTurn_Attack());
        else if (state == BattleState.PLAYERTURN)
            StartCoroutine(EnemyTurn());
    }
    private void ItemProcess()
    {
        if (state != BattleState.PLAYERTURN)
            StartCoroutine(PlayerTurn_Item());
        else
            StartCoroutine(EnemyTurn());
    }
    private void ChangeProcess()
    {
        if (state != BattleState.PLAYERTURN)
            StartCoroutine(PlayerTurn_Change());
        else
            StartCoroutine(EnemyTurn());
    }
    private void RunProcess()
    {
        if (state != BattleState.PLAYERTURN)
            StartCoroutine(PlayerTurn_Item());
        else
            StartCoroutine(EnemyTurn());
    }

    #endregion


<<<<<<< Updated upstream
    // ���� ���� ó��
    void AfterWin()
    {
        state = BattleState.END;
        dialogueText.text = "�¸�!";
=======

    void AfterWin()
    {
        state = BattleState.END;
        dialogueText.text = "승리했다!";
        SceneManager.UnloadSceneAsync("BattleScene");
        GameManager.Instance.g_GameState = GameManager.GameState.INPROGRESS;

>>>>>>> Stashed changes
    }

    void AfterLost()
    {
        state = BattleState.END;
<<<<<<< Updated upstream
        dialogueText.text = ".......����� ������ ����������.";
=======
        dialogueText.text = "패배했다.";
        SceneManager.UnloadSceneAsync("BattleScene");
        GameManager.Instance.g_GameState = GameManager.GameState.INPROGRESS;
>>>>>>> Stashed changes
    }

    #endregion

<<<<<<< Updated upstream
    #region ���� ���� �ڷ�ƾ
    // ���� ������ ó���ϴ� �ڷ�ƾ
    IEnumerator SetupBattle()
    {
        // �÷��̾�� ���� ������ �����ϰ� ��ġ
        playerUnit = GameManager.Instance.m_UnitManager.g_PlayerUnits[0].transform.GetComponent<UnitEntity>();
        //UI�� �̹����� ��������Ʈ�� �����ϱ� ������ Station���� �����߽��ϴ�.
        //for(int i = 1; i< GameManager.Instance.m_UnitManager.g_PlayerUnits.Length;i++)
            //GameManager.Instance.m_UnitManager.g_PlayerUnits[i].transform.position = waitStation.position;
=======
    #region 전투 코루틴
    IEnumerator SetupBattle()
    {
        //플레이어 첫번째 유닛으로 설정, portrait 이미지 설정
        playerUnit = GameManager.Instance.m_UnitManager.g_PlayerUnits[0].transform.GetComponent<UnitEntity>();
>>>>>>> Stashed changes
        playerHUD.g_imagePortrait.sprite = playerUnit.m_spriteUnitImage;
        //적 유닛 설정, portrait 이미지 설정
        enemyUnit = g_EnemyUnit.GetComponent<UnitEntity>();
        enemyHUD.g_imagePortrait.sprite = enemyUnit.m_spriteUnitImage;

<<<<<<< Updated upstream
        // ��ȭ �ؽ�Ʈ�� ���� �̸��� ǥ��
        dialogueText.text = "�߻��� " + enemyUnit.m_sUnitName + " ��(��) ��Ÿ����...";

        // �÷��̾�� ���� HUD�� ������Ʈ
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        // ���� ���� �� ��� ���
        yield return new WaitForSeconds(2f);

        // �÷��̾� ������ ���� ��ȯ
        PlayerAction();
    }
    #region �÷��̾� Action ó��
=======
        dialogueText.text = enemyUnit.m_sUnitName + "가 나타났다!";

        //UI 설정
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        yield return new WaitForSeconds(2f);

        //액션 처리로 넘어감
        PlayerAction();
    }
    #region 플레이여 액션 처리부분
>>>>>>> Stashed changes
    IEnumerator PlayerTurn_Attack()
    {
        state = BattleState.PLAYERTURN;
        //���� ����
        playerUnit.AttackByIndex(playerUnit, enemyUnit, m_iPlayerActionIndex);
        enemyHUD.SetHP(enemyUnit.m_iCurrentHP);
        dialogueText.text = playerUnit.m_sUnitName + "�� " + playerUnit.GetSkillname(playerUnit,m_iPlayerActionIndex)+" ����!!";
        yield return new WaitForSeconds(1f);
        if (enemyUnit.m_iCurrentHP <= 0 || playerUnit.m_iCurrentHP <= 0)
            BattleCoroutine = StartCoroutine(Result());
        else if (!isPlayed)
            Process();
        else
            BattleCoroutine = StartCoroutine(Result());
        isPlayed = true;
    }
    IEnumerator PlayerTurn_Item()
    {
        state = BattleState.PLAYERTURN;

        playerUnit.Heal(5);

<<<<<<< Updated upstream
        // �÷��̾��� ü���� HUD�� ������Ʈ�ϰ� ��ȭ �ؽ�Ʈ ǥ��
        playerHUD.SetHP(playerUnit.m_iCurrentHP);
        dialogueText.text = "ü���� 5 ȸ���ߴ�!";
=======
        playerHUD.SetHP(playerUnit.m_iCurrentHP);
        dialogueText.text = "아이템 사용!";
>>>>>>> Stashed changes

        yield return new WaitForSeconds(2f);

        Process();
        isPlayed = true;
    }
    IEnumerator PlayerTurn_Change()
    {
        state = BattleState.PLAYERTURN;

<<<<<<< Updated upstream
        // �÷��̾� ��ü
        GameObject newPlayerGO = GameManager.Instance.m_UnitManager.g_PlayerUnits[m_iPlayerActionIndex];
        //playerUnit.transform.position = waitStation.position; // ���� �÷��̾� �̵�
        //newPlayerGO.transform.position = playerBattleStation.position;
        playerUnit = newPlayerGO.GetComponent<UnitEntity>();
        playerHUD.g_imagePortrait.sprite = playerUnit.m_spriteUnitImage;


        // �÷��̾��� ü���� HUD�� ������Ʈ
=======
        //플레이어 유닛에서 가져온 유닛으로 설정
        GameObject newPlayerGO = GameManager.Instance.m_UnitManager.g_PlayerUnits[m_iPlayerActionIndex];

        //스크립트를 지정하고 초기화
        playerUnit = newPlayerGO.GetComponent<UnitEntity>();
        playerHUD.g_imagePortrait.sprite = playerUnit.m_spriteUnitImage;

        
>>>>>>> Stashed changes
        playerHUD.SetHUD(playerUnit);
        yield return new WaitForSeconds(2f);

        Process();
        isPlayed = true;
    }
    #endregion

<<<<<<< Updated upstream
    // ���� ���� ó���ϴ� �ڷ�ƾ
=======
    //적 공격 처리
>>>>>>> Stashed changes
    IEnumerator EnemyTurn()
    {
        // 전투 상태 변경
        state = BattleState.ENEMYTURN;
<<<<<<< Updated upstream
        // ���� �����ϰ� ��ȭ �ؽ�Ʈ ������Ʈ
=======
        // 랜덤 인덱스로 공격 실행
>>>>>>> Stashed changes
        int randomAttackIndex = Random.Range(0, 2);
        enemyUnit.AttackByIndex(enemyUnit, playerUnit, randomAttackIndex);
        //텍스트 처리
        string AttackName = enemyUnit.GetSkillname(enemyUnit,randomAttackIndex);
        playerHUD.SetHP(playerUnit.m_iCurrentHP);
<<<<<<< Updated upstream
        dialogueText.text = enemyUnit.m_sUnitName + " �� " + AttackName + "����!";


        // �÷��̾ �������� �ް� ü�� ������Ʈ
=======
        dialogueText.text = enemyUnit.m_sUnitName + "의 " + AttackName + "공격!";
>>>>>>> Stashed changes

        yield return new WaitForSeconds(1f);
        //체력 검사 후 진행
        if (enemyUnit.m_iCurrentHP <= 0 || playerUnit.m_iCurrentHP <= 0)
            BattleCoroutine = StartCoroutine(Result());
        else if (!isPlayed)
            Process();
        else
            BattleCoroutine = StartCoroutine(Result());
        isPlayed = true;

    }
<<<<<<< Updated upstream
    // �÷��̾� ȸ���� ó���ϴ� �ڷ�ƾ
=======
>>>>>>> Stashed changes


    IEnumerator Result()
    {
<<<<<<< Updated upstream
        dialogueText.text = "�� ���� �Ϸ�..";
=======
        dialogueText.text = "턴 실행 완료";
>>>>>>> Stashed changes
        yield return new WaitForSeconds(1f);
        if (playerUnit.m_iCurrentHP <= 0)
            AfterLost();
        else if (enemyUnit.m_iCurrentHP <= 0)
            AfterWin();
        else
        {
            state = BattleState.ACTION;
            isPlayed = false;
            PlayerAction();
        }

    }

    #endregion

<<<<<<< Updated upstream
    #region ��ư Ŭ�� �̺�Ʈ
    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnButton(GameManager.Action action, int index)
    {
        // �÷��̾� ���� �ƴ� ��쿡�� �ƹ� �۾��� �������� ����
=======
    #region 버튼 클릭 메서드
    public void OnButton(GameManager.Action action, int index)
    {
        //버튼 동작을 action으로 받고 이에 따라 process에서 진행
>>>>>>> Stashed changes
        if (state != BattleState.ACTION)
            return;
        m_ePlayerAction = action;
        m_iPlayerActionIndex = index;
        //다시 기본 UI 활성화
        g_BattleButtons.SetActive(true);
        //하위 버튼 삭제
        GameObject[] destroy = GameObject.FindGameObjectsWithTag("CreatedButtons");
        for (int i = 0; i< destroy.Length;i++)
            Destroy(destroy[i]);
        
        
        

        state = BattleState.PROCESS;
        Process();
    }
    #endregion
}
