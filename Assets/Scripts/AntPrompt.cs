using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AntPrompt: MonoBehaviour
{
//this is the TutorialTalk script but is prompted when the player presses T when in proximity to an AntBox


    public Text dialogueText;
    public GameObject dialogueBox; 
   // public GameObject AntBox; // this detects if you are in contact with the box//in the vecinity 
    public string[] dialogueLines;
    public GameObject pressT;//the "press T to Talk" notif that shows up for the player
    public float textSpeed = 0.05f;
    public GameObject fullSprite; //this helps the box dissapear (i oriiginally used it to switch sprites during diolouge scenes)


    private bool isNearAnt = false; //checking if player is near ant//object i want to trigger diolouge 
    private int currentLineIndex = 0;  
    private bool isTyping = false;  
    private bool dialogueActive = false;

    private void Start()
    {
        dialogueBox.SetActive(false);
    }
    

    
    void Update()
    {

        if (isNearAnt && Input.GetKeyDown(KeyCode.T)) // T to talk makes sence right?
        {
            StartDialogue(); // this should start the diologe when the player is in proximity and presses T 
        }



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
                // Show the next line of dialogue
                NextLine();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearAnt = true;
        }
    }

    private void OnTriggerExit(Collider other) //genuinely diddn't know "on trigger exit" exitsted (this checks if player has left the "trigger Zone")
    {
        if (other.CompareTag("Player"))
        { isNearAnt = false;}
    }
    public void StartDialogue()
    {
        // Activate the dialogue box and start with the first line
       // pressT.SetValue(true);
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
      //pressT.SetValue(false);
            
    }
}

