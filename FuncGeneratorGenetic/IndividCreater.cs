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

using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace FuncGeneratorGenetic
{
    // Fabric to create compilable individuals 
    static class IndividCreater
    {
        // Program code text
        static string sProgramCodeFinal;

        // Needs for calling compiler
        static CSharpCodeProvider provider = new CSharpCodeProvider();
        static CompilerParameters parameters = new CompilerParameters();

        // Parameters of the function
        static object[] InvokeParams = new object[2];

        static Random rnd = new Random();

        // Constructor
        static IndividCreater()
        {
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
        }

        // Creates individual with random gene, that is compiled successfully
        public static Individ CreateIndivid()
        {
            Individ ind = new Individ();

            CompilerResults results = null;

            // Loop until compiled
            while (true)
            {
                // Get code sample with randomly built function
                sProgramCodeFinal = ProgramText.GetProgramCode(ind.Gene);
				Console.WriteLine("trying with this function: \n" + sProgramCodeFinal);
				Console.WriteLine("// by using a gene length of: " + ind.Gene.Length);

                // Try to compile
                results = provider.CompileAssemblyFromSource(parameters, sProgramCodeFinal);
                if (results.Errors.HasErrors)
                {
                    ind = new Individ();
                    continue;
                }

                break;
            }

            // Get access to the compiled function
            Assembly assembly = results.CompiledAssembly;
            Type program = assembly.GetType("Program.WorkingClass");
            MethodInfo main = program.GetMethod("F");

            int[] f_results = new int[TrainingData.a_array.Length];

            // Calculate function values with training data
            for (int itry = 0; itry < TrainingData.a_array.Length; itry++)
            {
                InvokeParams[0] = TrainingData.a_array[itry];
                InvokeParams[1] = TrainingData.b_array[itry];
                f_results[itry] = Convert.ToInt32(main.Invoke(null, InvokeParams));

				//Console.WriteLine("result should be: " + TrainingData.f_array[itry]
				//                + " instead it values: " + f_results[itry]);
            }

            // Calculate deviation with the training data at the place
            ind.CalculateDeviation(f_results);

            return ind;
        }

        // Creates individual with two parent's genes and possible mutation
        public static Individ CreateIndivid(Individ i1, Individ i2, bool mutate)
        {
            Individ ind = new Individ(i1, i2, mutate);

            CompilerResults results = null;

            // Loop until compiled
            while (true)
            {
                // Get code sample with randomly built function
                sProgramCodeFinal = ProgramText.GetProgramCode(ind.Gene);
				Console.WriteLine("trying with this function: \n" + sProgramCodeFinal);
				Console.WriteLine("// by using a gene length of: " + ind.Gene.Length);

                // Try to compile
                results = provider.CompileAssemblyFromSource(parameters, sProgramCodeFinal);
                if (results.Errors.HasErrors)
                {
                    ind = new Individ(i1, i2, true);
                    continue;
                }

                break;
            }

            // Get access to the compiled function
            Assembly assembly = results.CompiledAssembly;
            Type program = assembly.GetType("Program.WorkingClass");
            MethodInfo main = program.GetMethod("F");

            int[] f_results = new int[TrainingData.a_array.Length];

            // Calculate function values with training data
            for (int itry = 0; itry < TrainingData.a_array.Length; itry++)
            {
                InvokeParams[0] = TrainingData.a_array[itry];
                InvokeParams[1] = TrainingData.b_array[itry];
                f_results[itry] = Convert.ToInt32(main.Invoke(null, InvokeParams));

				//Console.WriteLine("result should be: " + TrainingData.f_array[itry]
				//				+ " instead it values: " + f_results[itry]);
            }

            ind.CalculateDeviation(f_results);

            return ind;
        }
    }
}
