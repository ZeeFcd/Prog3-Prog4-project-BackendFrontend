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
        public RestCollection<Husband> Husbands { get; set; }
        public RestCollection<Wife> Wives { get; set; }
        public RestCollection<Wedding> Weddings { get; set; }

        private Husband selectedHusband;
        
        public Husband SelectedHusband
        {
            get { return selectedHusband; }
            set {

                if (SelectedWedding != null)
                {
                    SelectedWedding = null;

                }
                if (SelectedWife != null)
                {
                    SelectedWife = null;

                }
                SetProperty(ref selectedHusband, value);


                //(UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
                //(DeleteCommand as RelayCommand).NotifyCanExecuteChanged();

            }
        }

        private Wife selectedWife;

        public Wife SelectedWife
        {
            get { return selectedWife; }
            set
            {
                if (SelectedWedding != null)
                {
                    SelectedWedding = null;


                }
                if (SelectedHusband != null)
                {
                    SelectedHusband = null;

                }
                SetProperty(ref selectedWife, value);
                

                //(UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
                //(DeleteCommand as RelayCommand).NotifyCanExecuteChanged();

            }
        }
        private Wedding selectedWedding;
       

        public Wedding SelectedWedding
        {
            get { return selectedWedding; }
            set
            {
                if (SelectedHusband != null)
                {
                    SelectedHusband = null;


                }
                if (SelectedWife != null)
                {
                    SelectedWife = null;

                }
                SetProperty(ref selectedWedding, value);
                

                //(UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
                //(DeleteCommand as RelayCommand).NotifyCanExecuteChanged();

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

            //CreateCommand = new RelayCommand(() =>
            //{
            //    Actors.Add(new Actor()
            //    {
            //        ActorName = SelectedActor.ActorName
            //    });
            //});
            //UpdateCommand = new RelayCommand(() =>
            //{
            //    try
            //    {
            //        Actors.Update(SelectedActor);
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        ErrorMessage = ex.Message;
            //    }

            //});

            //DeleteCommand = new RelayCommand(() =>
            //{
            //    Actors.Delete(SelectedActor.ActorId);
            //},
            //() =>
            //{
            //    return SelectedActor != null;
            //});
            //SelectedActor = new Actor();


        }
    }
}
