using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class TrafficLight
    {
        public ITrafficLight State { get; set; }

        public void Change()
        {
            State.Change(this);
        }

        public void ReportState()
        {
            State.ReportState();
        }
    }

    public interface ITrafficLight
    {
        void Change(TrafficLight light);
        void ReportState();
    }

    public class RedLight : ITrafficLight
    {
        public void Change(TrafficLight light)
        {
            light.State = new GreenLight();
        }

        public void ReportState()
        {
            Console.WriteLine("Red");
        }
    }

    public class YellowLight : ITrafficLight
    {
        public void Change(TrafficLight light)
        {
            light.State = new GreenLight();
        }

        public void ReportState()
        {
            Console.WriteLine("Yellow");
        }
    }

    public class GreenLight : ITrafficLight
    {
        public void Change(TrafficLight light)
        {
            light.State = new YellowLight();
        }

        public void ReportState()
        {
            Console.WriteLine("Green");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TrafficLight trafficLight = new TrafficLight();
            trafficLight.State = new RedLight();
            trafficLight.ReportState();

            while (true)
            {
                trafficLight.Change();
                trafficLight.ReportState();
                Console.ReadKey();
            }
        }
    }
}
