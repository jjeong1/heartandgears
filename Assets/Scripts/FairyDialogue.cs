using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyDialogue : MonoBehaviour {

    public Dialogue dialogue;
    public void Start ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
