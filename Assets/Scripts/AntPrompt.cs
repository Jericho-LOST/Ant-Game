                 using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AntPrompt: MonoBehaviour
{
//this is the TutorialTalk script but is prompted when the player presses T when in proximity to an AntBox


    public Text dialogueText;
    public GameObject dialogueBox; 
                
    public string[] dialogueLines;
    public GameObject pressT;//the "press T to Talk" notif that shows up for the player
    public float textSpeed = 0.05f;
    public GameObject fullSprite; //this helps the box dissapear (i oriiginally used it to switch sprites during diolouge scenes)


    
    private int currentLineIndex = 0;  
    private bool isTyping = false;  
    private bool dialogueActive = false;

    private void Start()
    {
        dialogueBox.SetActive(false);
        pressT.SetActive(false);
    }
    

    
    

        private void OnCollisionEnter(Collision collision)
        {

        if (collision.gameObject.CompareTag("Ant"))
        {
            pressT.SetActive(true);
        }


        if (collision.gameObject.CompareTag("Ant"))// && Input.GetKeyDown(KeyCode.T)) //!! code won't repond to input // needs to heva an "on trigger enter" (and exit) rather than collider

        {
            StartDialogue();
            pressT.SetActive(false);
            Debug.Log("anything");
        }

    }
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
                // Show the next line of dialogue
                NextLine();
            }
        }
    }

    public void StartDialogue()
    {
        // this activateas the dialogue box and starts the first line
       // pressT.SetValue(true);
        dialogueBox.SetActive(true);
        dialogueActive = true;
        fullSprite.SetActive(true);
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

