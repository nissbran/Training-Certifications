using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    /// <summary>
    /// Liskov substitution principle 
    /// 
    /// Inheritance is a powerful technique, but it should be used with caution. 
    /// As already mentioned, inheritance should be used only when you are dealing with a “is-a-kind-of” relationship.
    /// The Liskov substitution principle states that a subclass should be usable in each place you can use one of the base classes. 
    /// They shouldn’t suddenly change behavior that users would depend on.
    /// 
    /// It’s easy to violate this principle.
    /// </summary>
    class Program
    {
        static void Main(string[] args) {

            // Because you know that you are dealing with a square, 
            // you help the user of the class by modifying both the Width and Height properties together.
            // This way, the rectangle will always be a square. 

            Rectangle rectangle = new Square();
            rectangle.Width = 10;
            rectangle.Height = 5;

            Console.WriteLine(rectangle.Area);

            // This code will output 25. The user thinks he’s dealing with a Rectangle with a calculated Area,
            // but because the Rectangle is pointing to a Square, only the latest value of Height is stored.
            // This is a typical example of violating the Liskov substitution principle. 
            // The Square class cannot be used in all places where you would normally use a Rectangle. 
            Console.ReadLine();
        }
    }

    class Rectangle
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Height { get; set; }
        public int Width { get; set; }

        public int Area
        {
            get { return Height * Width; }
        }
    }

    /// <summary>
    /// When looking at this Rectangle class, would you say that a Square is a kind of Rectangle?
    /// In mathematics, this would be true. We know that a square is a special type of rectangle.
    /// You can model this using an inheritance relation
    /// </summary>
    class Square : Rectangle
    {
        public override int Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
        public override int Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}
