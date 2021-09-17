using System;
using System.Collections.Generic;
using System.Linq;

namespace bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] GameList = new int[10,2];
            //int[] arr = { 1,1,1,1,1,1,1,1,1,1,1,1 };
            //int[] arr = { 1, 9,1,1,1,};
            //int[] arr = { 1, 9, 10, 1, 1, };
            //int[] arr = { 10, 1, 9, 1, };
            //int[] arr = { 10, 10, 1, 9, 1, };
            //int[] arr = { 10, 10, 10,1, 9, 1, };
            //int[] arr = { 1, 1, 1, 1, 9,1,2,8,9,1,10,10,10,10,1,8};
            //int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10,   10,10,10 };
            //int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10,   10, 1, 9 };
            //int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10,    1, 9,9 };
            //int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10,    1, 9, 10 };
            //int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10,    1, 1 };
            //int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10,    1, 8 };
            //int[] arr = { 1, 9, 5, 5, 7, 0,10 };
            int[] arr = { 10, 10, 5, 4, 7, 0, 10 };
            //int[] arr = { 10, 10, 10, 4, 7, 0, 10 };

            int firstball = 0;
            int secondball = 0;
            bool firststrike = false;
            bool secondstrike = false;           
            int gameCount = 0;
            int gamecount2 = 8;
            bool spare = false;


            for (int i = 0; i <GameList.GetLength(1); i++)
            {
                //all incomplete game as 0, completed as 1
                GameList[i, 1] = 0;
            }

            for (int i = 0; i < arr.Length; i++)
            {                
                if (gameCount>8)
                {
                    gamecount2 += 1;
                }

                if (arr[i]<10)
                {
                    if (firstball==0)
                    {
                        if (secondstrike==true)
                        {
                            if (gamecount2 == 10)
                            {
                                GameList[gameCount - 1,0] += arr[i];
                                GameList[gameCount - 1, 1] = 1;
                            }

                            if (gamecount2 == 11)
                            {
                                GameList[gameCount,0] += arr[i];
                            }

                            if (gamecount2 < 10)                            
                            {
                                GameList[gameCount - 2,0] += arr[i];
                                GameList[gameCount - 2, 1] = 1;

                                GameList[gameCount - 1, 0] += arr[i];
                                

                            }
                        }

                        if (firststrike == true)
                        {                            
                            if (secondstrike==false)
                            {
                                GameList[gameCount - 1,0] += arr[i];
                                GameList[gameCount - 1, 1] = 1;  
                            }                                                      
                        }

                        firstball = arr[i];
                        GameList[gameCount,0] += firstball;
                        if (i==11)
                        {
                            GameList[gameCount, 1] = 1;
                        }

                        if (spare==true && gameCount!=9)
                        {
                            GameList[gameCount - 1, 0] += arr[i];
                            GameList[gameCount - 1, 1] = 1;
                        }

                    }
                    else
                    {
                        if (firstball+secondball==10)
                        {
                            spare = true;
                            if (arr[i]<10)
                            {
                                GameList[gameCount - 1,0] += arr[i];                             
                                firstball = arr[i];
                                secondball = 0;                                
                                GameList[gameCount,0] = arr[i];
                                GameList[gameCount-1, 1] = 1; //openframe
                            }

                            if (gamecount2 > 9)
                            {
                                GameList[gameCount - 1,0] += arr[i];
                            }
                        }
                        else
                        {
                            spare = false;
                            secondball = arr[i];

                            GameList[gameCount,0] += secondball;

                            if (firstball + secondball != 10)
                            {                                
                                GameList[gameCount, 1] = 1; //openframe
                            }
                            else
                            {
                                spare = true;
                            }

                            if ((firststrike || secondstrike) || (firstball + secondball == 10 && gameCount==9))
                            {
                                if (i!=11)
                                {
                                    if (gameCount>0 )
                                    {
                                        GameList[gameCount - 1, 0] += arr[i];
                                        GameList[gameCount - 1, 1] = 1;
                                    }
                                  
                                    firststrike = false;
                                    secondstrike = false;
                                }                                
                            }

                            if (gameCount<9)
                                gameCount += 1;

                            if (gamecount2 == 11 )
                            {

                                if (gamecount2 > 9)
                                {
                                    //GameList[gameCount - 1,0] += GameList[gameCount,0];
                                }
                            }
                            else
                            {
                                GameList[gameCount, 1] = 1;    
                            }
                            firstball = 0;
                            secondball = 0;
                        }                        
                    }                    
                }
                else
                {
                    if (firststrike == false)
                    {
                        if (gamecount2==11)
                        {
                            GameList[gameCount,0] += arr[i];
                            GameList[gameCount, 1] = 1;
                        }
                        else
                        {
                            GameList[gameCount,0] = arr[i];
                            if (spare == true || firstball + secondball == 10)
                            {
                                GameList[gameCount - 1,0] += arr[i];
                                GameList[gameCount - 1, 1] = 1;
                                firstball = 0;
                                secondball = 0;
                                spare = false;
                            }
                            gameCount += 1;
                            firststrike = true;  
                        }                     
                    }
                    else
                    {
                        if (secondstrike==false)
                        {
                            GameList[gameCount - 1,0] += arr[i];                            
                            GameList[gameCount,0] = arr[i];
                            gameCount += 1;
                        
                            secondstrike = true;
                        }
                        else
                        {                       
                            if (gamecount2 < 10)
                            { 
                                GameList[gameCount - 2,0] += arr[i];
                                GameList[gameCount - 1,0] += arr[i];
                                GameList[gameCount,0] = arr[i];
                                GameList[gameCount-2, 1] = 1;
                            }

                            if (gameCount < 9)
                            {
                                gameCount += 1;                                
                            }

                            if (gamecount2 == 10)
                            {
                                GameList[gameCount - 1,0] += arr[i];
                                GameList[gameCount,0] += arr[i];
                            }
                                
                            if (gamecount2 == 11)
                            {
                                GameList[gameCount,0] += arr[i];
                                GameList[gameCount - 1, 1] = 1;
                                GameList[gameCount, 1] = 1;                                
                            }                       
                        }
                    }
                }
            }

            int sum = 0;
            for (int i = 0; i < GameList.GetLength(0); i++)
            {
                if (GameList[i,1]==1)
                {
                    Console.WriteLine(GameList[i, 0] + sum);
                    sum += GameList[i, 0];
                }
                
            }
        }
    }
}
