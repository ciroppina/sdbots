/**********************************************************************************
Function Generator Genetic (Bot 2)
http://www.codeproject.com/Articles/1156694/A-Look-into-the-Future-Source-Code-Generation-by-t
-----------------------
The MIT License (MIT)
Copyright (c) 2016 Dmitriy Gakh ( dmgakh@gmail.com ).
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
**********************************************************************************/

using System;
using System.Diagnostics;

namespace FuncGeneratorGenetic
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Population p = new Population();
            int g = 1;

            while(true)
            {
                Console.WriteLine("Generation: {0}  Distance: {1}", g, p.BestIndivid.Deviation);

                p.LiveCycle();
                g++;

                // Check if the solution is found
                if (p.BestIndivid.Deviation == 0)
                    break;
            }

            watch.Stop();

            Console.WriteLine("Generation: {0}  Distance: {1}", g, p.BestIndivid.Deviation);
            Console.WriteLine("Elapsed time {0} seconds", watch.ElapsedMilliseconds / 1000);
            Console.WriteLine("The following code was built:");
            Console.WriteLine(ProgramText.GetProgramCode(p.BestIndivid.Gene));
			Console.WriteLine("// by using a gene length of: " + p.BestIndivid.Gene.Length);
            Console.ReadLine();
        }
    }
}
