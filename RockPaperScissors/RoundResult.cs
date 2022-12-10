using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{

    public class RoundResult
    {
        public RPSChoice MyChoice { get; set; }
        public RPSChoice OpponentChoice { get; set; }
        public RPSResult Result { get; set; }

        public RPSChoice DetermineMyChoice()
        {
            int a = (int) OpponentChoice + (int) Result;

            if (a == 4) a = 1;
            if (a == 0) a = 3;

            MyChoice = (RPSChoice) a;

            return MyChoice;
        }

        public RPSResult DetermineResult()
        {
            int a = MyChoice - OpponentChoice;

            if (Math.Abs(a) > 1)
            {
                a /= -2;
            }

            Result = (RPSResult) a;

            return Result;
        }

        public int CalculateScore()
        {
            return 3 + ((int) Result * 3) + (int) MyChoice;
        }
    }
}
