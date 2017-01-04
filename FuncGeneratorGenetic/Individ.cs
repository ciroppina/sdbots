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
    // The population individual for genetic algorithm
    class Individ
    {
        // Gene for building the formula
        public byte[] Gene;

        // Deviation from testing results
        public int Deviation;

        // Random number generator
        static Random rnd = new Random();

        // Creates Individ with random gene
        public Individ()
        {
			int howManyGenes = (ProgramText.VAlphabet.Length > TrainingData.DataSize) 
				? ProgramText.VAlphabet.Length : TrainingData.DataSize;

            Gene = new byte[howManyGenes]; //former: TrainingData.DataSize

			for (int i = 0; i < howManyGenes; i++)
			{
				try
				{
					Gene[i++] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);
					Gene[i] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);
				}
				catch (IndexOutOfRangeException){}
			}

            Deviation = int.MaxValue;
        }

        // Creates Individ with random gene
        public Individ(Individ i1, Individ i2, bool mutate)
        {
            int howManyGenes = (ProgramText.VAlphabet.Length > TrainingData.DataSize)
				? ProgramText.VAlphabet.Length : TrainingData.DataSize;

			Gene = new byte[howManyGenes]; //former: TrainingData.DataSize

            // Randomly use gene from one of the parent 
            for(int i = 0; i < Gene.Length; i++)
                Gene[i] = (rnd.Next(0, 2) == 0 ? i1.Gene[i] : i2.Gene[i]);

            if(mutate)
            {
                // value should be between 0 and 10
                int variability = 2;

				for (int i = 0; i < howManyGenes; i++)
				{
					try
					{
						if (rnd.Next(0, 12 - variability) == 0)
							Gene[i++] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);

						if (rnd.Next(0, 12 - variability) == 0)
							Gene[i] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);
					}
					catch (IndexOutOfRangeException) { }
				}
			}

            Deviation = int.MaxValue;
        }

        // Calculate Deviation as a maximal distance between
        // training and actual results
        public void CalculateDeviation(int[] results)
        {
            int d = 0;

            for (int i = 0; i < TrainingData.DataSize; i++)
            {
                int d2 = Math.Abs(TrainingData.f_array[i] - results[i]);
                if (d < d2)
                    d = d2;
            }

            Deviation = d;
			Console.WriteLine("---average Deviation is: " + d);
        }

    }
}
