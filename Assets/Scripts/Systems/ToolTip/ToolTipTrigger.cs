//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //PUBLC VALUES----------------------------------------
    public string _header;
    public string _content;

    //UNITY METHODS---------------------------------------

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(Wait());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.Current.Hide();
    }

    //CUSTOM METHODS -------------------------------------
    public void SetInfo(string header, string content)
    {
        _header = header;
        _content = content;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

        ToolTipSystem.Current.Show(_header, _content);
    }
}
