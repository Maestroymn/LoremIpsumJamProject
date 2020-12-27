using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateComboManager : MonoBehaviour
{
    [SerializeField] int current;
    [SerializeField] int maximum;
    [SerializeField] Image mask;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ComboBarProgression();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ComboFailed();
        }
    }
    public void ComboBarProgression()
    {
        current++;
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
        if(mask.fillAmount == 1)
        {
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
