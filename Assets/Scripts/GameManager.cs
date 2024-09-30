using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public DataManager dataManager;

    public AudioSource sfxEnding;

    public GameObject player;

    public int score = 0;   // ���� ���

    void Start()
    {
        // Ÿ�ӽ����� 1�� ����
        // ���� ���� �� 0���� �����ϱ� ������ �ٽ� �����ϸ� 0���� ������
        // ���� ������ ������ 1�� �ʱ�ȭ �������
        Time.timeScale = 1;
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
        bool isHighScore = false;

        // �ְ� ��� ���� ��
        if (score > dataManager.getHighScore())
        {
            // ���� score�� �� �ְ� ��� ����
            dataManager.updateHighScore(score);

            // �ְ� ��� ���� flag�� true�� ����
            isHighScore = true;
        }

        // ������ ������ ����
        dataManager.insertData(score);

        // ���� ���� �˸��� ���
        sfxEnding.Play();

        // Ÿ�ӽ����� ����
        Time.timeScale = 0f;
        
        // �÷��̾� deActive
        player.SetActive(false);

        // ���� �г� ���߱�
        uiManager.manageMainPanel(false);

        // ���� ���� UI ���� �Լ� ȣ��
        uiManager.manageEndPanel(true);

        // �ְ� ��� �����̶�� �ְ� ��� �г� ���� �Լ� ȣ��
        if (isHighScore)
        {
            uiManager.manageHighScorePanel(true);
        }
        else
        {
            uiManager.manageHighScorePanel(false);
        }

        // ���� ���� UI�� �ݿ�
        uiManager.updateFinalScore(score);

    }
}
