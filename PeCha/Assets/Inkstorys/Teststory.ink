INCLUDE globals.ink
Hi, I am an NPC.
I guess you are {Name}?
{   
    -Traits has Unhöflich:
    + Who wants to know?
    ->secondText
}
+ I am.
Great! I Am X.
->secondText

===secondText===
What are your Prononce?
+ [{Pron0}/{Pron1}]
Great. Mine are x/x.
->third
+ [Choose for me.]
You look like a {Pron0} to me.
->third
+ [I dont have any.]
Then I can not refere to you.
->third

===third===
This is third
-> END