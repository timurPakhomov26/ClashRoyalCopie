using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(CanvasGroup))]
public abstract class ItemBase : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [SerializeField] protected TextMeshProUGUI _manaCost;
    [SerializeField] protected Image _itemSprite;
    [SerializeField] protected CanvasGroup canvasGroup;
    protected Canvas mainCanvas;
    protected abstract RectTransform RectTrans { get; }


    public virtual void OnDrag(PointerEventData eventData)
    {
        
    }
    
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        mainCanvas = GetComponentInParent<Canvas>(); 
       /* var uiSlotTransform = rectTransform.parent;
        uiSlotTransform.SetAsLastSibling();
        
        var deckChangerTransform = uiSlotTransform.parent;
        deckChangerTransform.SetAsLastSibling(); 
       
        canvasGroup.blocksRaycasts = false;*/
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
    }

    public virtual void ChangeIcon(Sprite icon) => _itemSprite.sprite = icon;
    public virtual void ChangeManaCost(int costValue) => _manaCost.text = costValue.ToString();
}
