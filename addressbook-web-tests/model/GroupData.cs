namespace AddressbookWebTests
{
    public class GroupData
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
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            this.name = name + timestamp;
            this.header = header + timestamp;
            this.footer = footer + timestamp;
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
