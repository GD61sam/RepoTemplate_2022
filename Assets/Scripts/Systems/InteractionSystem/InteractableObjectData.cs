//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = ("Scriptable Object / Interactables Object Data"))]
public class InteractableObjectData : ScriptableObject
{
    [Title("Interactable Data")]
    public string Name;
    public EnumInteractionTypes InteractableType;

    [Title("Interaction Conditions")]
    public int InteractionDistance = 5;
    public Vector3 InteractionSourceOffset = new Vector3(0, 0, 0);    
    public string TargetTag;

    [Range(0, 20)] public int Weight = 10;

    public GameObject Interactable { get; private set; }

    public void SetInteractable(GameObject obj)
    {
        Interactable = obj;
    }
}
