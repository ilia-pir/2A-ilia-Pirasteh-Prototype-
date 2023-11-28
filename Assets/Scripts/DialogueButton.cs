using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonTextUI;
    private string _text;
    private UnityEvent _buttonEvent;

    public void Setup(string text, UnityEvent buttonEvent)
    {
        _text = text;
        _buttonEvent = buttonEvent;
        _buttonTextUI.SetText(text);


    }

    public void OnClicK()
    {
        if (_buttonEvent.GetPersistentEventCount() == 0)
        {
            GameManager.instance.Nextline();
        }
        _buttonEvent.Invoke();   
    }
}
