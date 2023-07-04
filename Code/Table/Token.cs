namespace Nail.Code.Table
{
    public enum Token
    {
        None, // Parent Node

        // lang items
        Id,         // var, use, etc...
        Op,         // + - = ; : , .
        Bracket,    // () {} []

        // user-defined
        Variable,   // number, string...
        Type,       // String, Float, Int, MyClass...

        // values
        Int,        // 10
        Float,      // 10.0
        String,     // "Hello!"
    }
}

// Example:
// None
// {
//  var  number  =  10  +   15.5  ;
//  Id  Variable Op Int Op Float Op

//  float  number  =  10  +   15.5  ;
//  Type  Variable Op Int Op Float Op

//  class MyClass {       }
//  Id    Type    Bracket Bracket
// }