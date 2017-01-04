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
using System.Text;

namespace FuncGeneratorGenetic
{
    // Class composing code of the program
    static class ProgramText
    {
        // First part of program code
        static string ProgramCodeHeader =
                        //"using System;\n" +
                        //"\n" +
                        "namespace Program\n" +
                        "{\n" +
                        "    public class WorkingClass\n" +
                        "    {\n" +
                        "        public static int F(int a, int b)\n" +
                        "        {\n" +
                        "            ";

        // Last part of program code
        static string ProgramCodeFooter =
                        "\n" +
                        "        }\n" +
                        "    }\n" +
                        "}";

        // Alphabet of operations
        public static char[] OAlphabet = { '-', '+', '*', '/', '-', '+', '*', '/' };
		//former: '-', '+', '*', '/'

        // Alphabet of values / variables
        public static char[] VAlphabet = { 'a', 'b', '1', '2', '3', '5', '7', '5', '3', '2', '1'}; 
		//other possible arrays:
		//'a','b','1','2','3','4','5','6','7','8','9' 
		//'a','b','5','9'
		//'a','b','1','2','3','5','7','5','3','2','1' 
		//'a','b','1','2','3','5','7','7','3','2','1' 

        // Random number generator
        static Random rnd = new Random();

        // Get code for program with random code of function
        public static string GetProgramCode(byte[] gene)
        {
            StringBuilder sb = new StringBuilder(16);

            sb.Append(ProgramCodeHeader);
            sb.Append(@"return ");
            GetFunctionCode(sb, gene);
            sb.Append(';');
            sb.Append(ProgramCodeFooter);

            return sb.ToString();
        }

        // Get code for function according to the gene
        public static void GetFunctionCode(StringBuilder sb, byte[] gene)
        {
			for (int i = 0; i < gene.Length; i++)
			{
				try
				{
					sb.Append(' ');
					sb.Append(VAlphabet[gene[i++]]);
					sb.Append(' ');
					sb.Append(OAlphabet[gene[i]]);
				}
				catch (IndexOutOfRangeException) { }
			}
        }
    }
}
