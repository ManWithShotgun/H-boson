using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace H_boson
{
    abstract class AbstractBuilder
    {
        protected ObservedTheory observedTheory;

        public ObservedTheory getObservedTheory()
        {
            return observedTheory;
        }
        public void createObservedTheory()
        {
            observedTheory = new ObservedTheory();
        }

        /*
         Double code becouse NCos.cs and ZAce.cs colletions
         */
        protected List<NCos> NCosFromFile(StreamReader file)//useless double code
        {
            List<NCos> list = new List<NCos>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] arr = line.Split(' ');
                list.Add(new NCos(double.Parse(arr[1]), double.Parse(arr[0])));
            }
            file.Close();
            return list;
        }
        protected List<ZAce> ZAceFromFile(StreamReader file)//useless double code
        {
            List<ZAce> list = new List<ZAce>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] arr = line.Split(' ');
                list.Add(new ZAce(double.Parse(arr[0]), double.Parse(arr[1])));
            }
            file.Close();
            return list;
        }

        abstract public void buildGraphCos(Series series);
        abstract public void buildGraphACE(Series series);
        abstract public void buildGraphP(Series series);
    }
}
