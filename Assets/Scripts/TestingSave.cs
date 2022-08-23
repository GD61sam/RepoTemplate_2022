using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestingSave : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levle;
    [SerializeField] private TextMeshProUGUI _health;

    private float lvl;
    private float health;

    private void Start()
    {
        UpdateUI();
    }

    public void Add()
    {
        lvl = SaveData.Current.PlayerProfile.Level += 1;
        health = SaveData.Current.PlayerProfile.CurrentHealth += 10;

        UpdateUI();
    }

    public void UpdateUI()
    {
        _levle.text = lvl.ToString();
        _health.text = health.ToString();
    }
}
