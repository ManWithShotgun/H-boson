﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace H_boson
{
    class Fqq075Builder: AbstractBuilder
    {
        public override void buildGraphCos(Series series)
        {
            string filePathCos = @"spin-2-2new.txt";
            List<NCos> listCos = this.NCosFromFile(new StreamReader(filePathCos));
            observedTheory.ListCos = listCos;
            observedTheory.Graphs.Add(new GraphCos(series, listCos));
        }
        public override void buildGraphACE(Series series)
        {
            observedTheory.Graphs.Add(new GraphACE());
        }
        public override void buildGraphP(Series series)
        {
            observedTheory.Graphs.Add(new GraphP());
        }
    }
}
