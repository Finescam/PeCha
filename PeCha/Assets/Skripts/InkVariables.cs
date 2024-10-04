using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkVariables 
{
    public Dictionary<string, Ink.Runtime.Object> variables;
    Story globalVariableStory;

    public InkVariables(TextAsset loadGlobalJSON)
    {
        globalVariableStory = new Story(loadGlobalJSON.text);

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariableStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariableStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
        }
    }


    //public void filltraitList(List<string> traits)
    //{
    //    var currentTraits = new Ink.Runtime.InkList("characterTraits", globalVariableStory)
    //}        

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

   private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
