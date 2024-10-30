using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInSceneManager : MonoBehaviour
{
    [Header("----- Screen Ratio -----")]
    public int width;
    public int height;

    [Header ("----- Panels -----")]
    public GameObject panelLogIn;
    public GameObject panelCreateAccount;
    public GameObject panelErrorMessage;

    [Header("----- Texts -----")]
    public Text txtError;

    private void Awake()
    {
        setScreen();
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

    // 로그인 화면으로 가는 버튼 클릭
    public void onClickGotoLogIn()
    {
        panelCreateAccount.SetActive(false);
        panelLogIn.SetActive(true);
    }

    // 회원가입 화면으로 가는 버튼 클릭
    public void onClickGotoCreateAccount()
    {
        panelLogIn.SetActive(false);
        panelCreateAccount.SetActive(true);
    }

    // 에러 메시지 확인 버튼
    public void onClickErrorOK()
    {
        panelErrorMessage.SetActive(false);
    }

    // 팝업 메시지 띄우는 함수
    public void showPopUp(string msg)
    {
        txtError.text = msg;
    }
}
