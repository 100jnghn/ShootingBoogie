using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public GameObject player;

    public int score = 0;   // ���� ���

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void scoreUp(int v)
    {
        score += v;

        // UI�� �ݿ��ϴ� �Լ� ȣ��
        uiManager.updateScore(score);
    }

    public void gameEnd()
    {
        // ������ ������ ����



        // Ÿ�ӽ����� ����
        Time.timeScale = 0f;
        
        // �÷��̾� deActive
        player.SetActive(false);

        // ���� �г� ���߱�
        uiManager.manageMainPanel(false);

        // ���� ���� UI ���� �Լ� ȣ��
        uiManager.manageEndPanel(true);

        // ���� ���� UI�� �ݿ�
        uiManager.updateFinalScore(score);

    }
}
