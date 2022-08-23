//PROPERTY OF SAM MCKINNEY - 2022
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest : ScriptableObject
{
    //SERIALIZED VAULES-----------------------------------

    //PRIVATE VALUES--------------------------------------

    //PUBLC VALUES----------------------------------------
    [Header("Quest Info")]
    public Info QuestInformation;

    [Header("Goals")]
    public List<string> ListOfGoals = new List<string>();

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
    public void StartQuest()
    {
        Debug.Log("Start Quest");

        FindAllGoalTypes();
    }

    public void PauseQuest()
    {

    }

    public void FindAllGoalTypes()
    {
        Debug.Log("Finding Types");

        var lookup = typeof(Goal_New);
        ListOfGoals = System.AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsSubclassOf(typeof(Goal_New)))
            .Select(type => type.Name)
            .ToList();

    }

    public void FinishQuest()
    {

    }

}
