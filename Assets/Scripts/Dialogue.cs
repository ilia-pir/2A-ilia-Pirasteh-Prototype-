using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class DialogueLineButton
{
    public string text;
    public UnityEvent buttonEvent;
}


[Serializable]
public class Dialogueline
{
    public string speaker;
    [TextArea(5, 10)] public string text;
    public UnityEvent lineevent;
    public List<DialogueLineButton> buttons;
}




public class Dialogue : MonoBehaviour
{
    public int priority = -1;
    public List<Dialogueline> dialoguelines;
    public UnityEvent onEnd; 


    public void ShowDialogue()
    {
        
        if (GameManager.instance.inDialogue || dialoguelines.Count == 0)  {return;}
        
        
        
        GameManager.instance.ShowDialogue(this);
    }

    public void SetPriority(int newPriority)
    {
        priority = newPriority;
    }
}
