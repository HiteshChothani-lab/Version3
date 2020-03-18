using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UserManagement.Common.Constants;
using UserManagement.Common.Enums;
using UserManagement.Entity;
using UserManagement.Manager;
using UserManagement.UI.Events;
using UserManagement.UI.ItemModels;

namespace UserManagement.UI.ViewModels
{
    public class EditButtonsPopupPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowsManager _windowsManager;

        public EditButtonsPopupPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IWindowsManager windowsManager) : base(regionManager)
        {
            _eventAggregator = eventAggregator;
            _windowsManager = windowsManager;

            this.ButtonABCheckedCommand = new DelegateCommand<string>((parameter) => ExecuteButtonABCheckedCommand(parameter));
            this.CancelCommand = new DelegateCommand(() => ExecuteCancelCommand());
            this.SubmitCommand = new DelegateCommand(async () => await ExecuteSubmitCommand());
        }

        public DelegateCommand<string> ButtonABCheckedCommand { get; private set; }

        private StoreUserEntity _selectedStoreUser;
        public StoreUserEntity SelectedStoreUser
        {
            get => _selectedStoreUser;
            set => SetProperty(ref _selectedStoreUser, value);
        }

        private bool IsSelectedStoreUser = false;
        
        private bool _isUserTypeMobile = true;
        public bool IsUserTypeMobile
        {
            get => _isUserTypeMobile;
            set => SetProperty(ref _isUserTypeMobile, value);
        }

        private bool _isUserTypeNonMobile;
        public bool IsUserTypeNonMobile
        {
            get => _isUserTypeNonMobile;
            set => SetProperty(ref _isUserTypeNonMobile, value);
        }

        private bool _isCheckedIAmFulfilled;
        public bool IsCheckedIAmFulfilled
        {
            get => _isCheckedIAmFulfilled;
            set => SetProperty(ref _isCheckedIAmFulfilled, value);
        }

        private bool _isCheckedINeedHelp;
        public bool IsCheckedINeedHelp
        {
            get => _isCheckedINeedHelp;
            set => SetProperty(ref _isCheckedINeedHelp, value);
        }

        private bool _isCheckedButtonA;
        public bool IsCheckedButtonA
        {
            get => _isCheckedButtonA;
            set => SetProperty(ref _isCheckedButtonA, value);
        }

        private bool _isCheckedButtonB;
        public bool IsCheckedButtonB
        {
            get => _isCheckedButtonB;
            set => SetProperty(ref _isCheckedButtonB, value);
        }

        private bool _isCheckedButtonC;
        public bool IsCheckedButtonC
        {
            get => _isCheckedButtonC;
            set => SetProperty(ref _isCheckedButtonC, value);
        }

        private string _note = string.Empty;
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        private int _noteColorSelectedIndex = 0;
        public int NoteColorSelectedIndex
        {
            get => _noteColorSelectedIndex;
            set => SetProperty(ref _noteColorSelectedIndex, value);
        }

        private ComboBoxItem _noteColor;
        public ComboBoxItem NoteColor
        {
            get => _noteColor;
            set { SetProperty(ref _noteColor, value); }
        }

        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand SubmitCommand { get; private set; }

        private void ExecuteCancelCommand()
        {
            this.RegionNavigationService.Journal.Clear();
            _eventAggregator.GetEvent<EditButtonsSubmitEvent>().Publish(null);
            SetUnsetProperties();
        }

        private async Task ExecuteSubmitCommand()
        {
            if (string.IsNullOrWhiteSpace(this.Note))
            {
                MessageBox.Show("Please select color and enter description in color textbox.", "Required.");
                return;
            }

            if (!this.IsCheckedButtonA && !this.IsCheckedButtonB && !this.IsCheckedButtonC)
            {
                MessageBox.Show("You must make a selection for BUTTLON A or BUTTON B or BUTTON C or all.", "Required.");
                return;
            }

            if (!this.IsCheckedINeedHelp && !this.IsCheckedIAmFulfilled)
            {
                MessageBox.Show("You must make a selection for I need help or I am fulfilled.", "Required.");
                return;
            }
            var reqEntity = new UpdateButtonsRequestEntity
            {
                Id = this.SelectedStoreUser.Id,
                UserId = Convert.ToInt32(this.SelectedStoreUser.UserId),
                SuperMasterId = Config.MasterStore.UserId,
                Note = this.Note,
                NoteColor = this.NoteColor.Name,
                Action = this.IsSelectedStoreUser ? "update_buttons" : "update_buttons_archive"
            };

            if (this.IsCheckedButtonA)
            {
                reqEntity.Button1 = "Button A";
            }

            if (this.IsCheckedButtonB)
            {
                reqEntity.Button2 = "Button B";
            }

            if (this.IsCheckedButtonC)
            {
                reqEntity.Button3 = "Button C";
            }

            if (this.IsCheckedINeedHelp)
            {
                reqEntity.ButtonAB = "I need help";
            }
            else if (this.IsCheckedIAmFulfilled)
            {
                reqEntity.ButtonAB = "I am fulfilled";
            }
            
            var result = await _windowsManager.UpdateButtons(reqEntity);

            if (result.StatusCode == (int)GenericStatusValue.Success)
            {
                if (Convert.ToBoolean(result.Status))
                {
                    this.RegionNavigationService.Journal.Clear();
                    _eventAggregator.GetEvent<EditButtonsSubmitEvent>().Publish(new EditButtonsItemModel());
                    SetUnsetProperties();
                }
                else
                {
                    MessageBox.Show(result.Messagee, "Unsuccessful");
                }
            }
            else if (result.StatusCode == (int)GenericStatusValue.NoInternetConnection)
            {
                MessageBox.Show(MessageBoxMessage.NoInternetConnection, "Unsuccessful");
            }
            else if (result.StatusCode == (int)GenericStatusValue.HasErrorMessage)
            {
                MessageBox.Show(result.Message, "Unsuccessful");
            }
            else
            {
                MessageBox.Show(MessageBoxMessage.UnknownErorr, "Unsuccessful");
            }
        }

        private void ExecuteButtonABCheckedCommand(string parameter)
        {
            if (parameter == "1")
            {
                this.IsCheckedINeedHelp = true;
                this.IsCheckedIAmFulfilled = false;
            }
            else if (parameter == "2")
            {
                this.IsCheckedINeedHelp = false;
                this.IsCheckedIAmFulfilled = true;
            }
            else
            {
                this.IsCheckedINeedHelp = false;
                this.IsCheckedIAmFulfilled = false;
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            SetUnsetProperties();

            if (navigationContext.Parameters[NavigationConstants.SelectedStoreUser] is StoreUserEntity selectedStoreUser)
            {
                SelectedStoreUser = selectedStoreUser;
            }

            if (navigationContext.Parameters[NavigationConstants.IsSelectedStoreUser] is bool isSelectedStoreUser)
            {
                IsSelectedStoreUser = isSelectedStoreUser;
            }

            this.Note = SelectedStoreUser.Note;

            this.IsCheckedButtonA = !string.IsNullOrWhiteSpace(SelectedStoreUser.Btn1);
            this.IsCheckedButtonB = !string.IsNullOrWhiteSpace(SelectedStoreUser.Btn2);
            this.IsCheckedButtonC = !string.IsNullOrWhiteSpace(SelectedStoreUser.Btn3);

            this.IsCheckedINeedHelp = "I need help".Equals(SelectedStoreUser.BtnAB);
            this.IsCheckedIAmFulfilled = !this.IsCheckedINeedHelp;

            UpdateColorBox(SelectedStoreUser.NoteColor);
        }

        private void SetUnsetProperties()
        {
            this.Note = string.Empty;
            this.NoteColorSelectedIndex = 0;
            this.IsCheckedButtonA = this.IsCheckedButtonB = this.IsCheckedButtonC = false;
            this.IsCheckedINeedHelp = this.IsCheckedIAmFulfilled = false;
            this.IsUserTypeMobile = false;
            this.IsUserTypeNonMobile = false;
            this.IsSelectedStoreUser = false;
        }

        private void UpdateColorBox(string fontColor)
        {
            if ("Silver".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 1;
            }
            else if ("White".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 2;
            }
            else if ("Gray".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 3;
            }
            else if ("Navy".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 4;
            }
            else if ("Blue".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 5;
            }
            else if ("Red".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 6;
            }
            else if ("Brown".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 7;
            }
            else if ("Purple".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 8;
            }
            else if ("Beige".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 9;
            }
            else if ("Green".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 10;
            }
            else if ("Orange".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 11;
            }
            else if ("Yellow".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 12;
            }
            else if ("Pink".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 13;
            }
            else if ("Other".Equals(fontColor))
            {
                this.NoteColorSelectedIndex = 14;
            }
            else
            {
                this.NoteColorSelectedIndex = 0;
            }
        }
    }
}
