using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Ink.Runtime;

public class InkVariables 
{
    public Dictionary<string, Ink.Runtime.Object> variables;

    public InkVariables(string globalFilePath)
    {
        string inkFileContents = File.ReadAllText(globalFilePath);
        Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        Story globalVariableStory = compiler.Compile();

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariableStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariableStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
        }
    }

    private void filltraitList()
    {
        //use prioritized trait list to fill "characterTraits" LIST in Ink
    }

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
        if(variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
