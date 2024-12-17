INCLUDE globals.ink

This is {Name} {Surname}. {Pron} {Pron == "They":were|was} {Age} years old at the time. #Layout:Narrator
{Pron} just came home from a long day and then-
{
-Traits has Indifferent:
    ... #Layout:Player
    {Name} sighed heavily. #Layout:Narrator
->Situation 
-Traits has Rude:
    SHIT!  #Layout:Player #PlayerAnim:Fear
-else: AH! #Layout:Player #PlayerAnim:Fear
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
The Room lay before {Name} {Pron == "They":like they knew it.}{Pron == "He":like he knew it.}{Pron == "She":like she knew it.} #Layout:Narrator #PlayerAnim:default
{Visuals ? Glasses: {Name} pushed {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} glasses up a little.}
The tiny flat rented a few years ago. Usually home. 
Except a book just flew by. It had been the second time this week.
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
{Name} hid behind a Sofa{Visuals?LongHair: pushing a long strand of hair out of {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} face,}{Traits ^ (Confident, Sceptical): feeling very stupid. Like a coward.|.} {Age >60:{Pron == "They":Their}{Pron == "He":his}{Pron == "She":her} old bones grinded at the movement, giving away {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} location away immediatly.} #Layout:Narrator
{Traits ? Sceptical: There wasn't even anything there, was there?, {Pron} thought. But...}
A book just flew by on its own. {Pron == "They": {Pron} were alone in the flat. {Pron} were certain of it.|{Pron} was alone in the flat. {Pron} was certain of it.}
{Traits ? Sceptical: Maybe it was just the wind or something., {Pron} thought, looking for a logical explaination.}
{Traits ? Superstitious: {Pron} did not imagine it flying by. There was a ghost there, right here in the flat.}
{Traits ? Anxious: {Pron == "They":They heard their heart bumping.}{Pron == "He":He heard his heard bumbing.}{Pron == "She":She heard her heart bumping.}|{Pron} took a deep breath.}
->Situation

===Confront===
{Traits ? Anxious: {Name} stepped forward but could't bring {Pron == "They":themselves}{Pron == "He":himself}{Pron == "She":herself} to speak. Fear, first pinning {Pron == "They":them}{Pron == "He":him}{Pron == "She":her} into place, then ushering {Pron == "They":them}{Pron == "He":him}{Pron == "She":her} to hide. -> Hide} {Name} stepped forward bravely. #Layout:Narrator #PlayerAnim:default
The geography book, which just flew through the room lied on the floor, motionless.
    + {Traits ? (Rude, Confident)}[(Insult)] ->Insult
    + {Traits ? (Rude, Confident)}[(Negotiate)] ->Negotiate
    + {Traits ? (Rude, Confident, Sceptical)}[(Doubt)] ->Doubt
    + {Traits ? (Rude, Confident, Superstitious)}[(Accuse)] -> Accuse
    + -> Confront.AutomaticResponse
= AutomaticResponse
{
    -Traits?Confident: ->Negotiate
    -Traits?Rude: ->Insult
    -else: ->Situation
}

===Insult===
Listen here you little shit... {Traits^(Sceptical, Serious): I dont know who {Traits?Serious:or what} you are, but} if you don't stop whatever you are doing, {Traits^(Serious, Sceptical): I will call the cops on you.| {Traits^(Humorous, Superstitious): {Traits^(Sceptical,Serious): Or }I will call a ghosthunter{Traits?Serious:.| and incenseate the hell out of you.}|I might punch you into the next afterlife.}} #Layout:Player #PlayerAnim:default
The book did not move, but {Name} felt an awful shiver run down {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} spine.#Layout:Narrator 
{Traits!? Confident: {Pron} took a step back involuntarily{Traits?Sceptical:, feeling foolish.|.}| {Pron} took a deep breath{Traits?Sceptical: reminding {Pron == "They":themselfes}{Pron == "He":himself}{Pron == "She":herself} that there were nothing and noone there.|{Traits?Serious: not allowing {Pron == "They":themselfes}{Pron == "He":himself}{Pron == "She":herself} to lose composure.|.}}}
->Situation

===Negotiate===
{
    -Traits ? Superstitious:
    Listen, {Traits?Charming: dear} ghost. #Layout:Player
    I don't mind you being here, but could you {Traits!?Rude:please} stop throwing my stuff around? 
    You can live{Traits?Humorous: - or unlive -} here, if you want, but we need to come to an agreement about this.
    -Traits? Sceptical:
    Is someone there? #Layout:Player
    If yes, {Traits!?Rude:please} just leave my flat. {Traits?Serious: I will call the cops on you, if you do not.}
    I can leave you some money on the counter or something, if you stop pestering my life?
    -else:
    What or whoever you are, {Traits!?Rude:please} just leave my appartment. #Layout:Player
    {Traits?Humorous: I get it, it's fun to mess with me, but you're overdoing it.| It is not funny.} Stop, or I will call the cops or a priest or something.
}
As expected, there is no response but silence. #Layout:Narrator
{Traits?Sceptical: {Name} really considered just calling the cops, but had no idea what to tell them exactly and doubted they would even believe {Pron == "They":them}{Pron == "He":him}{Pron == "She":her}.}
->Situation

===Doubt===
Listen, I know ghost do not exist. Could you stop playing fucking pranks on me now? {Traits?Serious: I will call the cops on you if you don't.} #Layout:Player #PlayerAnim:default
As expected, there is no response but silence. #Layout:Narrator
{Name} really considered just calling the cops, but had no idea what to tell them exactly and doubted they would even believe {Pron == "They":them}{Pron == "He":him}{Pron == "She":her}. 
->Situation

===Accuse===
Listen, I know you are a ghost. Is it fun to scare me like this? #Layout:Player #PlayerAnim:default
As expected, there is no response but silence. #Layout:Narrator
->Situation


===Situation===
{Visuals!?Bald:{Pron} stepped forward and pushed {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} {Visuals?ShortHair:short }{Visuals?LongHair:long }hair back.|}
{Name} is currently in a very {Traits?Inquisitive:interesting|{Traits?Indifferent:annoying|confusing}} situation. #Layout:Narrator #PlayerAnim:default
Since two months now some strange things had been happening in {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} flat. {Age>50:Something {Pron == "They":they}{Pron == "He":he}{Pron == "She":she} had never experienced before, in all {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} years of living.}
It started with things not being where they should be but at various {Traits?Rude:fucked up|curious} locations.
{Pron == "They":Their}{Pron == "He":His}{Pron == "She":Her} mobile phone in the fridge, keys inside the kitchen cupboard, soap under the sink instead of on it...
{Traits ? Sceptical: {Name} had brushed it off as forgetfullness{Traits?Anxious: but you could never be too sure|.}.|{Traits ? Superstitious: {Name} had {Traits?Confident:immediately} known it was a ghost or worse, a demon{Traits?Anxious:, but {Name} had been to afraid to investigate much further.|.}|{Traits ? Indifferent:{Name} hadn't thought about it much.|It was weird but probably nothing.}}}  
But then even {Traits?Rude: more fucked up|weirder} stuff happend.
The electricity went crazy. Light switched on and off, power chargers stopped working and {Pron == "They":they}{Pron == "He":he}{Pron == "She":she} often heard an electric ringing sound. 
{Traits!?Superstitious: {Pron} of course had checked the cables and even called a specialist, but everytime an expert came looking, everything was fine.|{Pron} had checked every forum and book available and everything hinted to paranormal activity.}
Lastly wilder stuff had happend. {Traits?Sceptical: Everything else {Name} could explain logically, with stress, forgetfullness and a power overload or something, but|Clearly} something was off. 
{Pron} actively noticed stuff moving on its own. Once {Pron == "They":they}{Pron == "He":He}{Pron == "She":she} had even seen a shadow creeping through the room.
That was the point {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} best friend had insisted, {Pron == "They":they}{Pron == "He":he}{Pron == "She":she} should call a ghosthunter.
{Traits^(Sceptical, Humorous):{Name} heavily concidered calling a therapist instead.}
{Hidden:Carefully {Name} got to their feet again, stepping forward from behind the sofa. {Pron} didnt fancy to hide within their own flat forever.|{Name} looked at the geography book that had just flown across the room and sighed. This could not go on forever and moving was not an option.}
{Pron} pulled out {Pron == "They":their}{Pron == "He":his}{Pron == "She":her} smartphone and looked at the number of the ghosthunter, {Pron == "They":their bestfriend had given them.}{Pron == "He":his bestfriend had given him.}{Pron == "She":her bestfriend had given her.}
+[(Call them to move forward.)]
{Traits?Sceptical: {Pron} still couldn't quite belived it but...} {Pron} diled in the number. 
... #System:LoadNextStory
->END
+[(Edit Character and start again.)]
#System:CharacterCreator
->END