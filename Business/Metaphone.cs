// --------------------------------------------------------------------
// Project : SPAIN
// Dec 2016
// Códigos postales, Provincias, Localidades, Comunidades autónomas, Indexación sonora por METAPHONE
// Class      : MetaphoneES                 (indexación por fonemas en castellano)
// Class Name : [Business.MetaphoneES]
// Author : Juan Carlos Ruiz López, juancarlosruizlopez@hotmail.com
// --------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MetaphoneES    // PhoneticAlgorithmsES():
    {
        // Based on 
        // The Spanish Metaphone Algorithm(Algoritmo del Metáfono para el Español)
        // (C) 1990 by Lawrence Philips. English double metaphone algorithm implementation by
        // Andrew Collins - January 12, 2007 who claims no rights to this work
        // (http://www.atomodo.com/code/double-metaphone)
        // The metaphone port adapted to the Spanish Language is authored by Alejandro Mosquera <amosquera @dlsi.ua.es> November, 2011 
        // Port mucho más avanzado : JC, Dec 2016
        

        /*
           @staticmethod
           def string_at(string, start, string_length, lista):

               if ((start<0) or (start >= len(string))):
                       return 0
               for expr in lista:
                       if string.find(expr, start, start + string_length) != -1:
                           return 1
               return 0


           @staticmethod

           def substr(string, start, string_length):

                   v = string[start:start + string_length]
                   return v

           @staticmethod
       */

        internal static bool IsVowel(char letter)
        {
            // Improve with RegEx
            if (letter == 'a') return true;
            if (letter == 'á') return true;
            if (letter == 'e') return true;
            if (letter == 'i') return true;
            if (letter == 'o') return true;
            if (letter == 'u') return true;
            if (letter == 'A') return true;
            if (letter == 'E') return true;
            if (letter == 'I') return true;
            if (letter == 'O') return true;
            if (letter == 'U') return true;
            return false;

        }
        internal static bool IsConsonantGroup1(char letter)
        {
            // Improve with RegEx
            if (letter == 'D') return true;
            if (letter == 'F') return true;
            if (letter == 'J') return true;
            if (letter == 'K') return true;
            if (letter == 'M') return true;
            if (letter == 'N') return true;
            if (letter == 'P') return true;
            if (letter == 'T') return true;
            if (letter == 'B') return true;
            // if (letter == 'V') return true;
            if (letter == 'L') return true;
            if (letter == 'Y') return true;



            return false;

        }
        internal static string Normalize(string Texto)  // def strtr(st):
        {
            if (string.IsNullOrEmpty(Texto)) return Texto;

            Texto = Texto.Replace('á', 'A');
            Texto = Texto.Replace("ch", "X");
            Texto = Texto.Replace('ç', 'S');
            Texto = Texto.Replace('é', 'E');
            Texto = Texto.Replace('í', 'I');
            Texto = Texto.Replace('ó', 'O');
            Texto = Texto.Replace('ú', 'U');
            Texto = Texto.Replace("ñ", "NY");
            Texto = Texto.Replace("gü", "W");
            Texto = Texto.Replace('ü', 'U');
            // Texto = Texto.Replace('b', 'V');
            Texto = Texto.Replace('v', 'B');

            // #st=st.replace('z','S')

            Texto = Texto.Replace("ll", "Y");
            return Texto;
        }



        public static string Metaphone(string Texto)
        {
            if (string.IsNullOrEmpty(Texto)) return Texto;

            string ATraducir = Normalize(Texto.Trim().ToLower()).ToUpper();

            string Results = "";        // initialize results key string
            int key_length = 15;        // set maximum metaphone key size 


            int CurrentPos = 0;
            int LastPos = ATraducir.Length - 1;

            while (Results.Length < key_length)
            {
                if (CurrentPos > LastPos) break;

                char CurrentChar = ATraducir[CurrentPos];

                // if it is a vowel, and it is at the begining of the string, set it as part of the meta key        
                if (IsVowel(CurrentChar) && (CurrentPos == 0))
                {
                    Results += CurrentChar.ToString();
                    CurrentPos++;
                    continue;
                }

                // Vocal en medio de la palabra O AL FINAL se ignora
                if (IsVowel(CurrentChar)) { CurrentPos++; continue; }

                // Todos los signos de puntuación se ignoran
                if (char.IsPunctuation(CurrentChar)) { CurrentPos++; continue; } 


                //# Let's check for consonants  that have a single sound 
                //# or already have been replaced  because they share the same sound like 'B' for 'V' and 'S' for 'Z'

                if (IsConsonantGroup1(CurrentChar))
                {
                    Results += CurrentChar.ToString();
                    // # increment by two if a repeated letter is found

                    if (CurrentPos == LastPos) break;

                    // Skip 1 if not duplicate, 2 if duplicate
                    if (CurrentChar == ATraducir[CurrentPos + 1]) { CurrentPos += 2; } else { CurrentPos++; };
                    continue;
                }


                if (CurrentChar == 'C')
                {
                    if (CurrentPos != LastPos)
                    {
                        char SiguienteLetra = ATraducir[CurrentPos + 1];

                        // Hay otra detrás
                        // Decidir qué se hace si CH


                        // CC - 'acción', 'reacción',etc.
                        if (SiguienteLetra == 'C')
                        {
                            Results += "X" ;    // Era X o Z ?
                            CurrentPos += 2;
                            continue;
                        }

                        // CE,CI
                        if ((SiguienteLetra == 'E') || (SiguienteLetra == 'I'))
                        {
                            Results += "Z";
                            CurrentPos += 2;
                        }
                        else
                        {
                            Results += "K";
                            CurrentPos += 1;

                        }
                        continue;
                    }
                    else
                    {
                        // No puede acabar en C   SI QUE PUEDE, NOMBRES DE EMPRESAS
                        Results += "K";
                        CurrentPos++;
                        continue;
                    }


                }  // C


                if (CurrentChar == 'G')
                {
                    if (CurrentPos != LastPos)
                    {
                        char SiguienteLetra = ATraducir[CurrentPos + 1];

                        // GE,GI
                        if ((SiguienteLetra == 'E') || (SiguienteLetra == 'I'))
                        {
                            Results += "J";
                            CurrentPos += 2;
                        }
                        else
                        {
                            Results += "G";
                            CurrentPos += 1;

                        }
                        continue;
                    }
                    else
                    {
                        // No puede acabar en G   SI QUE PUEDE, NOMBRES DE EMPRESAS
                        Results += "J";
                        CurrentPos++;
                        continue;
                    }


                }  // G


                if (CurrentChar == 'H')
                {
                    if (CurrentPos != LastPos)
                    {
                        char SiguienteLetra = ATraducir[CurrentPos + 1];

                        if (IsVowel(SiguienteLetra))
                        {
                            // Saltando H muda
                            Results += SiguienteLetra.ToString();
                            CurrentPos += 2;
                        }
                        else
                        {
                            Results += "H";
                            CurrentPos += 1;
                        }
                        continue;
                    }
                    else
                    {
                        // No puede acabar en H   SI QUE PUEDE, NOMBRES DE EMPRESAS
                        Results += "H";
                        CurrentPos++;
                        continue;
                    }
                }  // H


                if (CurrentChar == 'Q')
                {
                    if (CurrentPos != LastPos)
                    {
                        char SiguienteLetra = ATraducir[CurrentPos + 1];

                        // QU..
                        if (SiguienteLetra == 'U')
                        {
                            Results += "Q";
                            CurrentPos += 2;
                        }
                        else
                        {
                            Results += "K";
                            CurrentPos += 1;

                        }
                        continue;
                    }
                    else
                    {
                        // No puede acabar en Q   SI QUE PUEDE, NOMBRES DE EMPRESAS COMO BQ
                        Results += "K";
                        CurrentPos++;
                        continue;
                    }


                }  // Q


                if (CurrentChar == 'W')
                {
                    if (CurrentPos != LastPos)
                    {
                        char SiguienteLetra = ATraducir[CurrentPos + 1];


                        Results += "U";
                        CurrentPos += 1;

                        continue;
                    }
                    else
                    {
                        // No puede acabar en W   SI QUE PUEDE, NOMBRES DE EMPRESAS
                        Results += "U";
                        CurrentPos++;
                        continue;
                    }


                }  // W


                // Y doble R ?
                if (CurrentChar == 'R')
                {
                    Results += "R";
                    CurrentPos += 1;
                    continue;
                }  // R

                if (CurrentChar == 'S')
                {
                    if (CurrentPos != LastPos)
                    {

                        char SiguienteLetra = ATraducir[CurrentPos + 1];
                        if (IsVowel(SiguienteLetra))
                        {
                            Results += "S";
                            CurrentPos += 1;    // TD dos SSs
                        }
                        else
                        {
                            Results += "ES";
                            CurrentPos += 1;
                        }
                        continue;
                    }
                    else
                    {
                        // Si puede acabar en S
                        Results += "S";
                        CurrentPos += 1;
                        continue;
                    }


                }  // S

                if (CurrentChar == 'X')
                {
                    Results += "S";
                    CurrentPos += 1;
                    continue;
                }  // X


                if (CurrentChar == 'Z')
                {
                    Results += "Z";
                    CurrentPos += 1;
                    continue;
                }  // Z





                // El resto
                if (CurrentPos != LastPos)
                {
                    char SiguienteLetra = ATraducir[CurrentPos + 1];
                    if ((!IsVowel(SiguienteLetra)) && (CurrentPos == 0))
                    {
                        Results += "EX";
                        CurrentPos += 1;
                        continue;

                    }
                    else
                    {
                        Results += "X";
                        CurrentPos += 1;
                        continue;

                    }

                }


                CurrentPos++;



            }


            return Results;

        }
    }
}