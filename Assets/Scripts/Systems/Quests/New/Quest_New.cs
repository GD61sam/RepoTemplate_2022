//PROPERTY OF SAM MCKINNEY - 2022
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest Test")]
public class Quest_New : ScriptableObject
{
    //SERIALIZED VAULES-----------------------------------

    //PRIVATE VALUES--------------------------------------

    //PUBLC VALUES----------------------------------------
    [Header("Quest Info")]
    public Info QuestInformation;

    [Header("Goals")]
    public List<Goal_New> Goals;

    //STRUCTS---------------------------------------------
    [System.Serializable]
    public struct Info
    {
        public string Name;
        public string ID;
        public string Description;
        public Reward Reward;
    }

    [System.Serializable]
    public struct Reward
    {
        public int Experience;
        public int Currency;
        public GameObject Item;
    }


    //PROPERTIES------------------------------------------

    //UNITY METHODS---------------------------------------
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //CUSTOM METHODS -------------------------------------
    public void AddNewGoal()
    {

    }


    //GetAll().ToList().ForEach(x => x.DoStuff());
}
