using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;
using UnityEngine.SceneManagement;  // �ڳ� Backend SDK

public class BackendManager : MonoBehaviour
{
    [Header("----- Log In Components -----")]
    public Text txtLogInID;
    public Text txtLogInPW;

    [Header("----- Create Account Components -----")]
    public Text txtCreateAccountName;
    public Text txtCreateAccountID;
    public Text txtCreateAccountPW;



    private void Awake()
    {
        // �ڳ� ���� �ʱ�ȭ
        var bro = Backend.Initialize();

        // �ʱ�ȭ ���䰪
        if (bro.IsSuccess())
        {
            // ���� -> statusCode 204 Success
            Debug.Log("�ڳ� �ʱ�ȭ ����! " + bro);
        }
        else
        {
            // ���� -> statusCode 4nn
            Debug.LogError("�ʱ�ȭ ����! " + bro);
        }
    }



    void Start()
    {
        // �� ��ȯ�� �־ �� Obj�� �ı����� ����
        DontDestroyOnLoad(this);
    }

    void Update()
    {

    }

    // ȸ������
    public void CustomSignUp()
    {
        Debug.Log("ȸ������ ��û");

        // Input Field�� �ϳ��� ��������� return
        if (txtCreateAccountName.text.Length <= 0 ||
            txtCreateAccountID.text.Length <= 0 ||
            txtCreateAccountPW.text.Length <= 0)
        {
            return;
        }
        


        // Input Field�� ID, PW ��
        string id = txtCreateAccountID.text;
        string pw = txtCreateAccountPW.text;

        // ȸ������ ��û
        var bro = Backend.BMember.CustomSignUp(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("ȸ������ ���� : " + bro);

            // ȸ�����Կ� �����ϸ� �̾ �̸��� �����Ѵ�
            UpdateNickname();
        }
        else
        {
            Debug.LogError("ȸ������ ���� : " + bro);

            // Error Code�� ���� ȸ������ ���� ����
            switch (bro.GetStatusCode())
            {
                case "409":
                    Debug.Log("�ߺ��� id�� ����");
                    break;

                case "403":
                    Debug.Log("��ü����� �׽�Ʈ�ε� AU�� 10�� �ʰ�");
                    break;
            }
        }
    }

    // �α���
    public void CustomLogIn()
    {
        Debug.Log("�α��� ��û");

        // Input Field�� �ϳ��� ��������� return
        if (txtLogInID.text.Length <= 0 ||
            txtLogInPW.text.Length <= 0)
        {
            return;
        }



        // Input Field�� ID, PW ��
        string id = txtLogInID.text;
        string pw = txtLogInPW.text;

        // �α��� ��û
        var bro = Backend.BMember.CustomLogin(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("�α��� ���� : " + bro);

            Invoke("moveToGameScene", 1f);
        }
        else
        {
            Debug.LogError("�α��� ���� : " + bro);

            // Error Code�� ���� �α��� ���� ����
            switch (bro.GetStatusCode())
            {
                case "401":
                    Debug.Log("�������� �ʴ� id or Ʋ�� password �Է�");
                    break;

                case "403":
                    Debug.Log("���ܴ��� ���� or ��ü����� �׽�Ʈ�ε� AU�� 10�� �ʰ�");
                    break;
            }
        }
    }

    // �г��� ����
    public void UpdateNickname()
    {
        Debug.Log("�̸� ���� ��û");

        // Input Field�� Name ��
        string name = txtCreateAccountName.text;

        var bro = Backend.BMember.UpdateNickname(name);

        if (bro.IsSuccess())
        {
            Debug.Log("�̸� ���� ���� : " + bro);
        }
        else
        {
            Debug.LogError("�̸� ���� ���� : " + bro);
        }
    }

    // �α��� �����ϰ� ���� ������ �̵�
    void moveToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
