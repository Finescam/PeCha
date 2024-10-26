INCLUDE globals.ink
Hi, I am an NPC. #Layout:NPC
I guess you are {Name}? 
{   
    -Traits has Rude:
    + Who wants to know? #Layout:Player
    ->secondText
}
+ I am. #Layout:Player
Great! I Am X. #Layout:NPC
->secondText

===secondText===
What are your Prononce?#Layout:NPC
+ [{{Pron == "They":They/Them} | {Pron == "He": He/Him}| {Pron == "She": She/Her}}]
Great. Mine are x/x.
->third
+ [Choose for me.]
You look like a {Pron} to me.
->third
+ [I dont have any.]
Then I can not refere to you.
->third

===third===
This is third
-> END