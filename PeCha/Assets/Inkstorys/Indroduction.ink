INCLUDE globals.ink

Hi, my name is {Name} {Surname}. I am currently {Age} years old.
I have a problem. 
{
    - Traits has Realistisch:
    I really don't believe in this stuff, but my roommate insist, we should check it out.
    - Traits has Abergläubisch:
    A goddamn demon, or something, I swear! 
    
    -else:
    I know it sounds crazy, but...
}
I {Traits hasnt Abergläubisch: apparently} have a ghost in my room{Traits has Realistisch:...|!}
I am now on my way to meet up with a ghost hunter. 
{
    -Traits has Schüchtern: 
    I am kind of scared to meet them. I don't really enjoy talking to people. {Traits has Sarkastisch: Maybe I should just chill out with that ghost, at least it doesn't talk! {Traits has Abergläubisch:...yet.|hah-}}
    Anyways...
    -Traits has Höflich:
    {Traits has Schüchtern: But...} I really hope they can help me out here.
    -Traits has Unhöflich:
    {Traits has Schüchtern: But...If hunting ghosts is really their main job, then I should not be the oddest one there. I mean...} Who the hell is ghosthunter for a living? {Traits has Realistisch: That shit is not even real.}  
    Anyways...
}
I should probably go now. 
* [(Go on)]
#System:LoadNextStory
->DONE
* [(Go back to Character Creator)]
#System:CharacterCreator
->END