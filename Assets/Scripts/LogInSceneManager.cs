using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInSceneManager : MonoBehaviour
{
    [Header ("----- Panels -----")]
    public GameObject panelLogIn;
    public GameObject panelCreateAccount;

    // �α��� ȭ������ ���� ��ư Ŭ��
    public void onClickGotoLogIn()
    {
        panelCreateAccount.SetActive(false);
        panelLogIn.SetActive(true);
    }

    // ȸ������ ȭ������ ���� ��ư Ŭ��
    public void onClickGotoCreateAccount()
    {
        panelLogIn.SetActive(false);
        panelCreateAccount.SetActive(true);
    }
}
