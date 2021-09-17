using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowling
{
    class bowling
    {
        public void getResult()
        {
            List<int[]> GameList = new List<int[]>();
            //int[] arr = { 1, 9, 5, 4, 7, 0,10 };
            //int[] arr = { 10, 10, 5, 4, 7, 0, 10 };
            int[] arr = { 10, 10, 10, 4, 7, 0, 10 };
            int firstball = 0;
            int secondball = 0;
            bool firststrike = false;
            bool secondstrike = false;
            bool turkey = false;
            List<int> listTemp = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 10)
                {
                    firststrike = false;
                    secondstrike = false;
                    turkey = false;
                    if (firstball == 0)
                    {
                        List<int> smallgame = new List<int>();
                        firstball = arr[i];
                        smallgame.Add(firstball);
                        listTemp = smallgame;
                    }
                    else
                    {
                        if (firstball + secondball == 10)
                        {
                            if (arr[i] < 10)
                            {
                                List<int> lastitem = GameList[GameList.Count - 1].ToList();

                                lastitem.Add(arr[i]);

                                GameList[GameList.Count - 1] = lastitem.ToArray();

                                List<int> smallgame = new List<int>();
                                firstball = arr[i];
                                secondball = 0;
                                smallgame.Add(firstball);
                                listTemp = smallgame;
                            }
                            else
                            {
                                secondball = arr[i];
                                if (listTemp != null)
                                {
                                    listTemp.Add(secondball);
                                }

                                listTemp.ToArray();
                                GameList.Add(listTemp.ToArray());
                                if (firstball + secondball != 10)
                                {
                                    firstball = 0;
                                    secondball = 0;
                                }
                                listTemp.Clear();
                            }
                        }
                        else
                        {
                            secondball = arr[i];
                            if (listTemp != null)
                            {
                                listTemp.Add(secondball);
                            }

                            listTemp.ToArray();
                            GameList.Add(listTemp.ToArray());
                            if (firstball + secondball != 10)
                            {
                                firstball = 0;
                                secondball = 0;
                            }

                            listTemp.Clear();
                        }
                    }
                }
                else
                {
                    if (firststrike == false)
                    {
                        List<int> smallgame = new List<int>();
                        smallgame.Add(arr[i]);
                        GameList.Add(smallgame.ToArray());
                        firststrike = true;
                    }
                    else
                    {
                        if (secondstrike == false)
                        {
                            List<int> lastitem = GameList[GameList.Count - 1].ToList();

                            lastitem.Add(arr[i]);

                            GameList[GameList.Count - 1] = lastitem.ToArray();
                            secondstrike = true;

                            List<int> smallgame = new List<int>();
                            smallgame.Add(arr[i]);
                            GameList.Add(smallgame.ToArray());
                        }
                        else
                        {
                            if (turkey == false)
                            {
                                //add 10 to the first game
                                List<int> firststrikelst = GameList[GameList.Count - 2].ToList();

                                firststrikelst.Add(arr[i]);

                                GameList[GameList.Count - 2] = firststrikelst.ToArray();

                                //add 10 to the second game
                                List<int> secondstrikelist = GameList[GameList.Count - 1].ToList();

                                secondstrikelist.Add(arr[i]);

                                GameList[GameList.Count - 1] = secondstrikelist.ToArray();
                                turkey = true;

                                List<int> smallgame = new List<int>();
                                smallgame.Add(arr[i]);
                                GameList.Add(smallgame.ToArray());
                            }
                        }
                    }
                }
            }

            foreach (var item in GameList)
            {
                Console.WriteLine(item.Sum());
            }
        }
    }

    public class Response
    {
        public int[] frameProgressScores { get; set; }
        public bool gameCompleted { get; set; }

    }

    public class payload
    {
        public int[] pinDowned { get; set; }

    }
}
