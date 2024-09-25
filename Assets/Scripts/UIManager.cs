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

    // ----- �г� ���� ----- //
    public void manageEndPanel(bool v)
    {
        panelEnd.SetActive(v);
    }

    public void manageMainPanel(bool v)
    {
        panelMain.SetActive(v);
    }
    


    // ----- ���� ��ư ----- //
    public void fireDown()
    {
        isFireButtonDown = true;
    }

    public void fireUp()
    {
        isFireButtonDown = false;
    }



    // ----- �ؽ�Ʈ ���� ----- //
    // gamemanager�� score UI�� �ݿ�
    public void updateScore(int score)
    {
        txtScore.text = " ���� : " + score.ToString();
    }

    // ���� ���� �� ���� ���� UI�� �ݿ�
    public void updateFinalScore(int score)
    {
        txtFinalScore.text += score.ToString();
    }
}
