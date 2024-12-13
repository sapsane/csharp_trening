using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
     public class ContactData : IEquatable<ContactData>, IComparable<ContactData>   
    {

         private string firstname;
         private string lastname;
         private string id="";   
         public ContactData( string firstname, string lastname, string id) 
         {
            
            this.firstname = firstname; 
            this.lastname = lastname;
            this.id = id;
        }
         public string Firstname 
         {   
            get 
            {
                return firstname;
            }
            set
            {
                firstname=value;
            }
         }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }



        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
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
