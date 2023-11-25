using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public System.Action onClickCallBack;
    private GameObject replicatedObjects;
    private Transform parentObject;
    private ItemBase itemBase;

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
        replicatedObjects = Instantiate(gameObject, transform.position, Quaternion.identity, parentObject);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.AddComponent<DragObject>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
