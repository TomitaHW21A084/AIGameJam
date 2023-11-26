using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public System.Action onClickCallBack;
    public bool shouldUpPointer;
    private GameObject replicatedObjects;
    private Transform parentObject;
    private ItemBase itemBase;
    private ItemBase otherItemBase;
    private DragObject dragObject;

    private void Start()
    {
        parentObject = transform.parent.transform;
        itemBase = GetComponent<ItemBase>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickCallBack?.Invoke();
        Debug.Log("押された");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("長押し");
        shouldUpPointer = false;
        replicatedObjects = Instantiate(gameObject, transform.position, Quaternion.identity, parentObject);
        itemBase.SetCopyItem(replicatedObjects);
        itemBase.isDuringDrag = true;
        
        otherItemBase = replicatedObjects.GetComponent<ItemBase>();
        otherItemBase.isCopied = true;
        otherItemBase.isDuringDrag = true;
        otherItemBase.SetItemAmong(itemBase.GetItemAmong());
        
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        
        dragObject = gameObject.AddComponent<DragObject>();
        dragObject.itemInDrag = gameObject;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        itemBase.isDragged= true;
        itemBase.DecideWhetherDestroy();
        shouldUpPointer = true;
    }
}
