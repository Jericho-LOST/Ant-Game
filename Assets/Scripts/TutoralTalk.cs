using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutoralTalk : MonoBehaviour
{

    // this script will be given to the "Trigger" or diolouge manager (whichever sounds cooler)


    public Text dialogueText; //how many of these do i need?
   // public GameObject dialogueManager; // this will be a empty game opbject that is a child of whatever platform want to triget the dialouge 
    public GameObject dialogueBox;  //the pannel 
    public string[] dialogueLines;  
    public float textSpeed = 0.05f;
   public GameObject fullSprite;
    public AudioSource TalkSound;


    private int currentLineIndex = 0;  //i wanted fancy type writer-transition text (this just tracks the crrent line of dialogue)
    private bool isTyping = false;  // Checks if the text is still typing
    private bool dialogueActive = false;  // Checks if dialogue is active..dont know how the two are different tbh-
    
  
    
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.F))
        {
            if (isTyping)
            {
                // If the player presses F while text is typing this finishes the line instantly
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLineIndex];
                isTyping = false;
            }
            else
            {
                // Shows the next line of dialogue
                NextLine();
            }
        }
    }
    public void Start()
    {
        StartDialogue();
    }
    public void StartDialogue()
    {
        // Activate the dialogue box and start with the first line
        dialogueBox.SetActive(true);
        dialogueActive = true;
        currentLineIndex = 0;
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            // End the dialogue when all lines are shown
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        TalkSound.Play();
        dialogueText.text = ""; 

        // Type each character one by one
        foreach (char c in dialogueLines[currentLineIndex].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueActive = false;
        fullSprite.SetActive(false);
    }

    //just me trying to figure out how to do it when object touches player
   // void OnTriggerEnter(Collider other)
   // {
     //   if (other.gameObject.name == "Player")
       // {
         //   StartDialogue();

        //}
   // }
}

