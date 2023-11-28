using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PlayerInput _playerInput; 

    [Header("interaction")]
    [SerializeField] private GameObject _interactUI;
    [Header("dialogue")]
    [SerializeField] private GameObject _dialogueUI;
    [SerializeField] private Animator _dialogueAnimation;
    [SerializeField] private TextMeshProUGUI _speakertext;
    [SerializeField] private TextMeshProUGUI _dialoguetext;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private GameObject _buttonGroup;
    public bool inDialogue = false;
    private Dialogue _currentDialogue;
    private int _currentLineIndex;

    [Header("Quest")]
    [SerializeField] private TextMeshProUGUI _questTitle;
    [SerializeField] private TextMeshProUGUI _questText;
    
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ShowInteractUI(false);
    }

    public void ShowInteractUI(bool show)
    {
        _interactUI.SetActive(show);
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        inDialogue = true;
        _currentDialogue = dialogue;
        _currentLineIndex = 0;
        _playerInput.SwitchCurrentActionMap("UI");
        ClearDialogueButtons();
        _speakertext.SetText("");
        _dialoguetext.SetText("");
        
        ShowInteractUI(false);
        ShowCurrentLine();
        Cursor.lockState = CursorLockMode.Confined;
        _dialogueAnimation.Play("DialogueShow");
    }

    public void HideDialogue()
    {
        _dialogueAnimation.Play("DialogueHide");
        Cursor.lockState = CursorLockMode.Locked;
        inDialogue = false;
        _currentDialogue.onEnd.Invoke();
        _playerInput.SwitchCurrentActionMap("Player");
    }

    private void ShowCurrentLine()
    {
        Dialogueline dialogueline = _currentDialogue.dialoguelines[_currentLineIndex];
        
        if (dialogueline == null) {return;}

        ClearDialogueButtons();

            foreach (DialogueLineButton button in dialogueline.buttons)
            {
                GameObject buttonInstance = Instantiate(_buttonPrefab, _buttonGroup.transform);
                buttonInstance.GetComponent<DialogueButton>().Setup(button.text, button.buttonEvent);
            }
            
        _speakertext.SetText(dialogueline.speaker);
        _dialoguetext.SetText(dialogueline.text);
            dialogueline.lineevent.Invoke();
        
        
    }

    public void Nextline()
    {
        if (!inDialogue) {return;}

        _currentLineIndex++;
        if (_currentDialogue.dialoguelines.Count <= _currentLineIndex)
        {
            HideDialogue();return;
        }
        ShowCurrentLine();
    }

    private void ClearDialogueButtons()
    {
        foreach (Transform t in _buttonGroup.transform)
        {
            Destroy(t.gameObject);
        }
    }

    public void ShowNewDialogue(Dialogue dialogue)
    {
        _currentDialogue = dialogue;
        _currentLineIndex = 0;
        
        ShowCurrentLine();
    }

    public void SetQuestTitle(string title)
    {
        _questTitle.SetText(title);
    }

    public void SetQuestText(string text)
    {
        _questText.SetText(text);
    }

    public void ClearQuest()
    {
        SetQuestTitle("");
        SetQuestText("");
    }
}
    
    
