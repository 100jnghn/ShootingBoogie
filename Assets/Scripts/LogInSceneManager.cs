using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInSceneManager : MonoBehaviour
{
    [Header("----- Screen Ratio -----")]
    public int width;
    public int height;

    [Header ("----- Panels -----")]
    public GameObject panelLogIn;
    public GameObject panelCreateAccount;

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
}
