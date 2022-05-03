using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat_Bolnica_Zdravo.CrudModel
{
    public class Medicine
    {

        public Medicine (string name,string amount,string frequency)
        {
            this.name = name;
            this.frequency = frequency;
            this.amount = amount;
        }
        public Medicine(string name,List<string> content)
        {
            this.name = name;
            this.content = content;
            this.allComponents = "";
            int i = 0;
            foreach(string s in content)
            {
                if(content.Count > i + 1)
                this.allComponents += s + ",";
                else
                {
                    this.allComponents += s;
                }
                i++;
            }
        }
        public string name
        {
            set;
            get;
        }

        public string amount
        {
            set;
            get;
        }

        public string frequency
        {
            set;
            get;
        }
        public List<string> content
        {
            set;
            get;
        }

        public string allComponents
        {
            set;
            get;
        }

    }
}
