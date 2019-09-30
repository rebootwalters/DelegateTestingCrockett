using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTesting
{

    delegate void mydelegate();
    delegate void myotherdelegate(int count);
    public delegate void stillanother(int a, int b);
    public class hello
    {
        public void sayhello()
        {
            Console.WriteLine("Hello there");
        }
        public void screamhello(int i)
        {
            Console.WriteLine($"HELLO {i} times");
        }
    }

    class goodbye
    {
        public string Name;
        public void saygoodbye()
        {
            Console.WriteLine($"Goodbye {Name}");
        }
        public void screamgoodbye(int count)
        {
            Console.WriteLine($"GOODBYE {Name} {count} times");
        }
    }

    class ouch
    {
        public string perp;
        public string victim;

        public mydelegate phase1;
        public stillanother phase2;
        public event stillanother phase3;
        public event mydelegate phase4;

        public void sayouch()
        {
            Console.WriteLine($"{perp} Looks At {victim}");
        }
        public void screamouch(int count)
        {
            // phase1  Prior to any looping
            if (phase1 != null) phase1();

            for(int i = 0; i<= count; i++)
            {
                // phase2   Inside the loop BEFORE body
                if (phase2 != null) phase2(i, count);
                Console.WriteLine($"{perp} Looks at {victim} time {i} of {count} times");
                // phase3   Inside the loop AFTER body
                if (phase3 != null) phase3(i, count);
                
            }
            // phase4  AFTER all Looping
            if (phase4 != null) phase4();
        }
    }
    class Program
    {
        static void program_phase1()
        {
            Console.WriteLine("I am in Program.Phase1");
        }
        static void program_phase2(int first, int second)
        {
            Console.WriteLine($"I am in Program.Phase2:{first} and {second}");
        }
        static void Main(string[] args)
        {
            
         
            ouch o;

            o = new ouch();
            o.perp = "Daniel";
            o.victim = "Lydia";
            o.phase1 += new mydelegate(program_phase1);
            o.phase2 += new stillanother(program_phase2);
            o.phase3 += O_phase3;
            o.phase4 += O_phase4;

            Console.WriteLine("Starting:Inside Program.Main***********");

            Console.WriteLine("Calling:Inside Program.Main************");

            o.screamouch(5);

            Console.WriteLine("Returned:Back Inside  Program.Main************");

            Console.WriteLine("Exiting:  Inside Program.Main****************");

        }

        private static void O_phase4()
        {
            Console.WriteLine("PHASE4");
        }

        private static void O_phase3(int a, int b)
        {
            Console.WriteLine($"PHASE3: {a}, {b}");
        }
    }
}
