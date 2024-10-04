using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogeSystem : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] private GameObject NPCDialogePanel;
    [SerializeField] private TextMeshProUGUI NPCDialogeText;
    [SerializeField] private GameObject playerDialogePanel;
    [SerializeField] private GameObject[] choicesUI;
    private TextMeshProUGUI[] choicesText;

    [Header("Ink")]
    [SerializeField] private List<TextAsset> inkJSONs;
    public int i; //Where we are in the story/which story to load from inkJSON list
    private Story currentInkStory;
    private bool dialogeIsPlaying;

    private static DialogeSystem instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogWarning("More than one DialogeSystem");

        dialogeIsPlaying = false;
        NPCDialogePanel.SetActive(false);

        //Aline choicestext with UI
        choicesText = new TextMeshProUGUI[choicesUI.Length];
        int index = 0;
        foreach(GameObject choice in choicesUI)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogeIsPlaying)
            LoadDialoge();

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (currentInkStory != null)
                ContinueDialoge(currentInkStory);
            else
                ExitDialoge();
        }
    }

    public void LoadDialoge()
    {
        if (i < inkJSONs.Count -1)
        {
            i++;
            StartDialoge(inkJSONs[i]);
        }
    }

    public void StartDialoge(TextAsset inkJSON)
    {
        NPCDialogePanel.SetActive(true);
        currentInkStory = new Story(inkJSON.text);
        dialogeIsPlaying = true;

        ContinueDialoge(currentInkStory);       
    }

    public void ExitDialoge()
    {
        dialogeIsPlaying = false;
        NPCDialogePanel.SetActive(false);
        NPCDialogeText.text = "";
    }

    private void ContinueDialoge(Story story)
    {
        if (story.canContinue)
        {
            NPCDialogeText.text = currentInkStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialoge();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentInkStory.currentChoices;

        if(currentChoices.Count > choicesUI.Length)
        {
            Debug.LogWarning("More Choices than UI can support");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choicesUI[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i<choicesUI.Length; i++)
        {
            choicesUI[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentInkStory.ChooseChoiceIndex(choiceIndex);
        ContinueDialoge(currentInkStory);
    }
}
