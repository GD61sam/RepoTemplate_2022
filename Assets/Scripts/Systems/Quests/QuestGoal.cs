//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object / Quest Goal")]
public class QuestGoal : ScriptableObject
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private string _description;

    //PRIVATE VALUES--------------------------------------
    //PUBLC VALUES----------------------------------------
    //public bool IsCompleted { get; private set; }

    //PROPERTIES------------------------------------------
       
    //UNITY METHODS---------------------------------------
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //CUSTOM METHODS -------------------------------------
    public void CheckProgress()
    {

    }

}
