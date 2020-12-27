using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateComboManager : MonoBehaviour
{
    [SerializeField] int current;
    [SerializeField] int maximum;
    [SerializeField] Image mask;
    public event Action OnSuccess;
    public void ComboBarProgression()
    {
        current++;
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
        if(Math.Abs(mask.fillAmount - 1) < Mathf.Epsilon)
        {
            OnSuccess?.Invoke();
            mask.fillAmount = 0;
            current = 0;
        }
    }

    public void ComboFailed()
    {
        mask.fillAmount = 0;
        current = 0;
    }
}
