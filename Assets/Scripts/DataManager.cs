using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class DataManager : MonoBehaviour
{
    public Text txtHighScore;   // �ְ� ���� ǥ���ϴ� UI
    public Text txtEndPanelHighScore;   // ���� ���� ȭ�鿡 �ְ� ��� ǥ��

    string id;              // ���� �й�
    string myName;          // ���� �̸�
    int myHighScore = 0;    // ���� �ְ� ����
    int myScore = 0;        // �̹��� �÷����� ���� ����


    void Start()
    {
        // id, name �ʱ�ȭ
        initStringValues();

        // myHighScore �ʱ�ȭ
        initIntValues();
    }

    // id, name �ʱ�ȭ
    void initStringValues()
    {
        var bro = Backend.BMember.GetUserInfo();

        if (!bro.IsSuccess())
        {
            Debug.LogError("���� ������ �������µ� ���� �߻� : " + bro);
            return;
        }



        LitJson.JsonData userInfoJson = bro.GetReturnValuetoJSON()["row"];

        id = userInfoJson["gamerId"].ToString();
        myName = userInfoJson["nickname"].ToString();
    }

    // myHighScore �ʱ�ȭ
    void initIntValues()
    {
        var bro = Backend.GameData.GetMyData("USER_DATA", new Where());

        if (!bro.IsSuccess())
        {
            Debug.LogError("���� ���� ��ȸ ������ : " + bro);
        }



        Debug.Log("���� ���� ��ȸ ���� : " + bro);

        // GameData �ҷ�����
        LitJson.JsonData gameDataJson = bro.FlattenRows();

        if (gameDataJson.Count <= 0)
        {
            Debug.LogWarning("���� �����Ͱ� �������� ���� = �ְ� ������ 0�Դϴ�");
        }
        else
        {
            // GameData���� HighScore ������
            myHighScore = int.Parse(gameDataJson[0]["HIGHSCORE"].ToString());

            // ������ �ְ� ���� UI�� �ݿ�
            txtHighScore.text = " �ְ� ���� : " + myHighScore.ToString();
            txtEndPanelHighScore.text = " �ְ� ���� : " + myHighScore.ToString();
        }    
    }

    // ���� ���� �� �ְ� ��� ����
    public void updateHighScore(int newHighScore)
    {
        myHighScore = newHighScore;
    }

    // �ְ� ��� ��ȯ
    public int getHighScore()
    {
        return myHighScore;
    }

    // ���� ���� �� ������ ������ ����
    public void insertData(int score)
    {
        myScore = score;

        // ������ ������ �Ķ���� ����
        Param param = new Param();

        // ������ �Ķ���Ϳ� �� �Է�
        //param.Add("ID", id);
        param.Add("NAME", myName);
        param.Add("HIGHSCORE", myHighScore);
        param.Add("SCORE", myScore);

        // ������ �Ķ���� ����
        var bro = Backend.GameData.Insert("USER_DATA", param);



        if (bro.IsSuccess())
        {
            Debug.Log("���� ���� ������ ���� ���� : " + bro);

            // ������ ���� ������ ������
            
        }
        else
        {
            Debug.LogError("���� ���� ������ ���� ���� : " + bro);
        }
    }
}
