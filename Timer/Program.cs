//1. Создайте программу секундомер.Требуется выводить показания секундомера в консоле.Консоль должна уметь "отслеживать" кнопки запуска, останова 
//и сброса секундомера.
using System;
using System.Threading;

namespace Timer
{
    class Program
    {
        delegate void buttonHandler();
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            Console.WriteLine(@"Menu
1 Start
2 Pause
3 Reset
4 Clear
0 Exit");
            buttonHandler buttonHandlerStart = delegate () { timer.Start(); };
            buttonHandlerStart += delegate () { timer.Time(); };
            buttonHandler buttonHandlerPause = delegate () { timer.Stop(); };
            buttonHandlerPause += delegate () { timer.Time(); };
          
            Console.WriteLine();
            while (true)
            {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1": buttonHandlerStart.Invoke();
                        break;
                    case "2": buttonHandlerPause.Invoke();
                        break;
                    default: return;
                }
            }

        }
    }
    class Timer
    {
        DateTime time;
        bool timerIsStarted = false;

        public void Start()
        {
               timerIsStarted = true;
               Tick();
        }
        public void Tick()
        {
            while (timerIsStarted == true)
            {
                time = time.AddSeconds(1);
                
                Time();
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            timerIsStarted = false;
        }
        public  void Time()
        {
            int second, minute;
            second = time.Second;
            minute = time.Minute;
            Console.SetCursorPosition(0, Console.CursorTop);
            if(second>9 && minute>9)
            Console.Write(minute + ":" + second);
            else if (second > 9 && minute < 9)
                Console.Write("0"+ minute + ":" + second);
            else
                Console.Write("0" + minute + ":0" + second);
            // Console.Clear();
        }
    }
}
