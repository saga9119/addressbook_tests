using System;

namespace AddressbookWebTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string header;
        private string footer;
        private string parentGroupName;
        private string groupId;

        public GroupData( 
            string name = "",
            string header = "",
            string footer = "",
            string parentGroupName = "[none]",
            string groupId = null

            )
        {
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            this.name = name + timestamp;
            this.header = header + timestamp;
            this.footer = footer + timestamp;
            this.parentGroupName = parentGroupName;
            this.groupId = groupId;

        }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string ParentGroupName { get; set; }

        public string GroupId { get; set; }

        public bool Equals(GroupData other)
        {
            if(object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Name == other.Name) && (GroupId == other.GroupId);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    
        public override string ToString()
        {
            return "\nName=" + Name 
                + "\nHeader="+ Header 
                + "\nFooter=" + Footer 
                + "\nParentGroupName=" + ParentGroupName 
                + "\nId=" + GroupId;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ToString().CompareTo(other.ToString());
        }
    }
}
