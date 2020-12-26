﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BossHealthManager : MonoBehaviour
{
    [SerializeField] int maximum;
    [SerializeField] int current;
    [SerializeField] Image mask;
    [SerializeField] List<float> percentageValues;
    public event Action<int> percentageReached;
    public float fillAmount;
    
    void Start()
    {
        for (int i = 0; i < percentageValues.Count; i++)
        {
            percentageValues[i] = percentageValues[i] / (float)maximum;
        }
    }

    public void SetHealth(int damage)
    {
        current -= damage;
        fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
        for (int i = 0; i < percentageValues.Count; i++)
        {
            if(percentageValues[i] <= fillAmount && percentageValues[i - 1] > fillAmount && i >= 1)
            {
                percentageReached?.Invoke(i);
            }
        }
    }
}