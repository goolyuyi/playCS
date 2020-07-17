using System;

namespace playCS
{
    public class PlayLambda
    {
        delegate int DeleFunc(int x);
        public PlayLambda()
        {
            DeleFunc deleFuncNLambda = (int x) =>
            {
                for (var i = 0; i < 10; i++, x += i) ;
                return x + 1;
            };

            Console.WriteLine("{0},{1:N}",deleFuncNLambda,deleFuncNLambda(5));
        }
    }
}