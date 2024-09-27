using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class DataManager : MonoBehaviour
{
    public Text txtHighScore;   // 최고 점수 표시하는 UI
    public Text txtEndPanelHighScore;   // 게임 종료 화면에 최고 기록 표시

    string id;              // 개인 학번
    string myName;          // 개인 이름
    int myHighScore = 0;    // 개인 최고 점수
    int myScore = 0;        // 이번에 플레이한 게임 점수


    void Start()
    {
        // id, name 초기화
        initStringValues();

        // myHighScore 초기화
        initIntValues();
    }

    // id, name 초기화
    void initStringValues()
    {
        var bro = Backend.BMember.GetUserInfo();

        if (!bro.IsSuccess())
        {
            Debug.LogError("유저 정보를 가져오는데 에러 발생 : " + bro);
            return;
        }



        LitJson.JsonData userInfoJson = bro.GetReturnValuetoJSON()["row"];

        id = userInfoJson["gamerId"].ToString();
        myName = userInfoJson["nickname"].ToString();
    }

    // myHighScore 초기화
    void initIntValues()
    {
        var bro = Backend.GameData.GetMyData("USER_DATA", new Where());

        if (!bro.IsSuccess())
        {
            Debug.LogError("게임 정보 조회 실패함 : " + bro);
        }



        Debug.Log("게임 정보 조회 성공 : " + bro);

        // GameData 불러오기
        LitJson.JsonData gameDataJson = bro.FlattenRows();

        if (gameDataJson.Count <= 0)
        {
            Debug.LogWarning("게임 데이터가 존재하지 않음 = 최고 점수가 0입니다");
        }
        else
        {
            // GameData에서 HighScore 가져옴
            myHighScore = int.Parse(gameDataJson[0]["HIGHSCORE"].ToString());

            // 가져온 최고 점수 UI에 반영
            txtHighScore.text = " 최고 점수 : " + myHighScore.ToString();
            txtEndPanelHighScore.text = " 최고 점수 : " + myHighScore.ToString();
        }    
    }

    // 게임 종료 시 최고 기록 갱신
    public void updateHighScore(int newHighScore)
    {
        myHighScore = newHighScore;
    }

    // 최고 기록 반환
    public int getHighScore()
    {
        return myHighScore;
    }

    // 게임 종료 시 서버에 데이터 전송
    public void insertData(int score)
    {
        myScore = score;

        // 전송할 데이터 파라미터 생성
        Param param = new Param();

        // 생성한 파라미터에 값 입력
        //param.Add("ID", id);
        param.Add("NAME", myName);
        param.Add("HIGHSCORE", myHighScore);
        param.Add("SCORE", myScore);

        // 서버에 파라미터 전송
        var bro = Backend.GameData.Insert("USER_DATA", param);



        if (bro.IsSuccess())
        {
            Debug.Log("게임 정보 데이터 삽입 성공 : " + bro);

            // 삽입한 게임 정보의 고유값
            
        }
        else
        {
            Debug.LogError("게임 정보 데이터 삽입 실패 : " + bro);
        }
    }
}
