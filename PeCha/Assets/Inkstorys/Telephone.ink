INCLUDE globals.ink
{
    -Visuals?Female:
    ~Sal = "Ms."
    ~Anrede = "Ma'am"
    
    -Visuals?Male:
    ~Sal = "Mr."
    ~Anrede = "Sir"
    
    -else:
    ~Sal = "Mx."
    ~Anrede = "Captain"
}

Hello? #Layout:NPC
* {Traits?Rude} Wow[, really?], this is how you answer the phone? #Layout:Player
It is. Can I help you, {Anrede}, or do you just want to berate me? #Layout:NPC
** Sorry. #Layout:Player
Already forgotten. Jesaja Bevan here, how can I help you? #Layout:NPC
->Who
** Will you tell me your name? #Layout:Player
Jesaja Bevan. Your turn. #Layout:NPC
->Who
** {Visuals?Female} {Pron!="She"} Don't call me that. #Layout:Player
->Gender
** {Visuals?Male} {Pron!="He"} Don't call me that. #Layout:Player
->Gender
** ->Who
* Hello. #Layout:Player
This is Jesaja Bevan...#Layout:NPC
...Who is there?
->Who
* Is this[...] the ghosthunter? #Layout:Player
Yes, it is. Jesaja Bevan, at your service, {Anrede}. #Layout:NPC
** {Visuals?Female} {Pron!="She"} Don't call me that. #Layout:Player
->Gender
** {Visuals?Male} {Pron!="He"} Don't call me that. #Layout:Player
->Gender
** {Visuals?Female} {Pron!="She"} [Introduce yourself] ->Who 
** {Visuals?Male} {Pron!="He"} [Introduce yourself] ->Who
** ->Who

VAR genCor = false
===Gender===
~genCor = true
Sorry? What? #Layout:NPC
* My prononce are[...] {Pron == "They":They/Them}{Pron == "He":He/Him}{Pron == "She":She/Her}, actually. I don't want you to call me {Anrede}.#Layout:Player
Oh, sorry, my bad. Is {Pron == "They":..."Captain" okay?}{Pron == "He":"Sir" okay?}{Pron == "She":"Ma'am" okay?} #Layout:NPC
**Yes. #Layout:Player
{
    -Pron == "They":
    ~Sal = "Mx."
    ~Anrede = "Captain"
    -Pron == "He":
    ~Sal = "Mr."
    ~Anrede = "Sir"
    -Pron == "She":
    ~Sal = "Ms."
    ~Anrede = "Ma'am"
}
Alright, {Anrede}. Sorry again. Now, how can I help you? #Layout:NPC
->Who
**No. #Layout:Player
What should I call you then? #Layout:NPC
*** Sir/Mr. #Layout:Player
    ~Sal = "Mr."
    ~Anrede = "Sir"
*** Ma'am/Ms. #Layout:Player
    ~Sal = "Ms."
    ~Anrede = "Ma'am"
*** Captain/Mx. #Layout:Player
    ~Sal = "Mx."
    ~Anrede = "Captain"
*** {Traits?Serious} [Last name] 
Just call me by my last name. #Layout:Player
    ~Sal = ""
    ~Anrede = Surname
*** {Traits!?Serious} [Just use my first name.]
Just call me {Name}. #Layout:Player
    ~Sal = ""
    ~Anrede = Name
    ~Surname = Name
--- Alright, {Anrede},{Anrede == Name: you can call me Jesaja then. How can I help you now?| how can I help you now?} #Layout:NPC
->Who
* Nevermind... #Layout:Player
Okay? Then... How can I help you, please? #Layout:NPC
->DONE

===Who===
I am {Name} {Surname}{Traits?Anxious:, sorry for bothering you this late|{Traits?Confident:. I know it is late| it is nice to meet you}}, but... #Layout:Player
{
    -Traits?Sceptical: 
{Name} pauses for a second, sighing. #Layout:Narrator
Sorry, I know how rediculous this sounds, but my best friend suggested, I might call you, because I got a- {Traits?Serious:- (I can't believe I am saying this)} ... "ghostproblem".#Layout:Player
    You're calling a ghosthunter, denying the existence of ghosts...  Don't worry, I don't think you're crazy. #Layout:NPC
    -Traits?Superstitious:
    I just KNOW my appartment is haunted. {Traits!?Serious: I've already tried so much-} #Layout:Player
    alright alright! I believe you. #Layout:NPC
    -else:
    {Traits^(Serious, Indifferent, Sceptical):(Sigh) }I think, my appartment might be haunted. #Layout:Player
}
Good thing, you are calling me, this is my area of expertice! #Layout:NPC
Please tell me in detail what happend, {Sal} {Surname}.
*Ok, so[...] this happend.#Layout:Player
* {Traits?Charming} [Flirt.] Why don't we talk about you first? #Layout:Player
You sound cute.
(Silence) #Layout:NPC
{Anrede}, this is a buisness call. Let's go back to the important part.
* {Traits?(Rude, Sceptical)} [Doubt.]
I still can't belive we are talking about this, like it's real. #Layout:Player
{Anrede}, I understand, that this is a confusing situation, but I assure you, you made the right call. Literally. #Layout:NPC
Anyways... Please just tell me what happend.
-{Name} explained the situation in great detail. #Layout:Narrator
->DONE