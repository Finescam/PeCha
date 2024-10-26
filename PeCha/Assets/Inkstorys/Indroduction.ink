INCLUDE globals.ink

This is name is {Name} {Surname}. {Pron} {Pron == "They": are | is} currently {Age} years old. #Layout:Narrator
I have a problem. #Layout:Player
{
    - Traits has Sceptical:
    I really don't believe in this stuff, but my best friend insist, we should check it out.
    - Traits has Superstitious:
    A {Traits hasnt Charming: goddamn} demon, or something, I swear! 
    
    -else:
    I know it sounds crazy, but...
}
I {Traits hasnt Superstitious: apparently} have a ghost in my room{Traits has Sceptical:...|!}
I am now on my way to meet up with a ghost hunter. 
{
    -Traits has Anxious: 
    I am kind of scared to meet them. I don't really enjoy talking to people. {Traits has Humorous: Maybe I should just chill out with that ghost, at least it doesn't talk! {Traits has Superstitious:...yet.|hah-}}
    Anyways...
    -Traits has Charming:
    {Traits has Anxious: But...} I really hope they can help me out here.
    -Traits has Rude:
    {Traits has Anxious: But...If hunting ghosts is really their main job, then I should not be the oddest one there. I mean...} Who the hell is ghosthunter for a living? {Traits has Sceptical: That shit is not even real.}  
    Anyways...
}
I should probably go now. 
* [(Go on)]
#System:LoadNextStory
->DONE
* [(Go back to Character Creator)]
#System:CharacterCreator
->END