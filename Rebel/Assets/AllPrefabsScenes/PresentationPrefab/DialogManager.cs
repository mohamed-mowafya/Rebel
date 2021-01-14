using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animation;

    private Queue<string> phrases;
    // Start is called before the first frame update
    void Start()
    {
        phrases = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {

        animation.SetBool("EstOuvert", true);
      
        nameText.text = dialogue.nom;

        phrases.Clear();
        foreach (string phrase in dialogue.phrases )
        {
            phrases.Enqueue(phrase);
            
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(phrases.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = phrases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
       
        animation.SetBool("EstOuvert", false);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
