using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button[] answerButtons;
    public TextMeshProUGUI[] buttonTexts;
    public GlobalVariables GV;

    private List<string> dialogueLines;
    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool isQuestionActive = false;
    void Start()
    {
        foreach(Button button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
    
    public void StartSignal()
    {
        TextAsset textScript = GV.getScript();
        string script = textScript.text;
        dialogueLines = new List<string>(script.Split('\n'));

        currentLineIndex = 0;
        StartCoroutine(DisplayLine());
    }
    private IEnumerator DisplayLine()
    {
        isTyping = true;
        dialogueText.text = "";
        string line = dialogueLines[currentLineIndex];

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;

        //***********CODE CHANGED HERE**********
        CheckForQuestion();
        //***********CODE CHANGED HERE**********
    }

    private void CheckForQuestion()
    {
        int result = 0;
        Int32.TryParse(dialogueLines[currentLineIndex + 1], out result);
        
        if (currentLineIndex + 1 < dialogueLines.Count && result == 1101588)
        {
            Debug.Log("We in");
            isQuestionActive = true;
            ShowQuestion();
        }else{
            Debug.Log("Its so over");
        }
    }

    private void ShowQuestion()
    {
        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].gameObject.SetActive(true);
            buttonTexts[i].text = dialogueLines[currentLineIndex + 2 + i].Substring(1);
            int isCorrect = dialogueLines[currentLineIndex + 2 + i][0] - '0';
            int responseIndex = currentLineIndex + 6 + i;

            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => SelectAnswer(isCorrect, responseIndex));
        }
    }

    private void SelectAnswer(int isCorrect, int responseIndex)
    {
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }

        dialogueText.text = dialogueLines[responseIndex];

        currentLineIndex = responseIndex + 1;
        while (currentLineIndex < dialogueLines.Count && dialogueLines[currentLineIndex] != "8675309")
        {
            currentLineIndex++;
        }
        currentLineIndex++; 
        isQuestionActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLineIndex];
                isTyping = false;
                //***********CODE CHANGED HERE**********
                CheckForQuestion(); // Ensure skipping doesn't miss the question check
                //***********CODE CHANGED HERE**********
            }
            else if (!isQuestionActive)
            {
                currentLineIndex++;
                if (currentLineIndex < dialogueLines.Count)
                {
                    StartCoroutine(DisplayLine());
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
