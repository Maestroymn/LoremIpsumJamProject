using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFeedback : MonoBehaviour
{
    [SerializeField] TMP_Text feedbackText;
    [SerializeField] RectTransform HealthBar;
    Vector2 firstPos;

    private void Start()
    {
        firstPos = feedbackText.rectTransform.position;
    }
    
    public void ShowHPChange(int changedHpAmount)
    {
        feedbackText.gameObject.SetActive(true);
        if (changedHpAmount < 0)
        {
            feedbackText.text = changedHpAmount + "";
        }
        else
        {
            feedbackText.text = "+"+changedHpAmount + "";
        }
        feedbackText.gameObject.LeanMoveY(HealthBar.position.y, 1f);
        LeanTween.alphaText(feedbackText.rectTransform, 0f, 1f).setOnComplete(() =>
        {
            feedbackText.rectTransform.position = firstPos;
            feedbackText.gameObject.SetActive(false);
        });

    }
}
