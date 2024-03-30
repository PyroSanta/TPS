using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;

    public RectTransform expirienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;

    private int _levelValue = 1;
    
    private float _expirienceCurrentValue = 0;
    private float _expirienceTargetValue = 100;


    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }

    public void AddExpirience(float value)
    {
        _expirienceCurrentValue += value;
        if(_expirienceCurrentValue >= _expirienceTargetValue )
        {
            SetLevel(_levelValue += 1);
            _expirienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;
        var currentLevel = levels[_levelValue - 1];
        _expirienceTargetValue = currentLevel.expirienceForNextLevel;
        GetComponent<FireballCaster>().damage = currentLevel.fireballDamage;
        GetComponent<GrenadeCaster>().damage = currentLevel.grenadeDamage;  
        
        var grenadeCaster = GetComponent<GrenadeCaster>();  
        grenadeCaster.damage = currentLevel.grenadeDamage;
        
        if(currentLevel.grenadeDamage < 0)
            grenadeCaster.enabled = false;
        else
            grenadeCaster.enabled = true;
        

    }

    private void DrawUI()
    {
        expirienceValueRectTransform.anchorMax = new Vector2(_expirienceCurrentValue / _expirienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }
}
