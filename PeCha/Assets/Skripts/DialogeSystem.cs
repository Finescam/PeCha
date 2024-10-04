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
    [SerializeField] private TextAsset loadGlobalsJSON;
    [SerializeField] private List<TextAsset> inkJSONs;
    [SerializeField] string inkVariables;
    public int i; //Where we are in the story/which story to load from inkJSON list
    private Story currentInkStory;
    private InkVariables inkVars;
    private bool dialogeIsPlaying;

    [Header("SriptRefs")]
    private static DialogeSystem instance;
    [SerializeField] PlayerCharacter playChar;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogWarning("More than one DialogeSystem");

        inkVars = new InkVariables(loadGlobalsJSON);
    }

    private void Start()
    {
        //inkVars.SetListInInk(playChar.prioritizedTraits);
        
        dialogeIsPlaying = false;
        NPCDialogePanel.SetActive(false);

        //Aline choicestext with UI
        choicesText = new TextMeshProUGUI[choicesUI.Length];
        int index = 0;
        foreach (GameObject choice in choicesUI)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogeIsPlaying)
            LoadDialoge();

        //dont continue story if there are choices
        if (currentInkStory.currentChoices.Count != 0)
            return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (currentInkStory != null)
                ContinueDialoge();
            else
                ExitDialoge();
        }
    }

    private void SetPlayerName(string playname)
    {
        currentInkStory.variablesState["playerName"] = playname;
    }

    public void FillTraitList(List<string> traits)
    {
        var currentTraits = new Ink.Runtime.InkList("characterTraits", currentInkStory);
        foreach (string trait in traits)
        {
            currentTraits.AddItem(trait);
        }
        currentInkStory.variablesState["characterTraits"] = currentTraits;
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
        inkVars.StartListening(currentInkStory);
        SetPlayerName(playChar.characterName);
        FillTraitList(playChar.prioritizedTraits);

        ContinueDialoge();       
    }

    public void ExitDialoge()
    {
        inkVars.StopListening(currentInkStory);
        dialogeIsPlaying = false;
        NPCDialogePanel.SetActive(false);
        NPCDialogeText.text = "";
    }

    private void ContinueDialoge()
    {
        if (currentInkStory.canContinue)
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
        ContinueDialoge();
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        inkVars.variables.TryGetValue(variableName, out variableValue);
        if(variableValue == null)
        {
            Debug.LogWarning("Ink Variable was null: " + variableName);
        }
        return variableValue;
    }
}
