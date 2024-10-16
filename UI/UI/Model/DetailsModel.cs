using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class DetailsModel:INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;
         private void OnPropertyChanged(string propertyName) 
         {
            if (PropertyChanged != null) 
            {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        
         }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged("FirstName"); }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged("LastName"); }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string company_name;

        public string Company_Name
        {
            get { return company_name; }
            set { company_name = value; OnPropertyChanged("Company_Name"); }
        }
        private int phone_no;

        public int Phone_No
        {
            get { return phone_no; }
            set { phone_no = value; OnPropertyChanged("Phone_No"); }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }



    }
}
