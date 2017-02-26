using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTests
{
    class GroupData
    {
        private string name;
        private string header;
        private string footer;
        private string parentGroupName;

        public GroupData(
            string name = "", 
            string header = "", 
            string footer = "", 
            string parentGroupName = "[none]"
            )
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
            this.parentGroupName = parentGroupName;

        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }

            set
            {
                footer = value;
            }
        }

        public string ParentGroupName
        {
            get
            {
                return parentGroupName;
            }

            set
            {
                parentGroupName = value;
            }
        }
    }
}
