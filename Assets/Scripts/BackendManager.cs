using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;
using UnityEngine.SceneManagement;  // �ڳ� Backend SDK

public class BackendManager : MonoBehaviour
{
    [Header("----- Associations -----")]
    public LogInSceneManager logInSceneManager;

    [Header("----- Log In Components -----")]
    public Text txtLogInID;
    public Text txtLogInPW;

    [Header("----- Create Account Components -----")]
    public Text txtCreateAccountName;
    public Text txtCreateAccountID;
    public Text txtCreateAccountPW;

    public Text txtHashKey;



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

        // ���� �ؽ�Ű ȹ�� 
        if (!Backend.Utils.GetGoogleHash().Equals(""))
        {
            string googlehash = Backend.Utils.GetGoogleHash();
            Debug.Log("Google Hash : " + googlehash);
            
            txtHashKey.text = googlehash;
        }
        else
        {
            Debug.Log("No Google Hash");

            txtHashKey.text = "No Google Hash";
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
            logInSceneManager.showPopUp("ID Ȥ�� Password�� �Է��ϼ���!");

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

            // �ٷ� �α��α���??

        }
        else
        {
            Debug.LogError("ȸ������ ���� : " + bro);

            // Error Code�� ���� ȸ������ ���� ����
            switch (bro.GetStatusCode())
            {
                case "409":
                    Debug.Log("�ߺ��� id�� ����");
                    logInSceneManager.showPopUp("�̹� �����ϴ� ID�Դϴ�!");

                    break;

                case "403":
                    Debug.Log("��ü����� �׽�Ʈ�ε� AU�� 10�� �ʰ�");
                    logInSceneManager.showPopUp("���� ����..!");

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
            logInSceneManager.showPopUp("ID Ȥ�� Password�� �Է��ϼ���!");

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
                    logInSceneManager.showPopUp("�������� �ʴ� ID �̰ų�\n�ùٸ��� ���� Password�Դϴ�!");

                    break;

                case "403":
                    Debug.Log("���ܴ��� ���� or ��ü����� �׽�Ʈ�ε� AU�� 10�� �ʰ�");
                    logInSceneManager.showPopUp("���� ����..!");

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
            logInSceneManager.showPopUp("�̸� ���� ����!");

            Debug.LogError("�̸� ���� ���� : " + bro);
        }
    }

    // �α��� �����ϰ� ���� ������ �̵�
    void moveToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
