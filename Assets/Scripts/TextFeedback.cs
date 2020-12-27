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
    public void ShowDamage(int changedHpAmount)
    {
        feedbackText.enabled = true;
        feedbackText.text = changedHpAmount + "";
        feedbackText.gameObject.LeanMoveY(HealthBar.position.y, 2f);
        LeanTween.alphaText(feedbackText.rectTransform, 0f, 2f).setOnComplete(() =>
        {
            feedbackText.rectTransform.position = firstPos;
            feedbackText.enabled = false;
        });

    }
}
