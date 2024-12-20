using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
     public class ContactData : IEquatable<ContactData>, IComparable<ContactData>   
    {
        private string allPhones;
        private string allEmails;

        //  private string firstname;
        //  private string lastname;
        //  private string id="";   
        public ContactData( string firstname, string lastname, string id) 
         {

            Firstname = firstname;
            Lastname = lastname;
            Id = id;
        }

         public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string Id { get; set; }

        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string AllPhones 
        {
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else 
                {
                return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }

            }
            set 
            {
                allPhones = value;
            }
        }

        public string AllEmails 
        {   
            get 
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else 
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3) ).Trim();
                }
            }
            

            set 
            {
                allEmails = value;
            } 
        }






        private string CleanUp(string phone)
        {
            if (phone == null || phone == "") 
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";


        }

        



        public bool Equals(ContactData other) 
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }


            return Firstname == other.Firstname && Lastname==other.Lastname;
        }

        public override int GetHashCode()
        {
            int result = Firstname.GetHashCode() + Lastname.GetHashCode();
            return result;
        }


        public override string ToString()
        {
            return "Firsrname=" + Firstname + "   Lastname=" + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                if (Firstname.CompareTo(other.Firstname) == 0) 
                {
                    return 0;
                }

                if (Firstname.CompareTo(other.Firstname) == 1) 
                {
                    return 1;
                }
                if (Firstname.CompareTo(other.Firstname) == -1)
                {
                    return -1;
                }

            }


            return Lastname.CompareTo(other.Lastname);  

        }



    }
}
