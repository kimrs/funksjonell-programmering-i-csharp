# funksjonell-programmering-i-csharp
A presentation that I will do at OPKOKO 23.2 Tyrifjord og P2P OPK1D Katrineholm

## Roadmap

What they | Before | After
Believe   |
Feel      |
Do        |         

Før
Hva vet de?
  * Kode må struktures godt for å kunne vedlikeholdes
Hva tror de?
  * Funksjonel programmering er fint men passer ikke problemene våre
    * Funksjonelle språk er skikkelig bra FOR ENKELTE PROBLEMER
    * Videoprocessering også videre
  * Kompakt kode er ikke lesbart
Hva føler de?
 * Oppgitt
 * Selvsikker
Hva gjør de?
  * Skriver muterbar kode
  * Nullchecker
  * Bruker mye tid på bugs

Etter
Hva gjør de?
  * Skriver immuterbar kode
  * Uten nullchek
Hva føler de
  * Motivert
  * Nyskjerrig
Hva tror de?
  * Funksjonell programmering passer alle problemer
  * Hjelper oss å skrive bedre kode
Hva vet de?
  * Hvordan progge funksjonelt
  * Hvordan bruke kjærnefunksjonene til å skrive sikrere kode

Hvordan kan jeg få dem dit?
Alt jeg hater med imperativ koding er løst i funksjonell
Funksjonell koding passer fint i vårt domene
De fleste nye språk er funksjonelle
Desverre får vi ikke lov til å kode i F#, men det gjør ikke noe.

Vise dem kjærnefunksjonene
Demonstrere dem
Livekoding


## Bilde 1 - Intro
Hei, mitt navn er Kim Rune. Jeg har jobbet i Omegapoint i snart 5 år nå og er advocate i Domain Driven Design.
Mesteparten av dagen min går med til å lese kode. Også bruker jeg litt tid på å skrive kode. Dette gjelder sikkert dere også,
så vi kan enes om en ting. Vi bruker mindre tid på å sette oss inn i velstrukturert kode enn dårlig strukturert kode.
Det er ikke en kontroversiell påstand, men ofte enes vi ikke helt om hvordan vi skaper velstrukturert kode.
Clean Code er et begrep jeg hører alt for ofte. Folk leste boka for 15 år siden og husker nå bare de enkleste tingene fra den.
For eksempel at metoder skal ha maks 3 linjer. Så nå gjemmer de koden sin i metoder som om de egentlig skammer seg over den. 
Er vi allergisk mot kode eller?
Så har vi SOLID da, som er enda eldre enn Clean Code. Så folk som satte seg inn i prinsippene for hundre år siden husker nå bare at det
er noe som heter Single Responsibility Principle. Det prinsippet er så vagt at det ikke betyr noe.


"Any fool can write code that a computer can understand. Good programmers write code that humans can understand." 
- Refactoring, Martin Fowler with Kent Beck, 1996

Koden vi skriver er i stor grad måten vi kommuniserer til resten av teamet.



Når jeg argumenterer for funksjonelle språk får jeg av og til høre frasen.
Ja, funksjonelle språk egner seg veldig godt FOR ENKELTE PROBLEMER.
Det var mer vanlig å si dette for 10-15 år siden. Da sa til og med jeg det også.
Det var bare en generelt vanlig ting å si.
Jeg tror grunnen til at folk sier dette er at de testet et funksjonlelt språk en gang i bildeprosseserings faget på universitetet og så
hvor passende det var for akkurat den oppgaven. Samtidig som de manglet fantasien
til å se for seg hvordan bruke det i andre sammenghenger. Også hørte de noen si
"Ja, Funksjonelle språk egner seg veldig godt for enkelte problemer". Og så  begynte de 
å si det selv.

Problemet jeg har med frasen er at man implisit sier at det ikke passer vårt domene. Holdninger som dette har
gjort meg mindre interresert i funksjonelle språk og ført til at det har tatt lang tid å sette meg inn i dem.

Det var ikke før jeg begynte å virkelig hate mange av konseptene i C# at jeg begynte å lete etter alternativer.
Ting jeg ikke liker er 
Null hater jeg. Det vet nesten alle.
Exceptions,
Setters,
for og while
if og else er jeg heller ikke noen stor fan av.

Nå er det sikkert noen som spør seg om jeg egentlig liker å programmere i det hele tatt.
Mye av det jeg hater med programmering ser ikke ut til å eksistere i den funksjonelle verden. 
Jeg vil derfor argumentere for at funksjonell koding gjør programvaren mer forutsigbar og lettere å forstå.
Desverre, så er det foreløpig ikke realistisk å kreve at prosjektet skal utvikles i noe annet enn C#.
Heldigvis, så har Mads Torgersen begynt å implementer noen funksjonelle konsepter i C#, men vi er ikke helt der enda.
Linq
Pattern matching
Records
Tuples

Jeg vil i dette foredraget vise dere hvordan vi kan løse oppgaven funksjonelt til tross for kravet om å
progge i C#

#Bilde Purity etc.

#Bilde 2 - What is a funcion

I mattematikken, så er funksjon en mapping mellom to set. Domenet og codomenet. 

#Core Techniques
##Option
I funksjonell programmering bruker man ikke null.
Man bruker Option isteden. 
Kodesnutt s.76



# Partial Application
Eksempel:
Når en funksjon trenger konfigurasjoner som er tilgjengelige ved oppstart og som ikke endrer seg. 


## Om applikasjonen
Vil i utgangspunktet si at teamet som lagde dette apiet har gjort en god jobb.
De har allerede valgt å separere basert på foretningsprosesser istedenfor
lagvis med, en mappe for dtoer og en mappe for domeneobjekter osv.
Om endepunktet mottar noe uforutset, så returnerer vi BadRequest
og om noe feiler, så returnerer vi InternalServerError og logger detaljene.
Så ting tyder på at de er opptatt av sikkerhet her. 





































