using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class txt
{
    public string name;

    //min to max amount of text lines
    [TextArea(3, 10)]
    public string[] sentences;
}
