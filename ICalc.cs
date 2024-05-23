using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    public interface ICalc
    {
        double Result { get; set; }
        void Sum(int x);
        void Subtract (int x);
        void Divide (int x);
        void Multiply (int x);
        void CancelLast ();

        event EventHandler<EventArgs> MyEventHandler;
    }
}
