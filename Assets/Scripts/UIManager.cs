using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("----- Associations -----")]
    public GameManager gameManager;
    public Player player;

    [Header("----- Panels")]
    public GameObject panelEnd;
    public GameObject panelMain;

    [Header ("----- Button Attack -----")]
    public Button btnFire;
    private bool isFireButtonDown;

    [Header ("----- Score -----")]
    public Text txtScore;
    public Text txtFinalScore;
    public Text txtHighScore;



    void Start()
    {
        
    }

    void Update()
    {
        if (isFireButtonDown)
        {
            //Debug.Log("Fire!");
            player.doFire();
        }
    }

    // ----- 패널 관리 ----- //
    public void manageEndPanel(bool v)
    {
        panelEnd.SetActive(v);
    }

    public void manageMainPanel(bool v)
    {
        panelMain.SetActive(v);
    }
    


    // ----- 공격 버튼 ----- //
    public void fireDown()
    {
        isFireButtonDown = true;
    }

    public void fireUp()
    {
        isFireButtonDown = false;
    }



    // ----- 텍스트 관리 ----- //
    // gamemanager의 score UI에 반영
    public void updateScore(int score)
    {
        txtScore.text = " 점수 : " + score.ToString();
    }

    // 게임 종료 시 현재 점수 UI에 반영
    public void updateFinalScore(int score)
    {
        txtFinalScore.text += score.ToString();
    }
}
