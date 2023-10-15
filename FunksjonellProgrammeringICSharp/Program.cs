// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
//
// app.MapGet("/", () => "Hello World!");
//
// app.Run();

using LaYumba.Functional;
using Name = System.String;
using Greeting = System.String;
using PersonalizedGreeting = System.String;
using static LaYumba.Functional.F;
using static System.Console;

var greet = (Greeting gr, Name name) => $"{gr}, {name}";

var greetWith = (Greeting gr) => (Name name) => $"{gr}, {name}";

var names = new Name[] {"Tristan", "Ivan"};

WriteLine("Greet - with 'normal', multi-argument application");
names.Map(g => greet("Hello", g)).ForEach(WriteLine);
// prints: Hello, Tristan
//         Hello, Ivan

WriteLine("Greet formally - with partial application, manual");
var greetFormally = greetWith("Good evening");
names.Map(greetFormally).ForEach(WriteLine);
// prints: Good evening, Tristan
//         Good evening, Ivan

WriteLine("Greet informally - with partial application, general");
var greetInformally = greet.Apply("Hey");
names.Map(greetInformally).ForEach(WriteLine);
// prints: Hey, Tristan
//         Hey, Ivan

WriteLine("Greet nostalgically - with partial application, currying");
var greetNostalgically = greet.Curry()("Arrivederci");
names.Map(greetNostalgically).ForEach(WriteLine);
// prints: Arrivederci, Tristan
//         Arrivederci, Ivan

// mest generelle foran
// mest spesifikke bakerst
var hils = (string h, string n, int m) => Some($"{h} {n} det er {m} min å vente");
var d = hils
   .Apply("God aften")
   .SwapArgs()
   .Apply(5);

var gr = Some("Kim")
   .Bind(d)
   .Match(
      None: () => "I did not get a name",
      Some: name => $"{name}"
   );
WriteLine(gr);

new string[] {"Kim", "Troy"}
// Some("Kim")
   .Bind(d)
   .WriteSome();

var medCurryForm = hils.Curry()("hei")("Kim Karry")(2);

static class ExtensionMethods
{
   public static Func<T2, T1, R> SwapArgs<T1, T2, R>(this Func<T1, T2, R> func)
      => (t2, t1) => func(t1, t2);
   
   public static void WriteSome(this Option<string> os)
      => os.Match(() => { }, WriteLine);
   
   public static void WriteSome(this IEnumerable<string> os)
      => os.ForEach(WriteLine);
}
