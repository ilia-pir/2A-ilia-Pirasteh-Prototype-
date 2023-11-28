using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private List<Dialogue> _dialogues;

    private void Start()
    {
        foreach (Dialogue d in GetComponentsInChildren<Dialogue>())
        {
            _dialogues.Add(d);
        }
    }

    private Dialogue GetPrioritizedDialogue()
    {
        Dialogue prioritizedDialogue = _dialogues[0];
        foreach (Dialogue d in _dialogues)
        {
            if (prioritizedDialogue.priority < d.priority)
            {
                prioritizedDialogue = d;
            }
        } 
        return prioritizedDialogue;
    }
    public void ShowDialogue()
    {
        GetPrioritizedDialogue().ShowDialogue();
    }
    
    
}



