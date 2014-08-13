using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{

    /// <summary>
    /// Lambda expressions 
    /// Lambda functions were introduced in C# 3.0. 
    /// You can think of a lambda expression as a compact method to create an anonymous method.
    ///
    /// When working with lambdas, you will also need to know about the Func<..> and Action types.
    /// These generic types were added to have some predefined delegate types in the .NET Framework. 
    /// You use Action when you have a delegate that doesn’t return a value and Func when you do want to return a value.
    /// Both can take up to 16 type arguments in the .NET Framework 4.0. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> addFunc = (x, y) => x + y;
            Console.WriteLine(addFunc(2, 3));

            // The lambda is of the type Func<int, int, int> 
            // which means that it takes two integer arguments and returns an int as result. 
            // The strange => notation can be read as “becomes” or “for which.” 
            // The addFunc type can be read as “x, y become x + y”.

            // Expression trees
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                    Expression.Constant("Hello ")
                    ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("World!")
                    )
            );

            Expression.Lambda<Action>(blockExpr).Compile()();

            // The expression is first constructed with a call to Console.Write and Console.WriteLine. 
            // After construction, the expression is compiled to an Action (because it doesn’t return anything) and executed.

            Console.ReadLine();
        }
    }
}
