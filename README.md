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
Caset vi skal jobbe med er et tradisjonelt crud api. Apiet er utviklet med en typisk lagvis arkitektur der
databaseoperasjonene er i repository laget og endepuntkene er definert i controller laget.
I Controlleren ser vi at vi bare har to endepunkter, Read og Create, så Update og Delete mangler.
Read metoden tar imot en userid som blir sent til UserRepository. Vi kunne ha brukt en int som id her,
men vi har valgt å bruke et Value Object som imput parameter. Er det noen var dere som syns dette er ugreit?
Ikke? Good!

Om vi tar en titt videre i Read metoden til repository.
Så har vi en connection string som vi henter med dependency injection. Den har en
Connect metode som tar inn en spørring. Vi ser SQL spørringeng lengre opp, og vi
bruker id som parameter. Så bruker vi constructoren til domeneobjektet for å lage en
instans. Til slutt her så returnerer vi SingleOrDefault. Det vil si at
* Om det eksisterer EN bruker med denne id-en, så returnerer vi den
* Om det eksisterer FLERE brukere med denne id-en, så kaster vi ekseption
* Om dei ikke eksisterer noen brukere med denne IDen, så returnerer vi null

Tilbake i controlleren, så ser vi at vi returnerer NotFound om user er null og Ok om den ikke er null.

Den neste operasjonen er Create. Her tar vi i mot en DTO eller domeneobjekt eller hva enn du vil kalle det som 
representerer en bruker. Jeg har ikke tatt meg bryderiet med å skille domeneobjekt fra dto, det er ikke
alltid jeg ser poenget med å gjøre det. User klassen er en record med to properties.
Name og Role. Det dere pleier å bli krenket av er at jeg putter Value Objects i dtoen min. 
Jeg hører mange si at man skal holde seg til c# datatyper i dtoer og konvertere det til
domeneobjekt ved mottak. Så jeg lurer på, er det mange her inne som syns at jeg ikke skal
bruke Value Objects i DTOer? Rekk opp handa!
Ser at det er noen her. Kan jeg få en grunn til at du mener det?
Den som pleier å bli mest krenket her er jo Stenland, men han holder foredraget sitt i nabo rommet akkurat nå.
Så det ser ikke ut til at jeg trenger å forsvare avgjørelsene mine her. Det er bra.

Videre sender vi User til userRepository, hvor vi har en ganske enkel operasjon for å lagre objektet.
Det samme objektet som vi mottok i contolleren blir lagret. ID feltet blir bestemt av databasen.
I controlleren så returnerer Created.

Vil i utgangspunktet si at teamet som lagde dette apiet har gjort en god jobb.
Om en exception blir kastet, så returnerer vi 500 feil uten feilmeldinga,
fordi at å eksponere seg selv for omverdenen på den måten er vulgært.
Også har bruken av value objects og valget om å ha dem i dtoen sørget for at 
valideringen er på plass uten at vi trenger å tenke på det.

Det vi nå skal se på er hvordan applikasjonen vil se ut om vi introduseser noen 
funksjonelle konsepter. Først ut er null/feil håndteringa.

## Steg 1 Core Functions
I funksjonell programmering bruker man ikke null eller ekseptions.
Det er gode grunner til det. Blandt annet motarbeider det oss
når vi ønkser å væare konsekvente. Ta en titt på denne kodesnutten.
Hva blir skevet til konsollen? Noen her som tør å prøve seg?

Ser ikke mange som rekker opp handa her. Ikke mange som har ballene til å
fortelle oss hva som blir skrevet til konsollen. Men poenget mitt er at 
slikt burde ikke kreve baller.

Fasit: NameValueCollection returnerer null når den ikke inneholder verdien.
Dictionary kaster KeyNotFoundException.

I funksjonell programmering så bruker man Option isteden. Option
er en beholder som pakker inn en verdi, eller som ikke inneholder noen verdi.
Se på det som en liste med plass til kun en verdi.

Jeg pratet om Option tidligere i år på Opkoko 23.1 i Berlin. Da foreslo jeg en ganske enkel implementasjon
Med et interface og to implementasjoner, en for Some og en for None. None hadde 
også et felt som beskrev hva som gikk galt. Det var ikke feil, dette er bare konsepter, man står fritt til å bruke dem som man vil.
Denne gangen vil jeg bruke biblioteket som er skrevet av forfatteren. Den er litt mer
kompleks.

TODO: Ta akkurat de bitene vi blir å bruke.

DO: Endre repository til å returnere Option

Som nevnt tidligere så er jeg ikke spesielt fan av if-else. I funksjonell programmering,
så bruker man pattern matching for slikt. Desverre så lar ikke pattern-matching
oss skille mellom hva vi skal gjøre om lista er tom elle ikke. Så det vi 
istedenfor har, er funksjonen Match. Den fungerer på alle former for 
samlinger og tar inn en funksjon som eksekveres om lista er tom,
og en som eksekveres om lista inneholder noe. 
Otherwise parameteren bruker to parametere. Det er første
element i lista og resten av lista, men den discarder vi bare.

