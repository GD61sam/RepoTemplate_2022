using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _interactionText;

    public void SetInteractionText(bool isActive, string interactableName)
    {
        _interactionText.text = "Press 'E' to interact with " + interactableName;
        _interactionText.enabled = isActive;
    }

}
