using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi_Game
{
    class Program
    {
        static void BeginReversi(char [,] Tab)          //Preapare the Table to begin the game
        {
            int NumberOfLine = 0; 
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    Tab[i, j] = 'b';

            Tab[3,3] = 'r';
            Tab[4,4] = 'r';
            Tab[3,4] = 'w';
            Tab[4,3] = 'w';

            Console.WriteLine("  0|1|2|3|4|5|6|7");
            Console.WriteLine("  _|_|_|_|_|_|_|_");

            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0}",NumberOfLine);
                NumberOfLine++;

                for (int j = 0; j < 8; j++)
                {
                     Console.Write("|");

                        if (Tab[i, j] == 'w')
                            Console.BackgroundColor = ConsoleColor.White;
                        else if (Tab[i, j] == 'r')
                            Console.BackgroundColor = ConsoleColor.Red;
                        else
                            Console.BackgroundColor = ConsoleColor.Black;
                     Console.Write(" ");
                     Console.ResetColor();

                        if(j==7)
                          Console.Write("|");
                }
            Console.WriteLine();    
            Console.WriteLine(" |_|_|_|_|_|_|_|_|");
            }
        }

//--------------------------------------------------------------------------------------------------------------------

        static void ShowTab(char [,] Tab)
        {
            int NumberOfLine = 0;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  0|1|2|3|4|5|6|7");
            Console.WriteLine("  _|_|_|_|_|_|_|_");

            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0}", NumberOfLine);
                NumberOfLine++;

                for (int j = 0; j < 8; j++)
                {
                    Console.Write("|");

                    if (Tab[i, j] == 'w')
                        Console.BackgroundColor = ConsoleColor.White;
                    else if (Tab[i, j] == 'r')
                        Console.BackgroundColor = ConsoleColor.Red;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    Console.ResetColor();

                    if (j == 7)
                        Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine(" |_|_|_|_|_|_|_|_|");
            }
        }

        //---------------------------------------------------------------------------------------------------------------------

       static int CheckWhiteOptionNum(char[,] Tab, int[] WhereWhite)    //Check how much red we turn to white
        {
            int moneh = 0;

            moneh = moneh + CheckWhiteInLine_2(Tab, WhereWhite);
            moneh = moneh + CheckWhiteInColumn_2(Tab, WhereWhite);
            moneh = moneh + CheckWhiteInDig1_2(Tab, WhereWhite);
            moneh = moneh + CheckWhiteInDig2_2(Tab, WhereWhite);

            return moneh;
        }

       //---------------------------------------------------------------------------------------------------------------------

       static int CheckWhiteInLine_2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line
       {
           int moneh = 0;
           int WhereWhite2Column = -1;
           WhereWhite2Column = RightSideOfLineWhite_2(Tab, WhereWhite);
           if (WhereWhite2Column != -1)
           {
               for (int j = WhereWhite[1] + 1; j < WhereWhite2Column; j++)
                   moneh++;
           }

           WhereWhite2Column = -1;
           WhereWhite2Column = LeftSideOfLineWhite_2(Tab, WhereWhite);

           if (WhereWhite2Column != -1)
           {
               for (int j = WhereWhite[1] - 1; j > WhereWhite2Column; j--)
                   moneh++;
           }
           return moneh;
       }

       //----------------------------------------------------------------------------------------------------------------------

       static int RightSideOfLineWhite_2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going right
       {
           bool ThereWasRed = false;
           int Line = WhereWhite[0];

           for (int j = WhereWhite[1] + 1; j < 8; j++)
           {
               if (ThereWasRed == false)
               {
                   if (Tab[Line, j] == 'b')
                       return -1;
                   else if (Tab[Line, j] == 'w')
                       return -1;
                   else
                       ThereWasRed = true;
               }
               else
               {
                   if (Tab[Line, j] == 'b')
                       return -1;
                   else if (Tab[Line, j] == 'r')
                       continue;
                   else
                       return j;
               }
           }
           return -1;
       }

       //---------------------------------------------------------------------------------------------------------------------

       static int LeftSideOfLineWhite_2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going left
       {
           bool ThereWasRed = false;
           int Line = WhereWhite[0];

           for (int j = WhereWhite[1] - 1; j > -1; j--)
           {
               if (ThereWasRed == false)
               {
                   if (Tab[Line, j] == 'b')
                       return -1;
                   else if (Tab[Line, j] == 'w')
                       return -1;
                   else
                       ThereWasRed = true;
               }
               else
               {
                   if (Tab[Line, j] == 'b')
                       return -1;
                   else if (Tab[Line, j] == 'r')
                       continue;
                   else
                       return j;
               }
           }
           return -1;
       }

       //--------------------------------------------------------------------------------------------------------------------

       static int CheckWhiteInColumn_2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Column
       {
           int moneh = 0;
           int WhereWhite2Line = -1;
           WhereWhite2Line = TopSideOfColumnWhite_2(Tab, WhereWhite);
           if (WhereWhite2Line != -1)
           {
               for (int i = WhereWhite[0] + 1; i < WhereWhite2Line; i++)
                   moneh++;
           }

           WhereWhite2Line = -1;
           WhereWhite2Line = BottomSideOfColumnWhite_2(Tab, WhereWhite);

           if (WhereWhite2Line != -1)
           {
               for (int i = WhereWhite[0] - 1; i > WhereWhite2Line; i--)
                   moneh++;
           }
           return moneh;
       }

       //---------------------------------------------------------------------------------------------------------------------

       static int TopSideOfColumnWhite_2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Column - going up
       {
           bool ThereWasRed = false;
           int Column = WhereWhite[1];

           for (int i = WhereWhite[0] + 1; i < 8; i++)
           {
               if (ThereWasRed == false)
               {
                   if (Tab[i, Column] == 'b')
                       return -1;
                   else if (Tab[i, Column] == 'w')
                       return -1;
                   else
                       ThereWasRed = true;
               }
               else
               {
                   if (Tab[i, Column] == 'b')
                       return -1;
                   else if (Tab[i, Column] == 'r')
                       continue;
                   else
                       return i;
               }
           }
           return -1;
       }

       //--------------------------------------------------------------------------------------------------------------------

       static int BottomSideOfColumnWhite_2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going down
       {
           bool ThereWasRed = false;
           int Column = WhereWhite[1];

           for (int i = WhereWhite[0] - 1; i > -1; i--)
           {
               if (ThereWasRed == false)
               {
                   if (Tab[i, Column] == 'b')
                       return -1;
                   else if (Tab[i, Column] == 'w')
                       return -1;
                   else
                       ThereWasRed = true;
               }
               else
               {
                   if (Tab[i, Column] == 'b')
                       return -1;
                   else if (Tab[i, Column] == 'r')
                       continue;
                   else
                       return i;
               }
           }
           return -1;
       }

       //--------------------------------------------------------------------------------------------------------------------

       static int CheckWhiteInDig1_2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Dig1 - from left to right
       {
           int moneh = 0;
           int[] WhereWhite2Dig1 = new int[2];
           WhereWhite2Dig1[0] = -1;
           WhereWhite2Dig1[1] = -1;

           TopSideOfDig1White_2(Tab, WhereWhite, WhereWhite2Dig1);
           if (WhereWhite2Dig1[0] != -1 && WhereWhite2Dig1[1] != -1)
           {
               int j = WhereWhite[1] + 1;

               for (int i = WhereWhite[0] - 1; i > WhereWhite2Dig1[0]; i--)
               {
                   if (j < WhereWhite2Dig1[1])
                       moneh++;
                   j++;
               }
           }

           WhereWhite2Dig1[0] = -1;
           WhereWhite2Dig1[1] = -1;
           BottomSideOfDig1White_2(Tab, WhereWhite, WhereWhite2Dig1);

           if (WhereWhite2Dig1[0] != -1 && WhereWhite2Dig1[1] != -1)
           {
               int j = WhereWhite[1] - 1;

               for (int i = WhereWhite[0] + 1; i < WhereWhite2Dig1[0]; i++)
               {
                   if (j > WhereWhite2Dig1[1])
                       moneh++;
                   j--;
               }
           }
           return moneh;
       }

       //--------------------------------------------------------------------------------------------------------------------

       static void TopSideOfDig1White_2(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig1)    //Check if White affect something in Dig1 - from left to right - up
       {
           bool ThereWasRed = false;
           int j = WhereWhite[1] + 1;

           for (int i = WhereWhite[0] - 1; i > -1; i--)
           {
               if (j < 8)
               {
                   if (ThereWasRed == false)
                   {
                       if (Tab[i, j] == 'b')
                           break;
                       else if (Tab[i, j] == 'w')
                           break;
                       else
                           ThereWasRed = true;
                       j++;
                   }
                   else
                   {
                       if (Tab[i, j] == 'b')
                           break;
                       else if (Tab[i, j] == 'r')
                       {
                           j++;
                           continue;
                       }
                       else
                       {
                           WhereWhite2Dig1[0] = i;
                           WhereWhite2Dig1[1] = j;

                           break;
                       }
                   }
               }
           }
       }

       //--------------------------------------------------------------------------------------------------------------------

       static void BottomSideOfDig1White_2(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig1)//Check if White affect something in Dig1 - from left to right - down
       {
           bool ThereWasRed = false;
           int j = WhereWhite[1] - 1;

           for (int i = WhereWhite[0] + 1; i < 8; i++)
           {
               if (j > -1)
               {
                   if (ThereWasRed == false)
                   {
                       if (Tab[i, j] == 'b')
                           break;
                       else if (Tab[i, j] == 'w')
                           break;
                       else
                           ThereWasRed = true;
                       j--;
                   }
                   else
                   {
                       if (Tab[i, j] == 'b')
                           break;
                       else if (Tab[i, j] == 'r')
                       {
                           j--;
                           continue;
                       }
                       else
                       {
                           WhereWhite2Dig1[0] = i;
                           WhereWhite2Dig1[1] = j;
                           break;
                       }
                   }
               }
           }
       }

       //--------------------------------------------------------------------------------------------------------------------

       static int CheckWhiteInDig2_2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Dig2 - from right to left
       {
           int moneh = 0;
           int[] WhereWhite2Dig2 = new int[2];
           WhereWhite2Dig2[0] = -1;
           WhereWhite2Dig2[1] = -1;

           TopSideOfDig2White_2(Tab, WhereWhite, WhereWhite2Dig2);
           if (WhereWhite2Dig2[0] != -1 && WhereWhite2Dig2[1] != -1)
           {
               int j = WhereWhite[1] - 1;

               for (int i = WhereWhite[0] - 1; i > WhereWhite2Dig2[0]; i--)
               {
                   if (j > WhereWhite2Dig2[1])
                       moneh++;
                   j--;
               }
           }

           WhereWhite2Dig2[0] = -1;
           WhereWhite2Dig2[1] = -1;
           BottomSideOfDig2White_2(Tab, WhereWhite, WhereWhite2Dig2);

           if (WhereWhite2Dig2[0] != -1 && WhereWhite2Dig2[1] != -1)
           {
               int j = WhereWhite[1] + 1;

               for (int i = WhereWhite[0] + 1; i < WhereWhite2Dig2[0]; i++)
               {
                   if (j < WhereWhite2Dig2[1])
                       moneh++;
                   j++;
               }
           }
           return moneh;
       }

       //--------------------------------------------------------------------------------------------------------------------

       static void TopSideOfDig2White_2(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig2)    //Check if White affect something in Dig2 - from right to left - up
       {
           bool ThereWasRed = false;
           int i = WhereWhite[0] - 1;

           for (int j = WhereWhite[1] - 1; j > -1; j--)
           {
               if (i > -1)
               {
                   if (ThereWasRed == false)
                   {
                       if (Tab[i, j] == 'b')
                           break;
                       else if (Tab[i, j] == 'w')
                           break;
                       else
                           ThereWasRed = true;
                       i--;
                   }
                   else
                   {
                       if (Tab[i, j] == 'b')
                           break;
                       else if (Tab[i, j] == 'r')
                       {
                           i--;
                           continue;
                       }
                       else
                       {
                           WhereWhite2Dig2[0] = i;
                           WhereWhite2Dig2[1] = j;
                           break;
                       }
                   }
               }
           }
       }

       //--------------------------------------------------------------------------------------------------------------------

       static void BottomSideOfDig2White_2(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig2)//Check if White affect something in Dig2 - from right to left - down
       {
           bool ThereWasRed = false;
           int j = WhereWhite[1] + 1;

           for (int i = WhereWhite[0] + 1; i < 8; i++)
           {
               if (j < 8)
               {
                   if (ThereWasRed == false)
                   {
                       if (Tab[i, j] == 'b')
                           break;
                       else if (Tab[i, j] == 'w')
                           break;
                       else
                           ThereWasRed = true;
                       j++;
                   }
                   else
                   {
                       if (Tab[i, j] == 'b')
                           break;
                       else if (Tab[i, j] == 'r')
                       {
                           j++;
                           continue;
                       }
                       else
                       {
                           WhereWhite2Dig2[0] = i;
                           WhereWhite2Dig2[1] = j;
                           break;
                       }
                   }
               }
           }
       }

