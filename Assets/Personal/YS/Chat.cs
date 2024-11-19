using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    // 이동 속도
    public float moveSpeed = 5.0f;

    // 색상 변경 주기
    public float colorChangeInterval = 2.0f;
    private float colorChangeTimer;

    // 오브젝트의 Renderer
    private Renderer objectRenderer;

    // UI 요소
    public InputField chatInputField; // 채팅 입력 필드
    public Text chatDisplay; // 채팅 표시 텍스트

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        colorChangeTimer = colorChangeInterval;
        ChangeColor(); // 초기 색상 변경
        chatDisplay.text = ""; // 초기 채팅 표시 텍스트 비워두기
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
        HandleColorChange();
        
        // Enter 키를 눌러 채팅 보내기
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendChatMessage();
        }
    }

    void MoveObject()
    {
        // 키 입력에 따른 오브젝트 이동
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);
    }

    void HandleColorChange()
    {
        // 색상 변경 타이머 업데이트
        colorChangeTimer -= Time.deltaTime;

        // 주기가 되면 색상 변경
        if (colorChangeTimer <= 0)
        {
            ChangeColor();
            colorChangeTimer = colorChangeInterval; // 타이머 리셋
        }
    }

    void ChangeColor()
    {
        // 랜덤한 색상을 생성하여 적용
        Color newColor = new Color(Random.value, Random.value, Random.value);
        objectRenderer.material.color = newColor;
        Debug.Log("색상이 변경되었습니다: " + newColor);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌 시 색상 변경
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            ChangeColor();
            Debug.Log("장애물과 충돌했습니다!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 트리거와 충돌 시 메시지 출력
        if (other.CompareTag("PowerUp"))
        {
            Debug.Log("파워업을 획득했습니다!");
            Destroy(other.gameObject); // 파워업 오브젝트 제거
        }
    }

    void SendChatMessage()
    {
        string message = chatInputField.text;
        if (!string.IsNullOrEmpty(message))
        {
            // 채팅 메시지를 화면에 추가
            chatDisplay.text += message + "\n";
            chatInputField.text = ""; // 입력 필드 초기화
            Debug.Log("전송된 메시지: " + message);
        }
    }
}
