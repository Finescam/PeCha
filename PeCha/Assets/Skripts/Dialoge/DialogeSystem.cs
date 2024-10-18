using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogeSystem : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] private GameObject DialogeUI;
    [SerializeField] TextMeshProUGUI DialogeText;
    [SerializeField] private GameObject choicesBG;
    [SerializeField] private GameObject[] choicesUI;
    private TextMeshProUGUI[] choicesText;

    [Header("Ink")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    [SerializeField] private List<TextAsset> inkJSONs;
    [SerializeField] string inkVariables;
    public int i; //Where we are in the story/which story to load from inkJSON list
    public Story currentInkStory;
    private InkGlobal inkGlobal;
    private bool dialogeIsPlaying;

    [Header("SriptRefs")]
    public static DialogeSystem instance;
    TagBehavior tagScript;
    InkVars playVars;
    [SerializeField] PlayerCharacter playChar;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogWarning("More than one DialogeSystem");

        inkGlobal = new InkGlobal(loadGlobalsJSON);
        playVars = GetComponent<InkVars>();
        tagScript = GetComponent<TagBehavior>();
    }

    private void Start()
    {
        dialogeIsPlaying = false;
        DialogeUI.SetActive(false);

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
        DialogeUI.SetActive(true);
        currentInkStory = new Story(inkJSON.text);
        dialogeIsPlaying = true;
        inkGlobal.StartListening(currentInkStory);
        playVars.LoadCharacter();
        ContinueDialoge();       
    }

    public void ExitDialoge()
    {
        inkGlobal.StopListening(currentInkStory);
        dialogeIsPlaying = false;
        DialogeUI.SetActive(false);
        DialogeText.text = "";
    }

    private void ContinueDialoge()
    {
        if (currentInkStory.canContinue)
        {
            DialogeText.text = currentInkStory.Continue();
            DisplayChoices();
            tagScript.HandleTags(currentInkStory.currentTags);
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
            choicesBG.SetActive(true);
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
        choicesBG.SetActive(false);
        currentInkStory.ChooseChoiceIndex(choiceIndex);
        ContinueDialoge();
    }

    //ink variables
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        inkGlobal.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was null: " + variableName);
        }
        return variableValue;
    }
}