//--------------------------------------------------------------------------------------------------------------------

        static bool CheckWhite(char[,] Tab, int[] WhereWhite)    //Check if White affect something 
        {
            bool Check1 = false, Check2 = false, Check3 = false, Check4 = false, ResultCheck = false;
            Check1 = CheckWhiteInLine(Tab, WhereWhite);
            Check2 = CheckWhiteInColumn(Tab, WhereWhite);
            Check3 = CheckWhiteInDig1(Tab, WhereWhite);
            Check4 = CheckWhiteInDig2(Tab, WhereWhite);

            ResultCheck = Check1 || Check2 || Check3 || Check4;

            return ResultCheck;
        }

//---------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteInLine(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line
        {
            bool Check = false;
            int WhereWhite2Column = -1;
            WhereWhite2Column = RightSideOfLineWhite(Tab, WhereWhite);
            if (WhereWhite2Column != -1)
            {
                Check = true;

                for (int j = WhereWhite[1] + 1; j < WhereWhite2Column; j++)
                    Tab[WhereWhite[0], j] = 'w';
            }

            WhereWhite2Column = -1;
            WhereWhite2Column = LeftSideOfLineWhite(Tab, WhereWhite);

            if (WhereWhite2Column != -1)
            {
                Check = true;

                for (int j = WhereWhite[1] - 1; j > WhereWhite2Column; j--)
                    Tab[WhereWhite[0], j] = 'w';
            }
            return Check;
        }

//----------------------------------------------------------------------------------------------------------------------

        static int RightSideOfLineWhite(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going right
        {
            bool ThereWasRed = false;
            int Line = WhereWhite[0];

            for (int j = WhereWhite[1] + 1; j < 8; j++)
            {
                if (ThereWasRed == false)
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'w')
                        return -1;
                    else
                        ThereWasRed = true;
                }
                else
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'r')
                        continue;
                    else
                        return j;
                }
            }
            return -1;
        }

