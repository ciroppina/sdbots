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

namespace FuncGeneratorGenetic
{
    // Create population of compiled individuals
    class Population
    {
        Individ[] Individuals;

        // Number of individuals who will create new population (parents)
        public const int size_main = 10;

        // Number of individuals created from parents
        public const int size_other = size_main * size_main;

        public Population()
        {
            // Create array for entire population
            Individuals = new Individ[size_main + size_other];

            // Create compileable individuals
            for(int i = 0; i < Individuals.Length; i++)
            {
                Individuals[i] = IndividCreater.CreateIndivid();
            }

            // Sortinf individuals for further selection top as parents
            // and rest to delete and replace by new generation
            Array.Sort<Individ>(Individuals, IndividComparizon);
        }

        // Create new generation
        public void LiveCycle()
        {           
            Repopulate();
            Array.Sort<Individ>(Individuals, IndividComparizon);
        }

        // Create new generation from the parents
        void Repopulate()
        {
            int pos = size_main;

            for (int i1 = 0; i1 < size_main; i1++)
                for (int i2 = 0; i2 < size_main; i2++)
                {
                    Individuals[pos] = IndividCreater.CreateIndivid(Individuals[i1], Individuals[i2], i1 == i2);
                    pos++;
                }
        }

        // Individ who is the most close to the solution 
        public Individ BestIndivid
        {
            get
            {
                return Individuals[0];
            }
        }

        // For sorting by deviation from training results
        static int IndividComparizon(Individ i1, Individ i2)
        {
            if (i1.Deviation < i2.Deviation)
                return -1;
            else
            if (i1.Deviation > i2.Deviation)
                return 1;
            else
                return 0;
        }
    }
}
