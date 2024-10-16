using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Command;
using UI.Model;

namespace UI.ViewModel
{
    public class DetailViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        DetailService DetailService;
        public DetailViewModel()
        {
            DetailService = new DetailService();
            saveCommand = new RelayCommand(Save);
            currentEmployee = new DetailsModel();
     
        }
        private DetailsModel currentEmployee;

        public DetailsModel CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
               
                var IsSaved = DetailService.Add(CurrentEmployee);
               
                if (IsSaved)
                    Message = "Employee Saved";
                else
                    Message = "Save Operation Failed";

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
