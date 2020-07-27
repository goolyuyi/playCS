using System;

namespace playCS
{
    class Counter
    {
        //NOTE why this event keyword is necessary?
        //https://stackoverflow.com/questions/3028724/why-do-we-need-the-event-keyword-while-defining-events
        //NOTE EventHandler/EventHandler<T> is just a delegate
        //public delegate void EventHandler(object? sender, EventArgs e);
        //public delegate void EventHandler<TEventArgs>(object? sender, TEventArgs e);
        //NOTE reached aka. EventHandler 不能访问注册的事件,要访问用EventHandlerList 类
        public event EventHandler Reached;
        public event EventHandler<Counter> GHandler;


        public void Happen()
        {
            //NOTE check null here in case of no listener's situation... 
            //NOTE every arg should extend from EventArgs
            Reached?.Invoke(this, null!);
            var ms = Reached.GetType().GetMembers();
        }

        private void OnGHandler(Counter e)
        {
            GHandler?.Invoke(this, e);
        }
    }

    public static class PlayEvent
    {
        private static void Basic()
        {
            var c = new Counter();

            c.Reached += (object sender, EventArgs args) => { Console.WriteLine("happen"); };
            //NOTE -= to remove

            c.Happen();
        }

        public static void Play()
        {
            Basic();
        }
    }
}