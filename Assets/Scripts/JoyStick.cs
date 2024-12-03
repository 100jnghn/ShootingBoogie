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

    // ���̽�ƽ �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        DragEvent(eventData);
    }

    // ���̽�ƽ �巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        DragEvent(eventData);
    }

    // ���̽�ƽ �巡�� ����
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");

        isDrag = false;
        lever.anchoredPosition = Vector2.zero;
    }

    private void DragEvent(PointerEventData eventData)
    {
        isDrag = true;

        // ȭ�� ��ǥ�� RectTransform�� ���� ��ǥ�� ��ȯ
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPoint);
        

        // �Է� ��ġ�� ���̽�ƽ ������ ���� �ʵ��� ���
        Vector2 rangeDir = localPoint.magnitude < leverRange ? localPoint : localPoint.normalized * leverRange;

        // ���� ��ġ �� ���� ����
        lever.anchoredPosition = rangeDir;
        inputVec = rangeDir.normalized;
    }
}
