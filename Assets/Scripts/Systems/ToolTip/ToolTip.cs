//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private LayoutElement _layoutElement;
    [SerializeField] private int _characterWrapLimit = 100;
    private RectTransform _rectTransform;

    //PRIVATE VALUES--------------------------------------
    //PUBLC VALUES----------------------------------------
    //PROPERTIES------------------------------------------

    //UNITY METHODS---------------------------------------
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Application.isEditor)
        {
            if (_header == null || _description == null || _layoutElement == null) return;

            int headerLength = _header.text.Length;
            int descriptionLength = _description.text.Length;

            _layoutElement.enabled = (headerLength > _characterWrapLimit || descriptionLength > _characterWrapLimit) ? true : false;
        }

        Vector2 mousePos = Input.mousePosition;

        float pivotX = mousePos.x / Screen.width;
        float pivioty = mousePos.y / Screen.height;


        _rectTransform.pivot = new Vector2(pivotX, pivioty);
        transform.position = mousePos;


    }

    //CUSTOM METHODS -------------------------------------
    public void SetText(string header, string content)
    {
        if (_header == null || _description == null || _layoutElement == null) return;

        if (header != null)
        {
            _header.enabled = true;
            _header.text = header;
        }
        else
        {
            _header.enabled = false;
        }
        
        if(content != null)
        {
            _description.enabled = true;
            _description.text = content;
        } 
        else
        {
            _description.enabled = false;
        }

        int headerLength = _header.text.Length;
        int descriptionLength = _description.text.Length;

        _layoutElement.enabled = (headerLength > _characterWrapLimit || descriptionLength > _characterWrapLimit) ? true : false;
    }
}
