using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nolik8
{
    public  enum PlayerType { Zero, Cross} ;
    public enum GameResult { Zero, Cross, Draw, Undefined };


    public class TicTacToeEngine
    {
        int[] ArrayOfValues={1,1,1,0,0,0,0,0,0};
        

        public  TicTacToeEngine(string position)
        {
            ArrayOfValues = ConvertStringPosition(position);
            Position = position;
        }

        public string Position { get; set; }


        public  int[] GetBestMove(PlayerType playerType) 
        {
            
            var cases = new int[,] {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 }
            };

            int[] Arr = { -1, -1, -1, -1 };
            int[] Corner={0,2,6,8};

            for (var a = 0; a < 2; a++)
            {
                for (var i = 0; i <= cases.GetUpperBound(0); i++)
                {

                    var sum =
                        ArrayOfValues[cases[i, 0]] +
                        ArrayOfValues[cases[i, 1]] +
                        ArrayOfValues[cases[i, 2]];
                    //////сочетания по два - поставить третий
                    if (((sum == 2) && (a == 0)) ^ ((sum == -2) && (a == 1) && (Arr[0] == -1)))
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            if ((ArrayOfValues[cases[i, j]] == 0) && (Arr[0] == -1))
                                Arr[0] = cases[i, j];
                            else if ((ArrayOfValues[cases[i, j]] == 0) && (Arr[1] == -1))
                                Arr[1] = cases[i, j];

                        }

                    }
                    /////занять центр
                    else if (ArrayOfValues[4] == 0)
                        Arr[0] = 4;
                   
                    ///вилки
                    ///помешать ноликам
                    else if ((sum == -1) && (ArrayOfValues[4] == -1) && ((i == 7) || (i == 6)))
                    {
                        for (var b = 0; b < 4; b++)
                        {
                            if (ArrayOfValues[Corner[b]] == 0)
                            {
                                Arr[b] = Corner[b];
                            }
                        }
                    }
                        //поставить свою
                    else if (((sum == 1) && (ArrayOfValues[4] == 1)) && ((i == 6)||(i==7)))   
                    {
                        for (var k = 0; k < 9; k++)
                        {
                            var g = 0;
                           
                             if (ArrayOfValues[k] == 0)
                            {
                                ArrayOfValues[k] = 1;
                                for (var l = 0; l < 8; l++)
                                {
                                    
                                    var sum1 =
                                ArrayOfValues[cases[l, 0]] +
                                ArrayOfValues[cases[l, 1]] +
                                ArrayOfValues[cases[l, 2]];
                                      if (sum1==2)
                                    {
                                        g++;
                                        if ((g == 2)&&(Arr[0]==-1))
                                            Arr[0] = k;
                                          else if ((g == 2)&&(Arr[1]==-1))
                                            Arr[1] = k;
                                    }
                                   
                                }
                                ArrayOfValues[k] = 0;
                            }
                        }
                    }
                        //поставить два в ряд
                    else if ((sum==1)&&((ArrayOfValues[cases[i,0]]==0)||(ArrayOfValues[cases[i,1]]==0)||(ArrayOfValues[cases[i,2]]==0)))
                    {
                        for (var j=0; j<3; j++)
                        {
                            if (ArrayOfValues[cases[i, j]] == 0)
                                Arr[j] = cases[i, j];
                           
                        }
                    }
                }
                //if (Arr[0]==-1)

                //{

                //}
            }
            return Arr;
        }

        public static int[] ConvertStringPosition(string position) {
         

            return position
                    .Select(x => (x == '0') ? -1 : (x == 'X') ? 1 : 0)
                    .ToArray ();

        }

        public GameResult GetGameResult() {
            var cases = new int[,] {
                { 0, 1, 2 },
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 0, 3, 6 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 0, 4, 8 },
                { 2, 4, 6 }
            };
           
            

                for (var i = 0; i <= cases.GetUpperBound(0); i++)
                {
                    var sum =
                        ArrayOfValues[cases[i, 0]] +
                        ArrayOfValues[cases[i, 1]] +
                        ArrayOfValues[cases[i, 2]];

                    if (sum == 3) return GameResult.Cross;
                    if (sum == -3) return GameResult.Zero;
                }
                for (var i = 0; i < ArrayOfValues.Length; i++)
                {
                    if (ArrayOfValues[i] == 0)
                        return GameResult.Undefined;
                }
                

            return GameResult.Draw;
        }
        

    }
}
