using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestValidationDepth
{
    public class ShallowAPI
    {
        public ShallowAPI() { }

        public string GetResults(string strIn)
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }

            MidAPI mapi = new MidAPI();
            return mapi.GetResults(strIn);
        }


    }

    public class MidAPI
    {
        public MidAPI() { }

        public string GetResults(string strIn)
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }

            DeepAPI dapi = new DeepAPI();
            return dapi.GetResults(strIn);
        }
    }

    public class DeepAPI
    {
        public DeepAPI() { }

        public string GetResults(string strIn)
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }

            RemoteAPI rapi = new RemoteAPI();
            return rapi.GetResults(strIn);
        }
    }


    public class RemoteAPI
    {
        public RemoteAPI() { }

        public string GetResults(string strIn)
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 50) { }
            try
            {
                Guid g = Guid.Parse(strIn);
                return g.ToString();
            }
            catch (FormatException fe) { throw fe; }
        }
    }



    public class Good
    {
        public Good() { }

        public string GetGood()
        {
            return Guid.NewGuid().ToString();
        }
    }

    public class SmallBad
    {
        private string _val;
        public SmallBad() { }
        public string GetSmallInput()
        {
            _val = "";
            Int32 _max = (900000000 / 10000000);
            while (_val.Length < _max)
            {
                _val += "SmallBadInput";
            }
            return _val;
        }
    }

    public class MediumBad
    {
        private string _val;

        public MediumBad() { }

        public string GetMediumInput()
        {
            _val = "";
            Int32 _max = (900000000 / 100000);
            while (_val.Length < _max)
            {
                _val += "MediumBadInput";
            }
            return _val;
        }
    }

    public class LargeBad
    {
        private string _val;

        public LargeBad() { }

        public string GetLargeInput()
        {
            _val = "";
           Int32  _max = (900000000 / 1000);
            while (_val.Length < _max)
            {
                _val += "LargeBadInput";
            }
            return _val;
        }
    }




}
