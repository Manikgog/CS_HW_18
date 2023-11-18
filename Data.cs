using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_18
{
    public class Data
    {
        public string data {  get; set; }

        public Data() { }
        public Data(string data)
        {
            this.data=data;
        }

        public override string ToString()
        {
            return data;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(obj ==  this) 
            { 
                return true; 
            }
            Data other = obj as Data;
            if (other.data.Equals(data))
            {
                return true;
            }
            return false;
        }
    }
}
