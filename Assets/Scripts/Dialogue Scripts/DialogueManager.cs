using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    //All possible sentences/conversations from the npc
    private Queue<string> sentences;
    private Queue<string> sentences1;
    private Queue<string> sentences2;
    private Queue<string> sentences3;
    private Queue<string> sentences4;
    private Queue<string> sentences5;
    private Queue<string> sentences6;
    public Queue<string> sentences7;

    public Button[] choiceButton;

    float totalScore;

    public bool sentencesDone;

    private string comment;

    private int timesClicked = 0;
    //For choosing which way in the dialogue to go
    public int continueGoTo = 0;
    
    //Queue of sentences
    void Start()
    {
        sentences = new Queue<string>();
        sentences1 = new Queue<string>();
        sentences2 = new Queue<string>();
        sentences3 = new Queue<string>();
        sentences4 = new Queue<string>();
        sentences5 = new Queue<string>();
        sentences6 = new Queue<string>();
        sentences7 = new Queue<string>();
    }
    //Name text set to the name of the NPC and a loop to go through the sentences (I think)
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.npcName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(dialogue);
    }
    
    //Checking how many sentences there are left, if there arent any, end the dialogue
    public void DisplayNextSentence(Dialogue dialogue)
    {
        if (sentences.Count > 0 && continueGoTo == 0)
        {
            string sentence = sentences.Dequeue();

            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
        else if (sentences.Count == 0 && continueGoTo == 1)
        {
            foreach (string sentence in dialogue.sentences1)
            {
                sentences1.Enqueue(sentence);
            }
            string sentence1 = sentences1.Dequeue();

            StartCoroutine(TypeSentence(sentence1));
        }
        else if (sentences.Count == 0 && continueGoTo == 2)
        {
            foreach (string sentence in dialogue.sentences2)
            {
                sentences2.Enqueue(sentence);
            }
            string sentence2 = sentences2.Dequeue();

            StartCoroutine(TypeSentence(sentence2));
        }
        sentencesDone = true;
        Debug.Log(continueGoTo);
        return;
    }

    //For "animating" each letter
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }   

    IEnumerator TypeComment (string comment)
    {
        choiceButton[0].image.enabled = false;
        choiceButton[1].image.enabled = false;
        choiceButton[2].image.enabled = false;
        choiceButton[3].image.enabled = false;

        dialogueText.text = "";
        foreach (char letter in comment.ToCharArray())
        {
            dialogueText.text = dialogueText.text + letter;
            yield return null;
        }
    }

    //Ends dialogue and gives player choice
    public void EndDialogue(Dialogue dialogue)
    {
        choiceButton[0].image.enabled = true;
        choiceButton[1].image.enabled = true;
        choiceButton[2].image.enabled = true;
        choiceButton[3].image.enabled = true;

        Text choice1 = choiceButton[0].GetComponentInChildren<Text>();
        Text choice2 = choiceButton[1].GetComponentInChildren<Text>();
        Text choice3 = choiceButton[2].GetComponentInChildren<Text>();
        Text choice4 = choiceButton[3].GetComponentInChildren<Text>();

        choice1.text = dialogue.choices[timesClicked + 0];
        choice2.text = dialogue.choices[timesClicked + 1];
        choice3.text = dialogue.choices[timesClicked + 2];
        choice4.text = dialogue.choices[timesClicked + 3];

    }

    //Choices
    public void Choice1(Dialogue dialogue)
    {
        comment = dialogue.comments[0];
        Debug.Log("Choice1");
        StartCoroutine(TypeComment(comment));
        Debug.Log(comment);

        continueGoTo = 1;
        timesClicked = timesClicked + 1;
    }
    public void Choice2(Dialogue dialogue)
    {
        comment = dialogue.comments[1];
        Debug.Log("Choice1");
        StartCoroutine(TypeComment(comment));
        Debug.Log(comment);

        continueGoTo = 2;
        timesClicked = timesClicked + 2;
    }
    public void Choice3(Dialogue dialogue)
    {
        comment = dialogue.comments[2];
        Debug.Log("Choice1");
        StartCoroutine(TypeComment(comment));
        Debug.Log(comment);
        continueGoTo = 2;
        timesClicked = timesClicked + 3;
    }
    public void Choice4(Dialogue dialogue)
    {
        comment = dialogue.comments[3];
        Debug.Log("Choice1");
        StartCoroutine(TypeComment(comment));
        Debug.Log(comment);
        continueGoTo = 1;
        timesClicked = timesClicked + 4;
    }
}
