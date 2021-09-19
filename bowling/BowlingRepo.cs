using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bowling
{
    public class BowlingRepo
    {     

        public Response GetMark(payload p)
        {
            int[,] GameList = new int[10, 2];
            Response resp = new Response();
            resp.gameCompleted = true;
            int[] arr;
            arr = p.pinDowned;
            int firstball = 0;
            int secondball = 0;
            bool firststrike = false;
            bool secondstrike = false;
            int gameCount = 0;
            int gamecount2 = 8;
            bool spare = false;

            var s = arr.Where(c => c > 10 || c < 0);

            if (s.Any()) throw new ArgumentOutOfRangeException("pinDowned", "all should be from  0 to 10");

            InitialiseGameComplete(GameList);

            ProcessGameScore(GameList, arr, ref firstball, ref secondball, ref firststrike, ref secondstrike, ref gameCount, ref gamecount2, ref spare);

            UpdateGameScore(GameList, resp);

            CheckIfGameIsCompleted(GameList, resp);

            return resp;
        }

        private static void ProcessGameScore(int[,] GameList, int[] arr, ref int firstball, ref int secondball, ref bool firststrike, ref bool secondstrike, ref int gameCount, ref int gamecount2, ref bool spare)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (gameCount > 8)
                {
                    gamecount2 += 1;
                }

                if (arr[i] < 10)
                {
                    if (firstball == 0)
                    {
                        if (secondstrike == true)
                        {
                            if (gamecount2 == 10)
                            {
                                GameList[gameCount - 1, 0] += arr[i];
                                GameList[gameCount - 1, 1] = 1;
                            }

                            if (gamecount2 == 11)
                            {
                                GameList[gameCount, 0] += arr[i];
                            }

                            if (gamecount2 < 10)
                            {
                                GameList[gameCount - 2, 0] += arr[i];
                                GameList[gameCount - 2, 1] = 1;
                                GameList[gameCount - 1, 0] += arr[i];
                            }
                        }

                        if (firststrike == true)
                        {
                            if (secondstrike == false)
                            {
                                GameList[gameCount - 1, 0] += arr[i];
                                GameList[gameCount - 1, 1] = 1;
                            }
                        }

                        firstball = arr[i];
                        GameList[gameCount, 0] += firstball;
                        if (i == 11)
                        {
                            GameList[gameCount, 1] = 1;
                        }

                        if (spare == true && gameCount != 9)
                        {
                            GameList[gameCount - 1, 0] += arr[i];
                            GameList[gameCount - 1, 1] = 1;
                        }
                    }
                    else
                    {
                        if (firstball + secondball == 10)
                        {
                            spare = true;
                            if (arr[i] < 10)
                            {
                                GameList[gameCount - 1, 0] += arr[i];
                                firstball = arr[i];
                                secondball = 0;
                                GameList[gameCount, 0] = arr[i];
                                GameList[gameCount - 1, 1] = 1; //openframe
                            }

                            if (gamecount2 > 9)
                            {
                                GameList[gameCount - 1, 0] += arr[i];
                            }
                        }
                        else
                        {
                            spare = false;
                            secondball = arr[i];

                            GameList[gameCount, 0] += secondball;

                            if (firstball + secondball != 10)
                            {
                                GameList[gameCount, 1] = 1; //openframe
                            }
                            else
                            {
                                spare = true;
                            }

                            if ((firststrike || secondstrike) || (firstball + secondball == 10 && gameCount == 9))
                            {
                                if (i != 11)
                                {
                                    if (gameCount > 0)
                                    {
                                        GameList[gameCount - 1, 0] += arr[i];
                                        GameList[gameCount - 1, 1] = 1;
                                    }

                                    firststrike = false;
                                    secondstrike = false;
                                }
                            }

                            if (gameCount < 9)
                                gameCount += 1;

                            if (gamecount2 == 11)
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
                        if (gamecount2 == 11)
                        {
                            GameList[gameCount, 0] += arr[i];
                            GameList[gameCount, 1] = 1;
                        }
                        else
                        {
                            GameList[gameCount, 0] = arr[i];
                            if (spare == true || firstball + secondball == 10)
                            {
                                GameList[gameCount - 1, 0] += arr[i];
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
                        if (secondstrike == false)
                        {
                            GameList[gameCount - 1, 0] += arr[i];
                            GameList[gameCount, 0] = arr[i];
                            gameCount += 1;

                            secondstrike = true;
                        }
                        else
                        {
                            if (gamecount2 < 10)
                            {
                                GameList[gameCount - 2, 0] += arr[i];
                                GameList[gameCount - 1, 0] += arr[i];
                                GameList[gameCount, 0] = arr[i];
                                GameList[gameCount - 2, 1] = 1;
                            }

                            if (gameCount < 9)
                            {
                                gameCount += 1;
                            }

                            if (gamecount2 == 10)
                            {
                                GameList[gameCount - 1, 0] += arr[i];
                                GameList[gameCount, 0] += arr[i];
                            }

                            if (gamecount2 == 11)
                            {
                                GameList[gameCount, 0] += arr[i];
                                GameList[gameCount - 1, 1] = 1;
                                GameList[gameCount, 1] = 1;
                            }
                        }
                    }
                }
            }
        }

        private static void InitialiseGameComplete(int[,] GameList)
        {
            for (int i = 0; i < GameList.GetLength(1); i++)
            {
                //all incomplete game as 0, completed as 1
                GameList[i, 1] = 0;
            }
        }

        private static void CheckIfGameIsCompleted(int[,] GameList, Response resp)
        {
            for (int i = 0; i < GameList.GetLength(0); i++)
            {
                if (GameList[i, 1] == 0)
                {
                    resp.gameCompleted = false;
                }
            }
        }

        private static void UpdateGameScore(int[,] GameList, Response resp)
        {
            int sum = 0;
            List<string> result = new List<string>();
            for (int i = 0; i < GameList.GetLength(0); i++)
            {
                if (GameList[i, 1] == 1)
                {
                    sum += GameList[i, 0];
                    result.Add(sum.ToString());
                }
                else
                {
                    if (GameList[i, 0] != 0)
                    {
                        result.Add("*");
                    }
                }
            }
            resp.frameProgressScores = result.ToArray();
        }
    }

    public class Response
    {
        public string[] frameProgressScores { get; set; }
        public bool gameCompleted { get; set; }

        public static implicit operator Response(ActionResult v)
        {
            throw new NotImplementedException();
        }
    }

    public class payload
    { 
        public int[] pinDowned { get; set; }

    }
  
}
