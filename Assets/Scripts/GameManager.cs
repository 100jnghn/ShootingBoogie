using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public DataManager dataManager;

    public AudioSource sfxEnding;

    public GameObject player;

    public int score = 0;   // 점수 기록

    void Start()
    {
        // 타임스케일 1로 설정
        // 게임 종료 시 0으로 설정하기 때문에 다시 시작하면 0으로 돼있음
        // 따라서 시작할 때마다 1로 초기화 해줘야함
        Time.timeScale = 1;
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
        bool isHighScore = false;

        // 최고 기록 갱신 시
        if (score > dataManager.getHighScore())
        {
            // 현재 score로 내 최고 기록 갱신
            dataManager.updateHighScore(score);

            // 최고 기록 갱신 flag를 true로 설정
            isHighScore = true;
        }

        // 서버에 데이터 전송
        dataManager.insertData(score);

        // 게임 종료 알림음 재생
        sfxEnding.Play();

        // 타임스케일 제로
        Time.timeScale = 0f;
        
        // 플레이어 deActive
        player.SetActive(false);

        // 현재 패널 감추기
        uiManager.manageMainPanel(false);

        // 게임 종료 UI 띄우는 함수 호출
        uiManager.manageEndPanel(true);

        // 최고 기록 갱신이라면 최고 기록 패널 띄우는 함수 호출
        if (isHighScore)
        {
            uiManager.manageHighScorePanel(true);
        }
        else
        {
            uiManager.manageHighScorePanel(false);
        }

        // 최종 점수 UI에 반영
        uiManager.updateFinalScore(score);

    }
}
