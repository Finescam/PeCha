INCLUDE globals.ink

This was {Name} {Surname}. {Pron == "They":were|was}  {Age} years old at the time. #Layout:Narrator
{
-Traits has Indifferent:
    ... #Layout:Player
    {Name} sighed heavily. #Layout:Narrator
->Situation 
-Traits has Rude:
    SHIT!  #Layout:Player
-else: AH! #Layout:Player
} 
It happened again!
+ {Traits ^(Sceptical,Inquisitive, Confident)}[(Investigate)] ->Investigate
+ {Traits ^ (Anxious, Superstitious)}[(Hide)] ->Hide
+ {Traits ^ (Confident, Rude)} [(Confront)] ->Confront
+ {Traits ^ (Sceptical, Inquisitive,Anxious, Superstitious,Confident, Rude)}[(Do nothing)]
{Name} just stood there, flabbergasted.
    ->Situation
+ -> Situation


=== Investigate ===
The Room lied before {Name} {Pron == "They":like they knew it.}{Pron == "He":like he knew it.}{Pron == "She":like she knew it.} #Layout:Narrator
{Visuals ? Glasses: {Name} pushed {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} glasses up a little.}
The tiny flat rented a few years ago. Usually home. 
Except a book just flew bye. It had been the second time this week.
{
    -Traits has Inquisitive:
    It was super exiting.
    -Traits has Sceptical:
    Usually {{Pron == "They":they did} | {Pron == "He":he did}| {Pron == "She":she did}} not believe in this kind of stuff, but evidence was going strong.
    Either that or someone was playing a horrible prank on {Pron == "They":them.}{Pron == "He":him.}{Pron == "She":her.}
}
{
- Traits has Superstitious:
    {Traits ? Confident: It was sure as day:} A ghost. Defintitly., {Pron} thought.
}
{ 
    -Traits !? Anxious:
    {Name} took a step forward to get a better look.
    -else:
    {Name} was to afraid to investigate further. -> Situation
}
The copy of an old school atlas lay motionless on the floor. 
{Traits ? Humorous: {Traits ? Sceptical: If there really was one:} The ghost clearly didn't fancy geology, {Name} thought, smiling a little.}
->Situation

VAR Hidden = false
===Hide===
~ Hidden = true
{Name} hid behind a Sofa{Traits ^ (Confident, Sceptical): feeling very stupid. Like a coward.|.} #Layout:Narrator
{Traits ? Sceptical: There wasn't even anything there, was there?, {Pron} thought. But...}
A book just flew by on its own. {Pron == "They": {Pron} were alone in the flat. {Pron} were certain of it.|{Pron} was alone in the flat. {Pron} was certain of it.}
{Traits ? Sceptical: Maybe it was just the wind or something., {Pron} thought, looking for a logical explaination.}
{Traits ? Superstitious: {Pron} did not imagine it flying by. There was a ghost there, right here in the flat.}
{Traits ? Anxious: {Pron == "They":They heard their heart bumping.}{Pron == "He":He heard his heard bumbing.}{Pron == "She":She heard her heart bumping.}|{Pron} took a deep breath.}
->Situation

===Confront===
{Traits ? Anxious: {Name} stepped forward but could't bring {Pron == "They":themselves}{Pron == "He":himself}{Pron == "She":herself} to speak. Fear, first pinning {Pron == "They":them}{Pron == "He":him}{Pron == "She":her} into place, then ushering {Pron == "They":them}{Pron == "He":him}{Pron == "She":her} to hide. -> Hide} {Name} stepped forward bravely. #Layout:Narrator
The geography book, which just flew through the room lied on the floor, motionless.
    + {Traits ? (Rude, Confident)}[(Insult)] ->Insult
    + {Traits ? (Rude, Confident)}[(Negotiate)] ->Negotiate
    + {Traits ? (Rude, Confident, Sceptical)}[(Question)] ->Question
    + {Traits ? (Rude, Confident, Superstitious)}[(Accuse)] -> Accuse
    + -> Confront.AutomaticResponse
= AutomaticResponse
{
-Traits?Confident: ->Negotiate
    -Traits?Rude: ->Insult
    -else: ->Situation
}

===Insult===
Listen here you little shit... {Traits^(Sceptical, Serious): I dont know who {Traits?Serious:or what} you are, but} if you don't stop whatever you are doing, {Traits^(Serious, Sceptical): I will call the cops on you.| {Traits^(Humorous, Superstitious): {Traits^(Sceptical,Serious): Or }I will call a ghosthunter{Traits?Serious:.| and incenseate the hell out of you.}|I might punch you into the next afterlife.}} #Layout:Player
The book did not move, but {Name} felt an awful shiver run down {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} spine.#Layout:Narrator
{Traits!? Confident: {Pron} took a step back involuntarily{Traits?Sceptical:, feeling foolish.|.}| {Pron} took a deep breath{Traits?Sceptical: reminding {Pron == "They":themselfes}{Pron == "He":himself}{Pron == "She":herself} that there were nothing and noone there.|{Traits?Serious: not allowing {Pron == "They":themselfes}{Pron == "He":himself}{Pron == "She":herself} to lose composure.|.}}}
->Situation

===Negotiate===
negotioation
->Situation
===Question===
->Situation
===Accuse===
->Situation


===Situation===
{Pron} {Pron == "They": are | is} currently in a very confusing situation. #Layout:Narrator
Since two months now some strage things had been happening in {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} flat.
It started with things not being where they should be but at various curious locations.
{Pron == "They":Their}{Pron == "He":His}{Pron == "She":Her} mobile phone in the wridge, keys on the kitchencupboard, soap under the sink instead of on it... 
{Traits ? Sceptical: {Name} had brushed it off as forgetfullness.|{Traits ? Superstitious: {Name} had immediately known it was a ghost or worse, a demon.|{Traits ? Indifferent:{Name} hadn't thought about it much.|It was weird but probably nothing, {Name} thought.}}}  
But then even weirder stuff happend.
//explain situation and that they need to get in touch with a ghosthunter
{Name} looked at the number of the ghosthunter, {Pron == "They":their bestfriend gave them.}{Pron == "He":his bestfriend gave him.}{Pron == "She":her bestfriend gave her.}
+[(Call them)]
//make some personalised reaction here 
... #System:LoadNextStory
->END
+[(Edit Character)]
#System:CharacterCreator
->END