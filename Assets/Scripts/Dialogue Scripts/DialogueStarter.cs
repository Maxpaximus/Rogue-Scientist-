using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStarter : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    //The same button continues the dialogue and and ends it, therefore I need a bool to see if the sentences are done
    public bool endOfDialogue;

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }
    
    //When pressing the button, the bool becomes true
    public void PressEndOfDialogue()
    {
        endOfDialogue = true;
        Debug.Log(dialogueManager.sentencesDone);
    }
    private void Update()
    {
        if(endOfDialogue = true && dialogueManager.sentencesDone == true)
        {
            TriggerEndOfDialogue();
        }
    }
    //"Button press" functions that run functions in the other script (?), I don't even know what I'm doing at this point.
    public void TriggerEndOfDialogue()
    {
        dialogueManager.EndDialogue(dialogue);
    }
    public void ChoicePress1()
    {
        dialogueManager.Choice1(dialogue);
    }
    public void ChoicePress2()
    {
        dialogueManager.Choice2(dialogue);
    }
    public void ChoicePress3()
    {
        dialogueManager.Choice3(dialogue);
    }
    public void ChoicePress4()
    {
        dialogueManager.Choice4(dialogue);
    }

    public void DisplayNextSentencePress()
    {
        dialogueManager.DisplayNextSentence(dialogue);
    }
}
