using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class randomnum
    {
        public string lob()
        {
            Random rn = new Random();
            int[] box = new int[6];

            string x = "";
            for (int i = 0; i < 6; i++)
            {
                box[i] = rn.Next(1, 50);
                for (int j = 0; j < 6; j++)
                {
                    if (box[j] == box[i])
                    {

                        box[i] = rn.Next(1, 50);
                    }
                }
            }
            foreach (int i in box)
            {
                x += i.ToString()+",";

            }
               
            return x;
        }
    }
}