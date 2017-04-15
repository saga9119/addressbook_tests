using System;
using System.Text.RegularExpressions;

namespace AddressbookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string title;
        private string company;
        private string address;
        private string home;
        private string mobile;
        private string work;
        private string fax;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string bday;
        private string bmonth;
        private string byear;
        private string aday;
        private string amonth;
        private string ayear;
        private string address2;
        private string phone2;
        private string notes;
        private string contactId;
        private string allEmails;
        private string allPhones;
        private string card;


        public ContactData(
            string firstname = "firstname",
            string middlename = "middlename",
            string lastname = "lastname",
            string nickname = "nickname",
            string title = "title",
            string company = "company",
            string address = "address",
            string home = "home",
            string mobile = "mobile",
            string work = "work",
            string fax = "fax",
            string email = "email",
            string email2 = "email2",
            string email3 = "email3",
            string homepage = "homepage",
            string bday = "1",
            string bmonth = "January",
            string byear = "1990",
            string aday = "1",
            string amonth = "January",
            string ayear = "1990",
            string address2 = "address2",
            string phone2 = "phone2",
            string notes = "notes",
            string contactId = ""

        )


        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.title = title;
            this.company = company;
            this.address = address;
            this.home = home;
            this.mobile = mobile;
            this.work = work;
            this.fax = fax;
            this.email = email;
            this.email2 = email2;
            this.email3 = email3;
            this.homepage = homepage;
            this.bday = bday;
            this.bmonth = bmonth;
            this.byear = byear;
            this.aday = aday;
            this.amonth = amonth;
            this.ayear = ayear;
            this.address2 = address2;
            this.phone2 = phone2;
            this.notes = notes;
            this.contactId = contactId;

        }

        public ContactData AutoFill()
        {
            long timestamp = System.Diagnostics.Stopwatch.GetTimestamp();
            this.Firstname = firstname + timestamp;
            this.Middlename = middlename + timestamp;
            this.Lastname = lastname + timestamp;
            this.Nickname = nickname + timestamp;
            this.Title = title + timestamp;
            this.Company = company + timestamp;
            this.Address = address + timestamp;
            this.Home = home + timestamp;
            this.Mobile = mobile + timestamp;
            this.Work = work + timestamp;
            this.Fax = fax + timestamp;
            this.Email = timestamp + email;
            this.Email2 = timestamp + email2;
            this.Email3 = timestamp + email3;
            this.Homepage = timestamp + homepage;
            this.Bday = bday;
            this.Bmonth = bmonth;
            this.Byear = byear;
            this.Aday = aday;
            this.Amonth = amonth;
            this.Ayear = ayear;
            this.Address2 = address2 + timestamp;
            this.Phone2 = phone2 + timestamp;
            this.Notes = notes + timestamp;
            this.ContactId = contactId;
            return this;
        }

        public string ContactId { get; set; }

        public string Firstname { get; set; }
        
        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string Homepage { get; set; }
        
        public string AllEmails
        {
            get
            {
                if (allEmails == null )
                {
                    return (Cleanup(Email) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }
                else
                {
                    return allEmails;
                }
            }

            set
            {
                allEmails = value;
            }
        }

        public string AllPhones {
            get
            {
                if (allPhones == null)
                {
                    return (Cleanup(Home) + Cleanup(Mobile) + Cleanup(Work) + Cleanup(Phone2)).Trim();
                }
                else
                {
                    return allPhones;
                }
            }

            set
            {
                allPhones = value;
            }
        }

        private string Cleanup(string str)
        {
            if (str == null || str == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(str, "[ -()]", "") + "\r\n";
            }

        }

        public string Card
        {
            get
            {
                if (card == null || card == "")
                {

                    return ((Firstname == "" ? "" : Firstname )
                        + (Middlename == "" ? "" : Middlename )
                        + (Lastname == "" ? "" :  Lastname)
                        + (Nickname == "" ? "" : Nickname )
                        + (Title == "" ? "" : Title)
                        
                        + (Company == "" ? "" :  Company)

                        + (Address == "" ? "" : Address)

                        + (Home == "" ? "" : "H: " + Home )

                        + (Mobile == "" ? "" : "M: " + Mobile)

                        + (Work == "" ? "" : "W: " + Work)

                        + (Fax == "" ? "" : "F: " + Fax )

                        + (Email == "" ? "" : Email )

                        + (Email2 == "" ? "": Email2 )

                        + (Email3 == "" ? "" : Email3)

                        + (Homepage == "" ? "" : "Homepage:\r\n" + Homepage )

                        + (Address2 =="" ? "" : Address2 )

                        + (Phone2 == "" ? "" : "P: " + Phone2)
                        
                        + (Notes == "" ? "" : Notes)).Replace("\r\n", "").Replace(" ", "");
                }
                else
                {
                    return card;
                }
            }

            set
            {
                card = value;
            }
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (ContactId == other.ContactId) && (Lastname == other.Lastname)
                && (Firstname == other.Firstname);
        }

        public override int GetHashCode()
        {
            return ContactId.GetHashCode();
        }

        public override string ToString()
        {
            return "id=" + ContactId + ", lastname=" + Lastname + ", firstname=" + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return ToString().CompareTo(other.ToString());
        }
    }
}
