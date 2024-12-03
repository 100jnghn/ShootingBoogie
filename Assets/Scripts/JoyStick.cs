using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject player;
    public bool isDrag;

    [SerializeField]
    RectTransform lever;
    RectTransform rectTransform;

    public Vector2 inputVec;
    public float moveSpeed = 0.1f;

    [SerializeField, Range(10f, 150f)]
    float leverRange;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        playerControl();
    }

    void playerControl()
    {
        if (isDrag)
        {
            player.transform.Translate(inputVec * moveSpeed * Time.deltaTime);
        }
    }

    // 조이스틱 드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {
        DragEvent(eventData);
    }

    // 조이스틱 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        DragEvent(eventData);
    }

    // 조이스틱 드래그 종료
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");

        isDrag = false;
        lever.anchoredPosition = Vector2.zero;
    }

    private void DragEvent(PointerEventData eventData)
    {
        isDrag = true;

        // 화면 좌표를 RectTransform의 로컬 좌표로 변환
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPoint);
        

        // 입력 위치가 조이스틱 범위를 넘지 않도록 계산
        Vector2 rangeDir = localPoint.magnitude < leverRange ? localPoint : localPoint.normalized * leverRange;

        // 레버 위치 및 방향 설정
        lever.anchoredPosition = rangeDir;
        inputVec = rangeDir.normalized;
    }
}
