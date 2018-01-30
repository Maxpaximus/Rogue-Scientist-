using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string npcName;

    [TextArea(4, 10)]
    public string[] sentences;
    public string[] sentences1;
    public string[] sentences2;
    public string[] sentences3;
    public string[] sentences4;
    public string[] sentences5;
    public string[] sentences6;
    public string[] sentences7;

    public float[] choiceValues;

    [TextArea(3, 10)]
    public string[] choices;

    [TextArea(3, 10)]
    public string[] comments;
}
