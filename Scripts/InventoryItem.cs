using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform ParentAfterDrag;

    public Canvas canvas;

    void Awake()
    {
        // Canvas�� �ֻ��� �θ𿡼� ã�ƿɴϴ� (��, �� ���� �ϳ��� �ִٰ� ����)
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        image.raycastTarget = false;

        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling(); // �׻� UI �ֻ������ ���̰�
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(ParentAfterDrag);
    }
}
