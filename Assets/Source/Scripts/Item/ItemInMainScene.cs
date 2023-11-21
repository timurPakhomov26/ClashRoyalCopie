using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInMainScene : ItemBase
{
    [SerializeField] private RectTransform _rectTransform;
    protected override RectTransform RectTrans => _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        //canvasGroup = GetComponent<CanvasGroup>();*/
    }

    public override void OnDrag(PointerEventData eventData)
    {
        RectTrans.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
    }
    
    public override void OnBeginDrag(PointerEventData eventData)
    {
        mainCanvas = GetComponentInParent<Canvas>(); 
    }
    
    public override void OnEndDrag(PointerEventData eventData)
    {
        RectTrans.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
    }
    
    public override void ChangeIcon(Sprite icon) => base.ChangeIcon(icon);
    
    public override void ChangeManaCost(int costValue) => base.ChangeManaCost(costValue);
    
}
