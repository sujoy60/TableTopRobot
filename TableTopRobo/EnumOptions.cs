using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopRobo
{

         public enum Instructions 
         {
            Invalid =0
            ,Place =1
            ,Move = 2
            ,Left = 3
            ,Right =4
            ,Report = 5
            ,
         }

        public enum Facing
        {
             North = 1
           , South = 2
           , East = 3
           , West = 4
           ,
        }

        public enum Direction
        {
            Left = 1
            ,Right =2
            ,   
        }


}
