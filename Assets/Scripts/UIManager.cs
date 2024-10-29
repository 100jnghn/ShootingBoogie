using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("----- Associations -----")]
    public GameManager gameManager;
    public Player player;

    [Header("----- Screen Ratio-----")]
    public int width;
    public int height;

    [Header("----- Panels")]
    public GameObject panelEnd;
    public GameObject panelMain;
    public GameObject panelHighScore;

    [Header ("----- Button Attack -----")]
    public Button btnFire;
    private bool isFireButtonDown;

    [Header ("----- Score -----")]
    public Text txtScore;
    public Text txtFinalScore;
    public Text txtHighScore;



    private void Awake()
    {
        setScreen();
    }

    void Update()
    {
        if (isFireButtonDown)
        {
            //Debug.Log("Fire!");
            player.doFire();
        }
    }

    void setScreen()
    {
        // 화면 비율 설정, 전체 화면 설정
        Screen.SetResolution(width, height, true);

        // 화면 꺼지지 않도록 설정
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // 화면 방향 설정 
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // ----- 패널 관리 ----- //
    public void manageEndPanel(bool v)
    {
        panelEnd.SetActive(v);
    }

    public void manageMainPanel(bool v)
    {
        panelMain.SetActive(v);
    }

    public void manageHighScorePanel(bool v)
    {
        panelHighScore.SetActive(v);
    }
    


    // ----- 공격 버튼 ----- //
    public void fireDown()
    {
        isFireButtonDown = true;
    }

    public void fireUp()
    {
        isFireButtonDown = false;
    }



    // ----- 버튼 기능 관리 ----- //
    // 다시하기 버튼
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 종료 버튼
    public void quit()
    {
        Application.Quit();

        // 에디터에서 Play 모드를 종료
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }


    // ----- 텍스트 관리 ----- //
    // gamemanager의 score UI에 반영
    public void updateScore(int score)
    {
        txtScore.text = " 점수 : " + score.ToString();
    }

    // 게임 종료 시 현재 점수 UI에 반영
    public void updateFinalScore(int score)
    {
        txtFinalScore.text += score.ToString();
    }
}
