using IJA9WQ_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IJA9WQ_SZTGUI_2021222.WpfClient
{
    public class MainWindowViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Husband> Husbands { get; set; }
        public RestCollection<Wife> Wives { get; set; }
        public RestCollection<Wedding> Weddings { get; set; }

        private Husband selectedHusband;
        
        public Husband SelectedHusband
        {
            get { return selectedHusband; }
            set {

                if (value != null)
                {
                    selectedHusband = new Husband()
                    {
                        Id=value.Id,
                        Name = value.Name,
                        Age = value.Age,
                        WifeID=value.WifeID
                    };
                    OnPropertyChanged();
                    (DeleteHusbandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
               
            }
        }

        private Wife selectedWife;

        public Wife SelectedWife
        {
            get { return selectedWife; }
            set
            {
                if (value != null)
                {
                    selectedWife = new Wife()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Age = value.Age
                        
                    };
                    OnPropertyChanged();
                    (DeleteWifeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        private Wedding selectedWedding;
       
        public Wedding SelectedWedding
        {
            get { return selectedWedding; }
            set
            {
                if (value != null)
                {
                    selectedWedding = new Wedding()
                    {
                        Id = value.Id,
                        Place = value.Place,
                        Price = value.Price,
                        HusbandID = value.HusbandID,
                        WifeID = value.WifeID

                    };
                    OnPropertyChanged();
                    (DeleteWifeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateHusbandCommand { get; set; }
        public ICommand UpdateHusbandCommand { get; set; }
        public ICommand CreateWifeCommand { get; set; }
        public ICommand UpdateWifeCommand { get; set; }
        public ICommand CreateWeddingCommand { get; set; }
        public ICommand UpdateWeddingCommand { get; set; }
        public ICommand DeleteHusbandCommand { get; set; }
        public ICommand DeleteWifeCommand { get; set; }
        public ICommand DeleteWeddingCommand { get; set; }

        public MainWindowViewModel()
        {
            Husbands = new RestCollection<Husband>("http://localhost:18885/", "husband");
            Wives = new RestCollection<Wife>("http://localhost:18885/", "wife");
            Weddings = new RestCollection<Wedding>("http://localhost:18885/", "wedding");

            CreateHusbandCommand = new RelayCommand(() =>
            {
               
                try
                {
                    Husbands.Add(new Husband()
                    {
                        Name = SelectedHusband.Name,
                        Age = SelectedHusband.Age,
                        WifeID = SelectedHusband.WifeID
                    });
                }
                catch (ArgumentException ex)
                {
                    
                    ErrorMessage = ex.Message;
                }

            });
            CreateWifeCommand = new RelayCommand(() =>
            {
               
                try
                {
                    Wives.Add(new Wife()
                    {
                        Name = SelectedWife.Name,
                        Age = SelectedWife.Age
                    });
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }



            });
            CreateWeddingCommand = new RelayCommand(() =>
            {
                try
                {
                    Weddings.Add(new Wedding()
                    {
                        Place = SelectedWedding.Place,
                        Price = SelectedWedding.Price,
                        HusbandID = SelectedWedding.HusbandID,
                        WifeID = SelectedHusband.WifeID
                    });
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
                

            });

            UpdateHusbandCommand = new RelayCommand(() =>
            {
                try
                {
                    Husbands.Update(SelectedHusband);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }

            });

            UpdateWifeCommand = new RelayCommand(() =>
            {
                try
                {
                    Wives.Update(SelectedWife);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }

            });

            UpdateWeddingCommand = new RelayCommand(() =>
            {
                try
                {
                    Weddings.Update(SelectedWedding);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }

            });

            DeleteHusbandCommand = new RelayCommand(() =>
            {
                try
                {
                    Husbands.Delete(SelectedHusband.Id);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            },
            () =>
            {
                return SelectedHusband != null;
            });

            DeleteWeddingCommand = new RelayCommand(() =>
            {
                try
                {
                    Weddings.Delete(SelectedWedding.Id);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            },
            () =>
            {
                return SelectedWedding != null;
            });

            DeleteWifeCommand = new RelayCommand(() =>
            {
                try
                {
                    Wives.Delete(SelectedWife.Id);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            },
            () =>
            {
                return SelectedWife != null;
            });

            SelectedHusband = new Husband();
            SelectedWedding = new Wedding();
            SelectedWife = new Wife();
        }
    }
}
