//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class Tab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    //SERIALIZED VAULES-----------------------------------
    [Header("Sprites")]
    [SerializeField] private Sprite DefaultSprite;
    [SerializeField] private Sprite HighlightedSprite;
    [SerializeField] private Sprite SelectedSprite;

    //PRIVATE VALUES--------------------------------------
    private TabGroup _tabGroup;

    private Image _image;

    //PUBLC VALUES----------------------------------------
    [Header("Events")]
    public UnityEvent OnSelected;
    public UnityEvent OnDeselected;

    //UNITY METHODS---------------------------------------
    void Awake()
    {
        _image = GetComponent<Image>();
        _tabGroup = GetComponentInParent<TabGroup>();

        _tabGroup.Subscribe(this);
    }

    //INTERFACE METHODS-----------------------------------
    public void OnPointerEnter(PointerEventData eventData)
    {
        _tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tabGroup.OnTabExit(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _tabGroup.OnTabSelected(this);
    }

    //CUSTOM METHODS -------------------------------------
    public void SetIdle()
    {
        _image.sprite = DefaultSprite;
    }

    public void SetHighlighted()
    {
        _image.sprite = HighlightedSprite;
    }

    public void SetSelected()
    {
        _image.sprite = SelectedSprite;
    }

    public void Selected()
    {
        OnSelected?.Invoke();
    }

    public void Deselected()
    {
        OnDeselected?.Invoke();
    }
}
