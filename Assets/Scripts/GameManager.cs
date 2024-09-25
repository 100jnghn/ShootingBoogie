using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public GameObject player;

    public int score = 0;   // 점수 기록

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void scoreUp(int v)
    {
        score += v;

        // UI에 반영하는 함수 호출
        uiManager.updateScore(score);
    }

    public void gameEnd()
    {
        // 서버에 데이터 전송



        // 타임스케일 제로
        Time.timeScale = 0f;
        
        // 플레이어 deActive
        player.SetActive(false);

        // 현재 패널 감추기
        uiManager.manageMainPanel(false);

        // 게임 종료 UI 띄우는 함수 호출
        uiManager.manageEndPanel(true);

        // 최종 점수 UI에 반영
        uiManager.updateFinalScore(score);

    }
}