//---------------------------------------------------------------------------------------------------------------------

        static int LeftSideOfLineWhite(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going left
        {
            bool ThereWasRed = false;
            int Line = WhereWhite[0];

            for (int j = WhereWhite[1]-1; j > -1; j--)
            {
                if (ThereWasRed == false)
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'w')
                        return -1;
                    else
                        ThereWasRed = true;
                }
                else
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'r')
                        continue;
                    else
                        return j;
                }
            }
            return -1;
        } 

//--------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteInColumn(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Column
        {
            bool Check = false;
            int WhereWhite2Line = -1;
            WhereWhite2Line = TopSideOfColumnWhite(Tab, WhereWhite);
            if (WhereWhite2Line != -1)
            {
                Check = true;

                for (int i = WhereWhite[0] + 1; i < WhereWhite2Line; i++)
                    Tab[i, WhereWhite[1]] = 'w';
            }

            WhereWhite2Line = -1;
            WhereWhite2Line = BottomSideOfColumnWhite(Tab, WhereWhite);

            if (WhereWhite2Line != -1)
            {
                Check = true;

                for (int i = WhereWhite[0] - 1; i > WhereWhite2Line; i--)
                    Tab[i, WhereWhite[1]] = 'w';
            }
            return Check;
        } 

//---------------------------------------------------------------------------------------------------------------------

        static int TopSideOfColumnWhite(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Column - going up
        {
            bool ThereWasRed = false;
            int Column = WhereWhite[1];

            for (int i = WhereWhite[0] + 1; i < 8; i++)
            {
                if (ThereWasRed == false)
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'w')
                        return -1;
                    else
                        ThereWasRed = true;
                }
                else
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'r')
                        continue;
                    else
                        return i;
                }
            }
            return -1;
        }

//--------------------------------------------------------------------------------------------------------------------

        static int BottomSideOfColumnWhite(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going down
        {
            bool ThereWasRed = false;
            int Column = WhereWhite[1];

            for (int i = WhereWhite[0] - 1; i > -1; i--)
            {
                if (ThereWasRed == false)
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'w')
                        return -1;
                    else
                        ThereWasRed = true;
                }
                else
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'r')
                        continue;
                    else
                        return i;
                }
            }
            return -1;
        }

//--------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteInDig1(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Dig1 - from left to right
        {
            bool Check = false;
            int[] WhereWhite2Dig1 = new int[2];
            WhereWhite2Dig1[0] = -1;
            WhereWhite2Dig1[1] = -1;

            TopSideOfDig1White(Tab, WhereWhite, WhereWhite2Dig1);
            if (WhereWhite2Dig1[0] != -1 && WhereWhite2Dig1[1] != -1)
            {
                Check = true;

                int j = WhereWhite[1] + 1;

                for (int i = WhereWhite[0] - 1; i > WhereWhite2Dig1[0]; i--)
                {
                    if (j < WhereWhite2Dig1[1])
                        Tab[i, j] = 'w';
                    j++;
                }
            }

            WhereWhite2Dig1[0] = -1;
            WhereWhite2Dig1[1] = -1;
            BottomSideOfDig1White(Tab, WhereWhite, WhereWhite2Dig1);

            if (WhereWhite2Dig1[0] != -1 && WhereWhite2Dig1[1] != -1)
            {
                Check = true;

                int j = WhereWhite[1] - 1;

                for (int i = WhereWhite[0] + 1; i < WhereWhite2Dig1[0]; i++)
                {
                    if (j > WhereWhite2Dig1[1])
                        Tab[i, j] = 'w';
                    j--;
                }
            }
            return Check;
        } 

//--------------------------------------------------------------------------------------------------------------------

        static void TopSideOfDig1White(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig1)    //Check if White affect something in Dig1 - from left to right - up
        {
            bool ThereWasRed = false;
            int j = WhereWhite[1] + 1;

            for (int i = WhereWhite[0] - 1; i > -1; i--)
            {
                if (j < 8)
                {
                    if (ThereWasRed == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                            break;
                        else
                            ThereWasRed = true;
                        j++;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            WhereWhite2Dig1[0] = i;
                            WhereWhite2Dig1[1] = j;

                            break;
                        }
                    }
                }
            }
        }

//--------------------------------------------------------------------------------------------------------------------

        static void BottomSideOfDig1White(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig1)//Check if White affect something in Dig1 - from left to right - down
        {
            bool ThereWasRed = false;
            int j = WhereWhite[1] - 1;

            for (int i = WhereWhite[0] + 1; i < 8; i++)
            {
                if (j > -1)
                {
                    if (ThereWasRed == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                            break;
                        else
                            ThereWasRed = true;
                        j--;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                        {
                            j--;
                            continue;
                        }
                        else
                        {
                            WhereWhite2Dig1[0] = i;
                            WhereWhite2Dig1[1] = j;
                            break;
                        }
                    }
                }
            }
        }

//--------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteInDig2(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Dig2 - from right to left
        {
            bool Check = false;
            int[] WhereWhite2Dig2 = new int[2];
            WhereWhite2Dig2[0] = -1;
            WhereWhite2Dig2[1] = -1;

            TopSideOfDig2White(Tab, WhereWhite, WhereWhite2Dig2);
            if (WhereWhite2Dig2[0] != -1 && WhereWhite2Dig2[1] != -1)
            {
                Check = true;

                int j = WhereWhite[1] - 1;

                for (int i = WhereWhite[0] - 1; i > WhereWhite2Dig2[0]; i--)
                {
                    if (j > WhereWhite2Dig2[1])
                        Tab[i, j] = 'w';
                    j--;
                }
            }

            WhereWhite2Dig2[0] = -1;
            WhereWhite2Dig2[1] = -1;
            BottomSideOfDig2White(Tab, WhereWhite, WhereWhite2Dig2);

            if (WhereWhite2Dig2[0] != -1 && WhereWhite2Dig2[1] != -1)
            {
                Check = true;

                int j = WhereWhite[1] + 1;

                for (int i = WhereWhite[0] + 1; i < WhereWhite2Dig2[0]; i++)
                {
                    if (j < WhereWhite2Dig2[1])
                        Tab[i, j] = 'w';
                    j++;
                }
            }
            return Check;
        }

//--------------------------------------------------------------------------------------------------------------------

        static void TopSideOfDig2White(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig2)    //Check if White affect something in Dig2 - from right to left - up
        {
            bool ThereWasRed = false;
            int i = WhereWhite[0] - 1;

            for (int j = WhereWhite[1] - 1; j > -1; j--)
            {
                if (i > -1)
                {
                    if (ThereWasRed == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                            break;
                        else
                            ThereWasRed = true;
                        i--;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            WhereWhite2Dig2[0] = i;
                            WhereWhite2Dig2[1] = j;
                            break;
                        }
                    }
                }
            }
        }

//--------------------------------------------------------------------------------------------------------------------

        static void BottomSideOfDig2White(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig2)//Check if White affect something in Dig2 - from right to left - down
        {
            bool ThereWasRed = false;
            int j = WhereWhite[1] + 1;

            for (int i = WhereWhite[0] + 1; i < 8; i++)
            {
                if (j < 8)
                {
                    if (ThereWasRed == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                            break;
                        else
                            ThereWasRed = true;
                        j++;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            WhereWhite2Dig2[0] = i;
                            WhereWhite2Dig2[1] = j;
                            break;
                        }
                    }
                }
            }
        }

