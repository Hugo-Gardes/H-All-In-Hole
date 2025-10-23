using System;
using UnityEngine;
using TMPro;

public class ConfirmationScript : MonoBehaviour
{
    private Action _callbackValidation;
    private Action _callbackCancel;
    private float timeLeft = 30f;

    public TMP_Text timeLeftText;

    public void confirmation(Action callbackValidation, Action callbackCancel)
    {
        _callbackValidation = callbackValidation;
        _callbackCancel = callbackCancel;
        timeLeft = 30f;
    }

    public void OnValidateButton()
    {
        _callbackValidation?.Invoke();
        gameObject.SetActive(false);
    }

    public void OnCancelButton()
    {
        _callbackCancel?.Invoke();
        gameObject.SetActive(false);
    }

    private void UpdateTime()
    {
        timeLeftText.text = "Time Left: " + Math.Ceiling(timeLeft).ToString();
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTime();
        }

        if (timeLeft <= 0)
        {
            OnCancelButton();
        }
    }
}
