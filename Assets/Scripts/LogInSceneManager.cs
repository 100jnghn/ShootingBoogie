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
        // ȭ�� ���� ����, ��ü ȭ�� ����
        Screen.SetResolution(width, height, true);

        // ȭ�� ������ �ʵ��� ����
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // ȭ�� ���� ���� 
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

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

    // ���� �޽��� Ȯ�� ��ư
    public void onClickErrorOK()
    {
        panelErrorMessage.SetActive(false);
    }

    // �˾� �޽��� ���� �Լ�
    public void showPopUp(string msg)
    {
        txtError.text = msg;
    }
}