Do: Match i repository

La oss se på Controlleren nå.
Når vi bruker en funksjon som returnerer en Option, så ønsker vi å
ta hensyn til begge utfallene. Altså, vil vi ta hensyn til både tilfellet
der Some returneres og tilfellet der None returneres.
Nå som pattern matching er en greie i C# så da lar det seg jo enkelt løse slikt?

Dette vil desverre ikke kompilere. For at den skal kompilere må vi gjøre slikt.
Men dette ser jo veldig stygt ut. Så hva gjør vi isteden?

Husk at Option er en collection med plass til en verdi. Match funksjonen
vil altså fungere her også.

Do: Match i controller

Vi er ikke helt ferdig med write. Vi har et tredje utfall som kan komme
fra dette kallet, menlig at noe går galt og en ekseption
blir kastet.
Som poengtert tidligere, gjør exceptions koden vår uforutsigbar.
Vi burde istedenfor ha denne situasjonen representert i returverdien
vår. Så hva med å bruke option for det og? Hva om vi først
representerer en verdi som er None om noe gikk galt, og en Some av Option om det ikke
gikk galt. Og så kan den igjen være None om vi ikke fant verdien og en Some av bruker hvis 
vi har verdien.

Det er på en måte det vi skal gjøre, men for å få det litt lettere har vi en 
spesialversjon av option som heter Exceptional. Exceptional kan være Success eller Exception.
Så får det være opp til oss hva vi gjør om den er exception.

Do: Exceptional i repository
Exceptional har en implicit constructor som bruker Exception, derfor trenger vi bare å returenre 
Exception.
Do: Match i controller

Da kan vi si oss ferdig med Read. Vi skal nå jobbe litt med Create

I repository, så ser vi at Create er en void, den gir oss altså
ikke noen retur verdi.
Men mange av teknikkene vi bruker i funksjonell programmering
krever en retur verdi.
For eksempel så ønsker vi her å returnere exception slik som i metoden ovenfor.
Men vi kan ikke det. Exeptional<void> er jo ikke en greie.

I funksjonelle språk så returnerer vi en tom tuple i slike tilfeller,
Også kalt Unit. Desverre så støtter ikke c# (), så vi må bruke System.ValueTuple.
Jeg har lagt ved et using statement som sier at Unit er Tuple

TODO: Kan fylle på med mer stoff om unit her om tiden tillater s. 70

Do: Legg til Unit i repository
Do: Legg til Exceptional i repository
Do: Match i controller

## Steg 2 - Partial Application
Det neste trikset jeg skal vise dere, er partial application.
Akkurat nå så har vi en repository klasse som integrerer mot databasen vår. Når applikasjonen
starter, så vet repository hvilket SQL spørring som vil bli brukt for denne operasjonen.
Og den vet om connection string. Den vet ikke hva Id parameteren kommer til å være.

Om vi ønsker å gjøre dette til en funksjonell applikasjon, så må vi klare å lage en funksjon som
vet de samme tingene ved oppstart. Så derfor vil jeg endre Read til å returnere en funksjon isteden.
Vi vil atså lage en funksjon som blir kallet ved oppstart med de parameterne vi vet på det tidspunktet.
Funksjonen som den returnerer vil bli kallet mens applikasjonen kjører. 

Do: Read blir statisk og returenrer en funskjon.
Do: Det samme skjer med Create.
Do: Flytt til Controller, slett repository

Føltes ikke det godt da. Vi har fjernet repository laget. Det er sikkert noen av dere som nå lurer på om det egentlig er behov for
controlleren. Jeg har i så fall gledelige nyheter til dere. Vi trenger den så  absolutt ikke.

Do: Flytt til Program, slett Controller.

Note. Bruker .NET 7. Minimal-api støtter ikke egendefinert model-binding. Har derimot hørt rykter om at det skal finnes en løsning for det i
.NET 8, men jeg har ikke rukket å teste det ut enda.

## Konklusjon
I apiet vi endte opp med så var det ingen klasser lengre.
Men, den er fortsatt like avkoblet som den var tidligere.
Read og Create endepunktene vet fortsatt like lite om database implementasjonen. 
Den er også testbar, men nå som vi ikke bruker interfacer lengre, så trenger vi ikke 
å sette opp Fakes.

En annen ting er at interface segregation prinsippet ble brutt i den tidligere versjonen.
Det forteller oss at klienter ikke burde avhenge av metoder de ikke bruker.
IRepository interfacet hadde en metode for Read og en for Create. Om vi ikke skulle 
brutt med det prinsippet, så måtte vi ha delt det i to.

Det var det jeg hadde for dere. Håper det var underholdende.
































