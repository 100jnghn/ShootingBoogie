using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInSceneManager : MonoBehaviour
{
    [Header ("----- Panels -----")]
    public GameObject panelLogIn;
    public GameObject panelCreateAccount;

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
}
