using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;
using UnityEngine.SceneManagement;  // 뒤끝 Backend SDK

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
        // 뒤끝 서버 초기화
        var bro = Backend.Initialize();

        // 초기화 응답값
        if (bro.IsSuccess())
        {
            // 성공 -> statusCode 204 Success
            Debug.Log("뒤끝 초기화 성공! " + bro);
        }
        else
        {
            // 실패 -> statusCode 4nn
            Debug.LogError("초기화 실패! " + bro);
        }

        // 구글 해시키 획득 
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
        // 씬 변환이 있어도 이 Obj를 파괴하지 않음
        DontDestroyOnLoad(this);
    }

    void Update()
    {

    }

    // 회원가입
    public void CustomSignUp()
    {
        Debug.Log("회원가입 요청");

        // Input Field가 하나라도 비어있으면 return
        if (txtCreateAccountName.text.Length <= 0 ||
            txtCreateAccountID.text.Length <= 0 ||
            txtCreateAccountPW.text.Length <= 0)
        {
            logInSceneManager.showPopUp("ID 혹은 Password를 입력하세요!");

            return;
        }
        


        // Input Field의 ID, PW 값
        string id = txtCreateAccountID.text;
        string pw = txtCreateAccountPW.text;

        // 회원가입 요청
        var bro = Backend.BMember.CustomSignUp(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("회원가입 성공 : " + bro);

            // 회원가입에 성공하면 이어서 이름도 설정한다
            UpdateNickname();

            // 바로 로그인까지??

        }
        else
        {
            Debug.LogError("회원가입 실패 : " + bro);

            // Error Code에 따른 회원가입 실패 사유
            switch (bro.GetStatusCode())
            {
                case "409":
                    Debug.Log("중복된 id가 존재");
                    logInSceneManager.showPopUp("이미 존재하는 ID입니다!");

                    break;

                case "403":
                    Debug.Log("출시설정이 테스트인데 AU가 10을 초과");
                    logInSceneManager.showPopUp("서버 오류..!");

                    break;
            }
        }

        
    }

    // 로그인
    public void CustomLogIn()
    {
        Debug.Log("로그인 요청");

        // Input Field가 하나라도 비어있으면 return
        if (txtLogInID.text.Length <= 0 ||
            txtLogInPW.text.Length <= 0)
        {
            logInSceneManager.showPopUp("ID 혹은 Password를 입력하세요!");

            return;
        }



        // Input Field의 ID, PW 값
        string id = txtLogInID.text;
        string pw = txtLogInPW.text;

        // 로그인 요청
        var bro = Backend.BMember.CustomLogin(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("로그인 성공 : " + bro);

            Invoke("moveToGameScene", 1f);
        }
        else
        {
            Debug.LogError("로그인 실패 : " + bro);

            // Error Code에 따른 로그인 실패 사유
            switch (bro.GetStatusCode())
            {
                case "401":
                    Debug.Log("존재하지 않는 id or 틀린 password 입력");
                    logInSceneManager.showPopUp("존재하지 않는 ID 이거나\n올바르지 않은 Password입니다!");

                    break;

                case "403":
                    Debug.Log("차단당한 유저 or 출시설정이 테스트인데 AU가 10을 초과");
                    logInSceneManager.showPopUp("서버 오류..!");

                    break;
            }
        }
    }

    // 닉네임 설정
    public void UpdateNickname()
    {
        Debug.Log("이름 설정 요청");

        // Input Field의 Name 값
        string name = txtCreateAccountName.text;

        var bro = Backend.BMember.UpdateNickname(name);

        if (bro.IsSuccess())
        {
            Debug.Log("이름 설정 성공 : " + bro);
        }
        else
        {
            logInSceneManager.showPopUp("이름 설정 실패!");

            Debug.LogError("이름 설정 실패 : " + bro);
        }
    }

    // 로그인 성공하고 게임 씬으로 이동
    void moveToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
