using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5
{
    class MyProcess
    {
        private readonly string _nameOfProcess;
        private readonly long _idOfProcess;
        private bool _isProcessActive;
        private double _CPUOfProcess;
        private double _RAMamount;
        private int _quantityOfThreads;
        private string _nameOfOwner;
        private string _nameAndPathToTheFile;
        static object locker = new object();

        MyProcess(Process proc)
        {
            _nameOfProcess = proc.ProcessName;
            _idOfProcess = proc.Id;
            //_isProcessActive = proc.;
            _CPUOfProcess = CountCPU();
            _RAMamount = proc.WorkingSet64; //PrivateMemorySize64
            _quantityOfThreads = proc.Threads.Count;
            _nameOfOwner = Environment.UserName;
            _nameAndPathToTheFile = proc.MainModule.FileName;

        }
        internal string NameOfProcess
        {
            get { return _nameOfProcess; }
        }

        internal long IdOfProcess
        {
            get { return _idOfProcess; }
        }

        internal bool IsProcessActive
        {
            get { return _isProcessActive; }
        }

        internal double CPUOfProcess
        {
            get { return _CPUOfProcess; }
        }

        internal double RAMamount
        {
            get { return _RAMamount ; }
        }

        internal int QuantityOfThreads
        {
            get { return _quantityOfThreads; }

        }

        internal string NameOfOwner
        {
            get { return _nameOfOwner; }
        }

        internal string NameAndPathToTheFile
        {
            get { return _nameAndPathToTheFile; }
        }

        private double CountCPU()
        {
            var counter = new PerformanceCounter("Process", "% Processor Time", _nameOfProcess);

            return counter.NextValue();
        }

        
    }
}
