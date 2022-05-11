using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CifraturaDiPolibio.Models
{
    public class Polibio
    {
        public string[,] map { get; set; }
        public char skip { get; set; }
        public int[] DoubleCharCoords { get; set; }


        public Polibio()
        {
            map = new string[5, 5];
        }

        private void CreateBaseMapWithAlphabet(char charToMerge)
        {
            int[] coord = { 4, 2 };
            DoubleCharCoords = coord;
            char tmp = 'a';
            skip = charToMerge;
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if(tmp == charToMerge)
                    {
                        map[i, j] = tmp + "," + (Convert.ToChar(tmp + 1));
                        tmp++;
                        tmp++;
                    }
                    else
                    {
                        map[i, j] = tmp + "";
                        tmp++;
                    }
                         
                }
            }
        }

        private void CreateCustomMap(string[] pattern)
        {
            for (int i = 0,k=0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = pattern[k];
                    k++;
                }
            }
        }

        private string[] ConvertMatrixToArray(string[,] strMatr)
        {
            string[] arr = new string[strMatr.GetLength(0) * strMatr.GetLength(1)];
            for (int i = 0, k = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    arr[k] = strMatr[i, j];
                    k++;
                }
            }
            return arr;
        }

        public string[,] GetMap(char charToMerge)
        {
            CreateBaseMapWithAlphabet(charToMerge);
            return map;
        }

        public void UpdateMap(string[,] map)
        {
            CreateCustomMap(ConvertMatrixToArray(map));
        }

        public string Encode(string text)
        {
            string res = "";
            for(int i = 0; i < text.Length; i++)
            {
                for(int j = 0; j < map.GetLength(0); j++)
                {
                    for(int k = 0; k < map.GetLength(1); k++)
                    {
                        if(text[i] + "" == map[j, k])
                        {
                            res += (j+1) + "" + (k+1) + " ";
                        }

                        if(text[i] == skip || text[i] == skip+1)
                        {
                            res += DoubleCharCoords[0] + "" + DoubleCharCoords[1] + " ";
                            j = map.GetLength(0);
                            
                            break;
                        }
                    }
                }
            }
            return res;
        }
    }
}
