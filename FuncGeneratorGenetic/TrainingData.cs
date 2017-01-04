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

namespace FuncGeneratorGenetic
{
    // Training Data
    static class TrainingData
    {
        // Test contains set of training data
        // 9 values of input values a and b, and 
        // 9 output values
        // The data are equal to function f = a*a + 5*b + 9;

        public static int[] a_array = { 38, 4, 51, 12, 6, 20, 25, 3, 40 };
        public static int[] b_array = { 2, 11, 7, 32, 21, 38, 43, 19, 34 };
        public static int[] f_array = { 1463, 80, 2645, 313, 150, 599, 849, 113, 1779 };

        public static int DataSize = 9;
    }
}
