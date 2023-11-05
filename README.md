# funksjonell-programmering-i-csharp
A presentation that I will do at OPKOKO 23.2 Tyrifjord og P2P OPK1D Katrineholm


# Cloning the repo
Repo has a submodule either use the `--recurse-submodules` flag

```shell
git clone --recurse-submodules git@github.com:kimrs/functional-programming-in-csharp.git
```

Or, if you forgot to use the flag

```shell
git submodule init
git submodule update
```

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
I C#, så er det implementasjonsdetaljer som bestemmer hvorvidt null returneres eller en exception kastes.
Dette har gjort bibliotekene våre inkonsekvente.

```csharp
using System.Collections.Specialized;
using static System.Console;

try
{
    _ = new NameValueCollection()["green"];
    WriteLine("green!");

    _ = new Dictionary<string, string>()["blue"];
    WriteLine("blue!");
}
catch (Exception ex)
{
    WriteLine(ex.GetType().Name);
}
/*
    green!
    KeyNotFoundException
*/
```
I funksjonell programmering bruker man ikke null. Man kaster heller ikke ekseption.
Mangelen på null og exception tvinger oss til å være mer konsekvente i måten vi 
tilfeller der ugyldige argumenter
Så hva bruker vi isteden?
Option<T>
Option er en wrapper som kan være None | Some(T). I C# kan vi enkelt håndtere None og Some
caset med en switch expression

```csharp
string Greet(Option<string> greetee)
    => greetee switch
    {
        None => "Sorry, who?",
        Some(name) => $"Hello, {name}"
    };
```

Desverre så lurte jeg dere. Dette vil ikke kompilere, vi må skrive det på en langt styggere måte

```csharp
string Greet(Option<string> greetee)
    => greetee switch
    {
        None<string> => "Sorry, who?",
        Some<string>(var name) => $"Hello, {name}"
        _ => throw new ArgumentException("Option must be None or Some")
    };
```

Så istedenfor så kan vi skjule det stygge i en Match funksjon

```csharp
static R Match<T, R> (this Option<T> opt, Func<R> None, Func<T, R> Some)
    => opt switch
    {
        None<T> => None(),
        Some<T>(var t) => Some(t),
        _ => throw new ArgumentException("Option must be None or Some")
    };
```

Greet funksjonen vår ser da slik ut. Strengt talt så er det ikke nødvendig å skrive None eller Some
Det er ryddig i denne presentasjonen

```csharp
string Greet(Option<string> greetee)
    => greetee.Match
    (
        None: () => "Sorry, who?",
        Some: (name) => $"Hello, {name}"
    );
```

TODO: Smart constructor pattern med Domain Primitives
TODO: Everything is a stream. Se på IOption som en spesiell type
liste som enten kan ha en verdi eller ingen. Da vil 

# Map
Map i funksjonell programmering er det samme som Select.
```csharp
public static IEnumerable<R> Map<T, R>(
  this IEnumerable<T> ts, Func<T, R> f
) => ts.Select(f);
```
Den brukes til å kalle en funksjon på den indre verdien i en datastruktur som for eksempel IEnumerable.
Som jeg nevnte, så kan vi se på en Option som ei liste. Det betyr at `Map` også fungerer på
Option. I det tilfellet vil 'f' kalles på ts kun hvis option er en Some.
Dette er likt det som skjer hvis ts er en tom liste. Select vil i det tilfellet returnere en tom liste

## Functor
Det vi kaller typer som har en Map funksjon definert for seg

# Bind
Gjør det samme som map, men fungerer på funksjoner som returnerer Option.
## Unngå stacking
## Monad 
Typer som har en Bind funksjon definert for seg

## Regular vs elevated? s.111

# Either

# Eksempel
Mulig jeg bruker eksempelet gradvis.








# Partial Application
Eksempel:
Når en funksjon trenger konfigurasjoner som er tilgjengelige ved oppstart og som ikke endrer seg. 

# Modularisering
s. 181
I objektorientert kode, så modulariserer vi applikasjonen vår med å fordele ansvar til forskjellige
klasser. De ulike ansvarene vi har delegert fanger vi opp med interfaces. 
Dette er bra fordi det decoupler koden vår slik at vi kan endre et kall fra
å legge en melding på en kø istedenfor å skrive til databasen uten å 
for eksempel endre foretningslogikken vår. Det gjør også koden vår
testbar. Dette følger et mønster vi kaller dependency inversion,
altså, at høy-nivå komponent ikke konsumerer komponenter fra
et lavere nivå direkte, men heller gjennom abstraksjoner, aka interfaces.
Ulempen er at vi ender opp med et stort antall interfacer som øker kompleksiteten
i koden. For å håndtere denne kompleksiteten, bruker vi IoC containere og mocke rammeverk.
### Vis eksempel der vi har gjort koden funksjonell men fortsatt bruker dependency injection

Om vi tenker at de fundamentale enhetene i oop er objekter, så er de funksjoner i FP
Så måten vi modulariserer koden i FP, er å delegere ansvar til metoder, ikke objekter.
I FP, så definerer vi ikke interfacer, fordi funksjon signaturen gir oss all interface vi trenger.

Så om du skriver kode som må vite hva klokka er, så tar du inn en funksjon som gir deg klokkeslettet
istedenfor et interface. ### eksempel


Etter å ha gjort alt dette, så er det på tide å spørre seg selv, hvorfor trenger vi en kontroller 
i det hele tatt?


## Om applikasjonen
Vil i utgangspunktet si at teamet som lagde dette apiet har gjort en god jobb.
De har allerede valgt å separere basert på foretningsprosesser istedenfor
lagvis med, en mappe for dtoer og en mappe for domeneobjekter osv.
Om endepunktet mottar noe uforutset, så returnerer vi BadRequest
og om noe feiler, så returnerer vi InternalServerError og logger detaljene.
Så ting tyder på at de er opptatt av sikkerhet her. 





