//--------------------------------------------------------------------------------------------------------------------

        static void AcceptRed(char[,] Tab, int[] WhereRed)       //Accept Red
        {
            int PositionInColumn = 0,PositionInLine = 0;
            string str = "";

            Console.WriteLine();
            Console.WriteLine("Red Turn:");
            Console.WriteLine();
            Console.Write("Enter which line to put the red:");
            str = Console.ReadLine();

            while (str.Length != 1 || int.Parse(str) > 7)
            {
                Console.Write("There isn't line " + str + "!!"); 
                Console.WriteLine();
                Console.Write("Enter which line to put the red:");
                str = Console.ReadLine();
            }
            PositionInLine = int.Parse(str);

            str = "";

            Console.Write("Enter which column to put the red:");
            str = Console.ReadLine();

            while (str.Length != 1 || int.Parse(str) > 7)
            {
                Console.Write("There isn't column " + str + "!!");
                Console.WriteLine();
                Console.Write("Enter which column to put the red:");
                str = Console.ReadLine();
            }
            PositionInColumn = int.Parse(str);

            WhereRed[0] = PositionInLine;
            WhereRed[1] = PositionInColumn;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckRed(char[,] Tab, int[] WhereRed)    //Check if Red affect something 
        {

            bool Check1 = false, Check2 = false, Check3 = false, Check4 = false,ResultCheck = false;
            Check1 = CheckRedInLine(Tab, WhereRed);
            Check2 = CheckRedInColumn(Tab, WhereRed);
            Check3 = CheckRedInDig1(Tab, WhereRed);
            Check4 = CheckRedInDig2(Tab, WhereRed);

            ResultCheck = Check1 || Check2 || Check3 || Check4;

            return ResultCheck;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static bool CheckRedInLine(char[,] Tab, int[] WhereRed)      //Check if Red affect something in line
        {

            bool Check = false;
            int WhereRed2Column = -1;
            WhereRed2Column = RightSideOfLineRed(Tab, WhereRed);
            if (WhereRed2Column != -1)
            {
                Check = true;

                for (int j = WhereRed[1] + 1; j < WhereRed2Column; j++)
                    Tab[WhereRed[0], j] = 'r';
            }

            WhereRed2Column = -1;
            WhereRed2Column = LeftSideOfLineRed(Tab, WhereRed);

            if (WhereRed2Column != -1)
            {
                Check = true;

                for (int j = WhereRed[1] - 1; j > WhereRed2Column; j--)
                    Tab[WhereRed[0], j] = 'r';
            }
            return Check;
        }

        //----------------------------------------------------------------------------------------------------------------------

        static int RightSideOfLineRed(char[,] Tab, int[] WhereRed)      //Check if Red affect something in line - going right
        {
            bool ThereWasWhite = false;
            int Line = WhereRed[0];

            for (int j = WhereRed[1] + 1; j < 8; j++)
            {
                if (ThereWasWhite == false)
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'r')
                        return -1;
                    else
                        ThereWasWhite = true;
                }
                else
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'w')
                        continue;
                    else
                        return j;
                }
            }
            return -1;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static int LeftSideOfLineRed(char[,] Tab, int[] WhereRed)      //Check if Red affect something in line - going left
        {
            bool ThereWasWhite = false;
            int Line = WhereRed[0];

            for (int j = WhereRed[1] - 1; j > -1; j--)
            {
                if (ThereWasWhite == false)
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'r')
                        return -1;
                    else
                        ThereWasWhite = true;
                }
                else
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'w')
                        continue;
                    else
                        return j;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckRedInColumn(char[,] Tab, int[] WhereRed)      //Check if Red affect something in Column
        {
            bool Check = false;
            int WhereRed2Line = -1;
            WhereRed2Line = TopSideOfColumnRed(Tab, WhereRed);
            if (WhereRed2Line != -1)
            {
                Check = true;

                for (int i = WhereRed[0] + 1; i < WhereRed2Line; i++)
                    Tab[i, WhereRed[1]] = 'r';
            }

            WhereRed2Line = -1;
            WhereRed2Line = BottomSideOfColumnRed(Tab, WhereRed);

            if (WhereRed2Line != -1)
            {
                Check = true;

                for (int i = WhereRed[0] - 1; i > WhereRed2Line; i--)
                    Tab[i, WhereRed[1]] = 'r';
            }
            return Check;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static int TopSideOfColumnRed(char[,] Tab, int[] WhereRed)      //Check if Red affect something in Column - going up
        {
            bool ThereWasWhite = false;
            int Column = WhereRed[1];

            for (int i = WhereRed[0] + 1; i < 8; i++)
            {
                if (ThereWasWhite == false)
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'r')
                        return -1;
                    else
                        ThereWasWhite = true;
                }
                else
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'w')
                        continue;
                    else
                        return i;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static int BottomSideOfColumnRed(char[,] Tab, int[] WhereRed)      //Check if Red affect something in line - going down
        {
            bool ThereWasWhite = false;
            int Column = WhereRed[1];

            for (int i = WhereRed[0] - 1; i > -1; i--)
            {
                if (ThereWasWhite == false)
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'r')
                        return -1;
                    else
                        ThereWasWhite = true;
                }
                else
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'w')
                        continue;
                    else
                        return i;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckRedInDig1(char[,] Tab, int[] WhereRed)      //Check if Red affect something in Dig1 - from left to right
        {
            bool Check = false;
            int[] WhereRed2Dig1 = new int[2];
            WhereRed2Dig1[0] = -1;
            WhereRed2Dig1[1] = -1;

            TopSideOfDig1Red(Tab, WhereRed, WhereRed2Dig1);
            if (WhereRed2Dig1[0] != -1 && WhereRed2Dig1[1] != -1)
            {
                Check = true;

                int j = WhereRed[1] + 1;

                for (int i = WhereRed[0] - 1; i > WhereRed2Dig1[0]; i--)
                {
                    if (j < WhereRed2Dig1[1])
                        Tab[i, j] = 'r';
                    j++;
                }
            }

            WhereRed2Dig1[0] = -1;
            WhereRed2Dig1[1] = -1;
            BottomSideOfDig1Red(Tab, WhereRed, WhereRed2Dig1);

            if (WhereRed2Dig1[0] != -1 && WhereRed2Dig1[1] != -1)
            {
                Check = true;

                int j = WhereRed[1] - 1;

                for (int i = WhereRed[0] + 1; i < WhereRed2Dig1[0]; i++)
                {
                    if (j > WhereRed2Dig1[1])
                        Tab[i, j] = 'r';
                    j--;
                }
            }
            return Check;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void TopSideOfDig1Red(char[,] Tab, int[] WhereRed, int[] WhereRed2Dig1)      //Check if Red affect something in Dig1 - from left to right - up
        {
            bool ThereWasWhite = false;
            int j = WhereRed[1] + 1;

            for (int i = WhereRed[0] - 1; i > -1; i--)
            {
                if (j < 8)
                {
                    if (ThereWasWhite == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                            break;
                        else
                            ThereWasWhite = true;
                        j++;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            WhereRed2Dig1[0] = i;
                            WhereRed2Dig1[1] = j;
                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void BottomSideOfDig1Red(char[,] Tab, int[] WhereRed, int[] WhereRed2Dig1)      //Check if Red affect something in Dig1 - from left to right - down
        {
            bool ThereWasWhite = false;
            int j = WhereRed[1] - 1;

            for (int i = WhereRed[0] + 1; i < 8; i++)
            {
                if (j > -1)
                {
                    if (ThereWasWhite == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                            break;
                        else
                            ThereWasWhite = true;
                        j--;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                        {
                            j--;
                            continue;
                        }
                        else
                        {
                            WhereRed2Dig1[0] = i;
                            WhereRed2Dig1[1] = j;

                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckRedInDig2(char[,] Tab, int[] WhereRed)      //Check if Red affect something in Dig2 - from right to left
        {
            bool Check = false;
            int[] WhereRed2Dig2 = new int[2];
            WhereRed2Dig2[0] = -1;
            WhereRed2Dig2[1] = -1;

            TopSideOfDig2Red(Tab, WhereRed, WhereRed2Dig2);
            if (WhereRed2Dig2[0] != -1 && WhereRed2Dig2[1] != -1)
            {
                Check = true;

                int j = WhereRed[1] - 1;

                for (int i = WhereRed[0] - 1; i > WhereRed2Dig2[0]; i--)
                {
                    if (j > WhereRed2Dig2[1])
                        Tab[i, j] = 'r';
                    j--;
                }
            }

            WhereRed2Dig2[0] = -1;
            WhereRed2Dig2[1] = -1;
            BottomSideOfDig2Red(Tab, WhereRed, WhereRed2Dig2);

            if (WhereRed2Dig2[0] != -1 && WhereRed2Dig2[1] != -1)
            {
                Check = true;

                int j = WhereRed[1] + 1;

                for (int i = WhereRed[0] + 1; i < WhereRed2Dig2[0]; i++)
                {
                    if (j < WhereRed2Dig2[1])
                        Tab[i, j] = 'r';
                    j++;
                }
            }
            return Check;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void TopSideOfDig2Red(char[,] Tab, int[] WhereRed, int[] WhereRed2Dig2)      //Check if Red affect something in Dig2 - from right to left - up
        {
            bool ThereWasWhite = false;
            int i = WhereRed[0] - 1;

            for (int j = WhereRed[1] - 1; j > -1; j--)
            {
                if (i > -1)
                {
                    if (ThereWasWhite == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                            break;
                        else
                            ThereWasWhite = true;
                        i--;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            WhereRed2Dig2[0] = i;
                            WhereRed2Dig2[1] = j;
                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void BottomSideOfDig2Red(char[,] Tab, int[] WhereRed, int[] WhereRed2Dig2)      //Check if Red affect something in Dig2 - from right to left - down
        {
            bool ThereWasWhite = false;
            int j = WhereRed[1] + 1;

            for (int i = WhereRed[0] + 1; i < 8; i++)
            {
                if (j < 8)
                {
                    if (ThereWasWhite == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                            break;
                        else
                            ThereWasWhite = true;
                        j++;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            WhereRed2Dig2[0] = i;
                            WhereRed2Dig2[1] = j;
                            break;
                        }
                    }
                }
            }
        }

//--------------------------------------------------------------------------------------------------------------------

        static bool CheckRedOption(char[,] Tab, int[] WhereRed)    //Check if Red affect something 
        {

            bool Check1 = false, Check2 = false, Check3 = false, Check4 = false, ResultCheck = false;
            Check1 = CheckRedInLineOption(Tab, WhereRed);
            Check2 = CheckRedInColumnOption(Tab, WhereRed);
            Check3 = CheckRedInDig1Option(Tab, WhereRed);
            Check4 = CheckRedInDig2Option(Tab, WhereRed);

            ResultCheck = Check1 || Check2 || Check3 || Check4;

            return ResultCheck;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static bool CheckRedInLineOption(char[,] Tab, int[] WhereRed)      //Check if Red affect something in line
        {

            bool Check = false;
            int WhereRed2Column = -1;
            WhereRed2Column = RightSideOfLineRedOption(Tab, WhereRed);
            if (WhereRed2Column != -1)
                Check = true;

            WhereRed2Column = -1;
            WhereRed2Column = LeftSideOfLineRedOption(Tab, WhereRed);

            if (WhereRed2Column != -1)
                Check = true;
            return Check;
        }

        //----------------------------------------------------------------------------------------------------------------------

        static int RightSideOfLineRedOption(char[,] Tab, int[] WhereRed)      //Check if Red affect something in line - going right
        {
            bool ThereWasWhite = false;
            int Line = WhereRed[0];

            for (int j = WhereRed[1] + 1; j < 8; j++)
            {
                if (ThereWasWhite == false)
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'r')
                        return -1;
                    else
                        ThereWasWhite = true;
                }
                else
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'w')
                        continue;
                    else
                        return j;
                }
            }
            return -1;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static int LeftSideOfLineRedOption(char[,] Tab, int[] WhereRed)      //Check if Red affect something in line - going left
        {
            bool ThereWasWhite = false;
            int Line = WhereRed[0];

            for (int j = WhereRed[1] - 1; j > -1; j--)
            {
                if (ThereWasWhite == false)
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'r')
                        return -1;
                    else
                        ThereWasWhite = true;
                }
                else
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'w')
                        continue;
                    else
                        return j;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckRedInColumnOption(char[,] Tab, int[] WhereRed)      //Check if Red affect something in Column
        {
            bool Check = false;
            int WhereRed2Line = -1;
            WhereRed2Line = TopSideOfColumnRedOption(Tab, WhereRed);
            if (WhereRed2Line != -1)
                Check = true;

            WhereRed2Line = -1;
            WhereRed2Line = BottomSideOfColumnRedOption(Tab, WhereRed);

            if (WhereRed2Line != -1)
                Check = true;
            return Check;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static int TopSideOfColumnRedOption(char[,] Tab, int[] WhereRed)      //Check if Red affect something in Column - going up
        {
            bool ThereWasWhite = false;
            int Column = WhereRed[1];

            for (int i = WhereRed[0] + 1; i < 8; i++)
            {
                if (ThereWasWhite == false)
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'r')
                        return -1;
                    else
                        ThereWasWhite = true;
                }
                else
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'w')
                        continue;
                    else
                        return i;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static int BottomSideOfColumnRedOption(char[,] Tab, int[] WhereRed)      //Check if Red affect something in line - going down
        {
            bool ThereWasWhite = false;
            int Column = WhereRed[1];

            for (int i = WhereRed[0] - 1; i > -1; i--)
            {
                if (ThereWasWhite == false)
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'r')
                        return -1;
                    else
                        ThereWasWhite = true;
                }
                else
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'w')
                        continue;
                    else
                        return i;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckRedInDig1Option(char[,] Tab, int[] WhereRed)      //Check if Red affect something in Dig1 - from left to right
        {
            bool Check = false;
            int[] WhereRed2Dig1 = new int[2];
            WhereRed2Dig1[0] = -1;
            WhereRed2Dig1[1] = -1;

            TopSideOfDig1RedOption(Tab, WhereRed, WhereRed2Dig1);
            if (WhereRed2Dig1[0] != -1 && WhereRed2Dig1[1] != -1)
                Check = true;

            WhereRed2Dig1[0] = -1;
            WhereRed2Dig1[1] = -1;
            BottomSideOfDig1RedOption(Tab, WhereRed, WhereRed2Dig1);

            if (WhereRed2Dig1[0] != -1 && WhereRed2Dig1[1] != -1)
                Check = true;
            return Check;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void TopSideOfDig1RedOption(char[,] Tab, int[] WhereRed, int[] WhereRed2Dig1)  //Check if Red affect something in Dig1 - from left to right - up
        {
            bool ThereWasWhite = false;
            int j = WhereRed[1] + 1;

            for (int i = WhereRed[0] - 1; i > -1; i--)
            {
                if (j < 8)
                {
                    if (ThereWasWhite == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                            break;
                        else
                            ThereWasWhite = true;
                        j++;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            WhereRed2Dig1[0] = i;
                            WhereRed2Dig1[1] = j;
                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void BottomSideOfDig1RedOption(char[,] Tab, int[] WhereRed, int[] WhereRed2Dig1)//Check if Red affect something in Dig1 - from left to right - down
        {
            bool ThereWasWhite = false;
            int j = WhereRed[1] - 1;

            for (int i = WhereRed[0] + 1; i < 8; i++)
            {
                if (j > -1)
                {
                    if (ThereWasWhite == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                            break;
                        else
                            ThereWasWhite = true;
                        j--;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                        {
                            j--;
                            continue;
                        }
                        else
                        {
                            WhereRed2Dig1[0] = i;
                            WhereRed2Dig1[1] = j;

                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckRedInDig2Option(char[,] Tab, int[] WhereRed)      //Check if Red affect something in Dig2 - from right to left
        {
            bool Check = false;
            int[] WhereRed2Dig2 = new int[2];
            WhereRed2Dig2[0] = -1;
            WhereRed2Dig2[1] = -1;

            TopSideOfDig2RedOption(Tab, WhereRed, WhereRed2Dig2);
            if (WhereRed2Dig2[0] != -1 && WhereRed2Dig2[1] != -1)
                Check = true;

            WhereRed2Dig2[0] = -1;
            WhereRed2Dig2[1] = -1;
            BottomSideOfDig2RedOption(Tab, WhereRed, WhereRed2Dig2);

            if (WhereRed2Dig2[0] != -1 && WhereRed2Dig2[1] != -1)
                Check = true;
            return Check;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void TopSideOfDig2RedOption(char[,] Tab, int[] WhereRed, int[] WhereRed2Dig2)//Check if Red affect something in Dig2 - from right to left - up
        {
            bool ThereWasWhite = false;
            int i = WhereRed[0] - 1;

            for (int j = WhereRed[1] - 1; j > -1; j--)
            {
                if (i > -1)
                {
                    if (ThereWasWhite == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                            break;
                        else
                            ThereWasWhite = true;
                        i--;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            WhereRed2Dig2[0] = i;
                            WhereRed2Dig2[1] = j;
                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void BottomSideOfDig2RedOption(char[,] Tab, int[] WhereRed, int[] WhereRed2Dig2)//Check if Red affect something in Dig2 - from right to left - down
        {
            bool ThereWasWhite = false;
            int j = WhereRed[1] + 1;

            for (int i = WhereRed[0] + 1; i < 8; i++)
            {
                if (j < 8)
                {
                    if (ThereWasWhite == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                            break;
                        else
                            ThereWasWhite = true;
                        j++;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            WhereRed2Dig2[0] = i;
                            WhereRed2Dig2[1] = j;
                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool ThereIsOtherOptionRedfunc(char[,] Tab)
        {
            int[] WhereRed = new int[2];
            for (int i = 0; i < Tab.GetLength(0); i++)
            {
                for (int j = 0; j < Tab.GetLength(1); j++)
                {
                    if (Tab[i, j] == 'b')
                    {
                        if (j + 1 < 8)
                        {
                            if (Tab[i, j + 1] == 'w')
                            {
                                WhereRed[0] = i;
                                WhereRed[1] = j;

                                if (CheckRedOption(Tab, WhereRed) == true){
                                    return true;
                                }
                            }
                        }
                        if (j - 1 > -1)
                        {
                            if (Tab[i, j - 1] == 'w')
                            {
                                WhereRed[0] = i;
                                WhereRed[1] = j;

                                if (CheckRedOption(Tab, WhereRed) == true)
                                    return true;
                            }
                        }
                        if (i + 1 < 8)
                        {
                            if (Tab[i + 1, j] == 'w')
                            {
                                WhereRed[0] = i;
                                WhereRed[1] = j;

                                if (CheckRedOption(Tab, WhereRed) == true)
                                    return true;
                            }
                        }
                        if (i - 1 > -1)
                        {
                            if (Tab[i - 1, j] == 'w')
                            {
                                WhereRed[0] = i;
                                WhereRed[1] = j;

                                if (CheckRedOption(Tab, WhereRed) == true)
                                    return true;
                            }
                        }
                        if (i - 1 > -1 && j - 1 > -1)
                        {
                            if (Tab[i - 1, j - 1] == 'w')
                            {
                                WhereRed[0] = i;
                                WhereRed[1] = j;

                                if (CheckRedOption(Tab, WhereRed) == true)
                                    return true;
                            }
                        }
                        if (i + 1 < 8 && j + 1 < 8)
                        {
                            if (Tab[i + 1, j + 1] == 'w')
                            {
                                WhereRed[0] = i;
                                WhereRed[1] = j;

                                if (CheckRedOption(Tab, WhereRed) == true)
                                    return true;
                            }
                        }
                        if (i - 1 > -1 && j + 1 < 8)
                        {
                            if (Tab[i - 1, j + 1] == 'w')
                            {
                                WhereRed[0] = i;
                                WhereRed[1] = j;

                                if (CheckRedOption(Tab, WhereRed) == true)
                                    return true;
                            }
                        }
                        if (i + 1 < 8 && j - 1 > -1)
                        {
                            if (Tab[i + 1, j - 1] == 'w')
                            {
                                WhereRed[0] = i;
                                WhereRed[1] = j;

                                if (CheckRedOption(Tab, WhereRed) == true)
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        //----------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteOption(char[,] Tab, int[] WhereWhite)    //Check if White affect something 
        {
            bool Check1 = false, Check2 = false, Check3 = false, Check4 = false, ResultCheck = false;
            Check1 = CheckWhiteInLineOption(Tab, WhereWhite);
            Check2 = CheckWhiteInColumnOption(Tab, WhereWhite);
            Check3 = CheckWhiteInDig1Option(Tab, WhereWhite);
            Check4 = CheckWhiteInDig2Option(Tab, WhereWhite);

            ResultCheck = Check1 || Check2 || Check3 || Check4;

            return ResultCheck;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteInLineOption(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line
        {
            bool Check = false;
            int WhereWhite2Column = -1;
            WhereWhite2Column = RightSideOfLineWhiteOption(Tab, WhereWhite);
            if (WhereWhite2Column != -1)
                Check = true;

            WhereWhite2Column = -1;
            WhereWhite2Column = LeftSideOfLineWhiteOption(Tab, WhereWhite);

            if (WhereWhite2Column != -1)
                Check = true;
            return Check;
        }

        //----------------------------------------------------------------------------------------------------------------------

        static int RightSideOfLineWhiteOption(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going right
        {
            bool ThereWasRed = false;
            int Line = WhereWhite[0];

            for (int j = WhereWhite[1] + 1; j < 8; j++)
            {
                if (ThereWasRed == false)
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'w')
                        return -1;
                    else
                        ThereWasRed = true;
                }
                else
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'r')
                        continue;
                    else
                        return j;
                }
            }
            return -1;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static int LeftSideOfLineWhiteOption(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going left
        {
            bool ThereWasRed = false;
            int Line = WhereWhite[0];

            for (int j = WhereWhite[1] - 1; j > -1; j--)
            {
                if (ThereWasRed == false)
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'w')
                        return -1;
                    else
                        ThereWasRed = true;
                }
                else
                {
                    if (Tab[Line, j] == 'b')
                        return -1;
                    else if (Tab[Line, j] == 'r')
                        continue;
                    else
                        return j;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteInColumnOption(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Column
        {
            bool Check = false;
            int WhereWhite2Line = -1;
            WhereWhite2Line = TopSideOfColumnWhiteOption(Tab, WhereWhite);
            if (WhereWhite2Line != -1)
                Check = true;

            WhereWhite2Line = -1;
            WhereWhite2Line = BottomSideOfColumnWhiteOption(Tab, WhereWhite);

            if (WhereWhite2Line != -1)
                Check = true;
            return Check;
        }

        //---------------------------------------------------------------------------------------------------------------------

        static int TopSideOfColumnWhiteOption(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Column - going up
        {
            bool ThereWasRed = false;
            int Column = WhereWhite[1];

            for (int i = WhereWhite[0] + 1; i < 8; i++)
            {
                if (ThereWasRed == false)
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'w')
                        return -1;
                    else
                        ThereWasRed = true;
                }
                else
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'r')
                        continue;
                    else
                        return i;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static int BottomSideOfColumnWhiteOption(char[,] Tab, int[] WhereWhite)      //Check if White affect something in line - going down
        {
            bool ThereWasRed = false;
            int Column = WhereWhite[1];

            for (int i = WhereWhite[0] - 1; i > -1; i--)
            {
                if (ThereWasRed == false)
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'w')
                        return -1;
                    else
                        ThereWasRed = true;
                }
                else
                {
                    if (Tab[i, Column] == 'b')
                        return -1;
                    else if (Tab[i, Column] == 'r')
                        continue;
                    else
                        return i;
                }
            }
            return -1;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteInDig1Option(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Dig1 - from left to right
        {
            bool Check = false;
            int[] WhereWhite2Dig1 = new int[2];
            WhereWhite2Dig1[0] = -1;
            WhereWhite2Dig1[1] = -1;

            TopSideOfDig1WhiteOption(Tab, WhereWhite, WhereWhite2Dig1);
            if (WhereWhite2Dig1[0] != -1 && WhereWhite2Dig1[1] != -1)
                Check = true;

            WhereWhite2Dig1[0] = -1;
            WhereWhite2Dig1[1] = -1;
            BottomSideOfDig1WhiteOption(Tab, WhereWhite, WhereWhite2Dig1);

            if (WhereWhite2Dig1[0] != -1 && WhereWhite2Dig1[1] != -1)
                Check = true;
            return Check;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void TopSideOfDig1WhiteOption(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig1)    //Check if White affect something in Dig1 - from left to right - up
        {
            bool ThereWasRed = false;
            int j = WhereWhite[1] + 1;

            for (int i = WhereWhite[0] - 1; i > -1; i--)
            {
                if (j < 8)
                {
                    if (ThereWasRed == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                            break;
                        else
                            ThereWasRed = true;
                        j++;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            WhereWhite2Dig1[0] = i;
                            WhereWhite2Dig1[1] = j;

                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void BottomSideOfDig1WhiteOption(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig1)//Check if White affect something in Dig1 - from left to right - down
        {
            bool ThereWasRed = false;
            int j = WhereWhite[1] - 1;

            for (int i = WhereWhite[0] + 1; i < 8; i++)
            {
                if (j > -1)
                {
                    if (ThereWasRed == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                            break;
                        else
                            ThereWasRed = true;
                        j--;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                        {
                            j--;
                            continue;
                        }
                        else
                        {
                            WhereWhite2Dig1[0] = i;
                            WhereWhite2Dig1[1] = j;
                            break;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------

        static bool CheckWhiteInDig2Option(char[,] Tab, int[] WhereWhite)      //Check if White affect something in Dig2 - from right to left
        {
            bool Check = false;
            int[] WhereWhite2Dig2 = new int[2];
            WhereWhite2Dig2[0] = -1;
            WhereWhite2Dig2[1] = -1;

            TopSideOfDig2WhiteOption(Tab, WhereWhite, WhereWhite2Dig2);
            if (WhereWhite2Dig2[0] != -1 && WhereWhite2Dig2[1] != -1)
                Check = true;

            WhereWhite2Dig2[0] = -1;
            WhereWhite2Dig2[1] = -1;
            BottomSideOfDig2WhiteOption(Tab, WhereWhite, WhereWhite2Dig2);

            if (WhereWhite2Dig2[0] != -1 && WhereWhite2Dig2[1] != -1)
                Check = true;
            return Check;
        }

        //--------------------------------------------------------------------------------------------------------------------

        static void TopSideOfDig2WhiteOption(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig2)//Check if White affect something in Dig2 - from right to left - up
        {
            bool ThereWasRed = false;
            int i = WhereWhite[0] - 1;

            for (int j = WhereWhite[1] - 1; j > -1; j--)
            {
                if (i > -1)
                {
                    if (ThereWasRed == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                            break;
                        else
                            ThereWasRed = true;
                        i--;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            WhereWhite2Dig2[0] = i;
                            WhereWhite2Dig2[1] = j;
                            break;
                        }
                    }
                }
            }
        }

    //--------------------------------------------------------------------------------------------------------------------

        static void BottomSideOfDig2WhiteOption(char[,] Tab, int[] WhereWhite, int[] WhereWhite2Dig2)//Check if White affect something in Dig2 - from right to left - down
        {
            bool ThereWasRed = false;
            int j = WhereWhite[1] + 1;

            for (int i = WhereWhite[0] + 1; i < 8; i++)
            {
                if (j < 8)
                {
                    if (ThereWasRed == false)
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'w')
                            break;
                        else
                            ThereWasRed = true;
                        j++;
                    }
                    else
                    {
                        if (Tab[i, j] == 'b')
                            break;
                        else if (Tab[i, j] == 'r')
                        {
                            j++;
                            continue;
                        }
                        else
                        {
                            WhereWhite2Dig2[0] = i;
                            WhereWhite2Dig2[1] = j;
                            break;
                        }
                    }
                }
            }
        }

    //--------------------------------------------------------------------------------------------------------------------

        static bool ThereIsOtherOptionWhitefunc(char[,] Tab)
        {
            int[] WhereWhite = new int[2];
            for (int i = 0; i < Tab.GetLength(0); i++)
            {
                for (int j = 0; j < Tab.GetLength(1); j++)
                {
                    if (Tab[i, j] == 'b')
                    {
                        if (j + 1 < 8)
                        {
                            if (Tab[i, j + 1] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                    return true;
                            }
                        }
                        if (j - 1 > -1)
                        {
                            if (Tab[i, j - 1] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                    return true;
                            }
                        }
                        if (i + 1 < 8)
                        {
                            if (Tab[i + 1, j] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                    return true;
                            }
                        }
                        if (i - 1 > -1)
                        {
                            if (Tab[i - 1, j] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                    return true;
                            }
                        }
                        if (i - 1 > -1 && j - 1 > -1)
                        {
                            if (Tab[i - 1, j - 1] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                    return true;
                            }
                        }
                        if (i + 1 < 8 && j + 1 < 8)
                        {
                            if (Tab[i + 1, j + 1] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                    return true;
                            }
                        }
                        if (i - 1 > -1 && j + 1 < 8)
                        {
                            if (Tab[i - 1, j + 1] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                    return true;
                            }
                        }
                        if (i + 1 < 8 && j - 1 > -1)
                        {
                            if (Tab[i + 1, j - 1] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

    //--------------------------------------------------------------------------------------------------------------------

        static void FindWhereToPut(char[,] Tab, int[] WhereWhite)           //Choose the place that will turn the most red to white
        {       
            int CurrentMax = 0;
            int NewMax = int.MinValue;
            int [] CurrentWhereWhite = new int[2];
            for (int i = 0; i < Tab.GetLength(0); i++)
            {
                for (int j = 0; j < Tab.GetLength(1); j++)
                {
                    if (Tab[i, j] == 'b')
                    {

                        if (j + 1 < 8)
                        {
                            if (Tab[i, j + 1] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                {
                                    NewMax = CheckWhiteOptionNum(Tab, WhereWhite);

                                    if (CurrentMax >= NewMax)
                                    {
                                        WhereWhite[0] = CurrentWhereWhite[0];
                                        WhereWhite[1] = CurrentWhereWhite[1];
                                    }
                                    else
                                    {
                                        CurrentMax = NewMax;

                                        CurrentWhereWhite[0] = WhereWhite[0];
                                        CurrentWhereWhite[1] = WhereWhite[1];
                                    }
                                }
                            }
                        }
                        if (j - 1 > -1)
                        {
                            if (Tab[i, j - 1] == 'r')
                            {
                                
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                {
                                    NewMax = CheckWhiteOptionNum(Tab, WhereWhite);

                                    if (CurrentMax >= NewMax)
                                    {
                                        WhereWhite[0] = CurrentWhereWhite[0];
                                        WhereWhite[1] = CurrentWhereWhite[1];
                                    }
                                    else
                                    {
                                        CurrentMax = NewMax;

                                        CurrentWhereWhite[0] = WhereWhite[0];
                                        CurrentWhereWhite[1] = WhereWhite[1];
                                    }
                                }
                            }
                        }
                        if (i + 1 < 8)
                        {
                            if (Tab[i + 1, j] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                {
                                    NewMax = CheckWhiteOptionNum(Tab, WhereWhite);

                                    if (CurrentMax >= NewMax)
                                    {
                                        WhereWhite[0] = CurrentWhereWhite[0];
                                        WhereWhite[1] = CurrentWhereWhite[1];
                                    }
                                    else
                                    {
                                        CurrentMax = NewMax;

                                        CurrentWhereWhite[0] = WhereWhite[0];
                                        CurrentWhereWhite[1] = WhereWhite[1];
                                    }
                                }
                            }
                        }
                        if (i - 1 > -1)
                        {
                            if (Tab[i - 1, j] == 'r')
                            {
                              
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                {
                                    NewMax = CheckWhiteOptionNum(Tab, WhereWhite);

                                    if (CurrentMax >= NewMax)
                                    {
                                        WhereWhite[0] = CurrentWhereWhite[0];
                                        WhereWhite[1] = CurrentWhereWhite[1];
                                    }
                                    else
                                    {
                                        CurrentMax = NewMax;

                                        CurrentWhereWhite[0] = WhereWhite[0];
                                        CurrentWhereWhite[1] = WhereWhite[1];
                                    }
                                }
                            }
                        }
                        if (i - 1 > -1 && j - 1 > -1)
                        {
                            if (Tab[i - 1, j - 1] == 'r')
                            {
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                {
                                    NewMax = CheckWhiteOptionNum(Tab, WhereWhite);

                                    if (CurrentMax >= NewMax)
                                    {
                                        WhereWhite[0] = CurrentWhereWhite[0];
                                        WhereWhite[1] = CurrentWhereWhite[1];
                                    }
                                    else
                                    {
                                        CurrentMax = NewMax;

                                        CurrentWhereWhite[0] = WhereWhite[0];
                                        CurrentWhereWhite[1] = WhereWhite[1];
                                    }
                                }
                            }
                        }
                        if (i + 1 < 8 && j + 1 < 8)
                        {
                            if (Tab[i + 1, j + 1] == 'r')
                            {
                                
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                {
                                    NewMax = CheckWhiteOptionNum(Tab, WhereWhite);

                                    if (CurrentMax >= NewMax)
                                    {
                                        WhereWhite[0] = CurrentWhereWhite[0];
                                        WhereWhite[1] = CurrentWhereWhite[1];
                                    }
                                    else
                                    {
                                        CurrentMax = NewMax;

                                        CurrentWhereWhite[0] = WhereWhite[0];
                                        CurrentWhereWhite[1] = WhereWhite[1];
                                    }
                                }
                            }
                        }
                        if (i - 1 > -1 && j + 1 < 8)
                        {
                            if (Tab[i - 1, j + 1] == 'r')
                            {
                               
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                {
                                    NewMax = CheckWhiteOptionNum(Tab, WhereWhite);

                                    if (CurrentMax >= NewMax)
                                    {
                                        WhereWhite[0] = CurrentWhereWhite[0];
                                        WhereWhite[1] = CurrentWhereWhite[1];
                                    }
                                    else
                                    {
                                        CurrentMax = NewMax;

                                        CurrentWhereWhite[0] = WhereWhite[0];
                                        CurrentWhereWhite[1] = WhereWhite[1];
                                    }
                                }
                            }
                        }
                        if (i + 1 < 8 && j - 1 > -1)
                        {
                            if (Tab[i + 1, j - 1] == 'r')
                            {
                                
                                WhereWhite[0] = i;
                                WhereWhite[1] = j;

                                if (CheckWhiteOption(Tab, WhereWhite) == true)
                                {
                                    NewMax = CheckWhiteOptionNum(Tab, WhereWhite);

                                    if (CurrentMax >= NewMax)
                                    {
                                        WhereWhite[0] = CurrentWhereWhite[0];
                                        WhereWhite[1] = CurrentWhereWhite[1];
                                    }
                                    else
                                    {
                                        CurrentMax = NewMax;

                                        CurrentWhereWhite[0] = WhereWhite[0];
                                        CurrentWhereWhite[1] = WhereWhite[1];
                                    }
                                }
                            }
                        }
                    }
                }
            }

            WhereWhite[0] = CurrentWhereWhite[0];
            WhereWhite[1] = CurrentWhereWhite[1];
        }


        //--------------------------------------------------------------------------------------------------------------------

        static void TheWinner(char[,] Tab)              //Tell us who is the winner
        {
            int SumRed = 0, SumWhite = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Tab[i, j] == 'r')
                        SumRed++;
                    else
                        SumWhite++;
                }
            }

            Console.WriteLine("The number of Red's cube is:{0}", SumRed);
            Console.WriteLine("The number of White's is:{0}", SumWhite);

            Console.WriteLine();

            Console.Write("The winner is:");

            if (SumRed > SumWhite)
                Console.Write("Red!!!");
            else if (SumRed < SumWhite)
                Console.Write("White!!!");
        }

        //*********************************************************************************************************************
        static void Main(string[] args)
        {
            string again = "again";

            while (again == "again")
            {
                char[,] Tab = new char[8, 8];
                bool Check = false, Continue1 = false,ThereIsOtherOptionRed , Break1 = false, Break2 = false;
                int[] WhereRed = new int[2];
                int[] WhereWhite = new int[2];
                int Game = 1;

                BeginReversi(Tab);

                while (Game <= 60)
                {
                    ThereIsOtherOptionRed = ThereIsOtherOptionRedfunc(Tab);
                    while (Check == false && ThereIsOtherOptionRed == true)
                    {
                        AcceptRed(Tab, WhereRed);

                        if (Tab[WhereRed[0], WhereRed[1]] != 'r')
                        {
                            if (Tab[WhereRed[0], WhereRed[1]] != 'w')
                            {
                                Continue1 = true;
                                Check = CheckRed(Tab, WhereRed);
                                if (Check == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Ilegal move");
                                }
                            }
                        }
                        if (Continue1 == false)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ilegal move");
                        }
                        if (ThereIsOtherOptionRed == false)
                        {
                            Break1 = true;
                            break;
                        }
                    }
                    if (Break1 == false)
                    {
                        Tab[WhereRed[0], WhereRed[1]] = 'r';
                        Game++;
                    }

                    Continue1 = false;

                    ShowTab(Tab);

                    System.Threading.Thread.Sleep(3000);

                    Check = false;

                    if (ThereIsOtherOptionWhitefunc(Tab) == true)
                    {
                        FindWhereToPut(Tab, WhereWhite);

                        Check = CheckWhite(Tab, WhereWhite);
                    }
                    else 
                        Break2 = true;

                    if (Break2 == false)
                    {
                        Tab[WhereWhite[0], WhereWhite[1]] = 'w';
                        Game++;
                    } 

                    if (Break1 == true && Break2 == true)
                        break;

                    Check = false;
                    Break2 = false;
                    Break1 = false;


                    ShowTab(Tab);
                }
                Console.WriteLine();
                TheWinner(Tab);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Do you want to play again? enter 'again' to play again/any other sentence to finish");
                again = Console.ReadLine();
            }
        }
    }
}

