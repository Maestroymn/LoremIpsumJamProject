using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthManager : MonoBehaviour
{
    [SerializeField] TextFeedback textFeedback;
    [SerializeField] int maximum;
    [SerializeField] int current;
    [SerializeField] Image mask;
    [SerializeField] List<float> percentageValues;
    public event Action<int> percentageReached;
    public event Action OnDead;
    public float fillAmount;
    
    void Start()
    {
        for (int i = 0; i < percentageValues.Count; i++)
        {
            percentageValues[i] = percentageValues[i] / (float)maximum;
        }
    }

    public void SetHealth(int damage,bool decrease)
    {
        textFeedback.ShowHPChange(-1*damage);
        if (decrease)
        {
            damage *= -1;
        }
        current += damage;
        if (current <= 0)
        {
            current = 0;
            OnDead?.Invoke();
        }
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
