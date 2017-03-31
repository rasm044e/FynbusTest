using Logic;
using Microsoft.Win32;
using System.Windows;
using System.Threading;
using DataAccess;
using System.Linq;

namespace View
{
    public class MainWindowViewModel
    {
        IOController iOController;
        SelectionController selectionController;
        OpenFileDialog openFileDialog;

        public bool ImportDone { get; set; }
        public bool SelectionDone { get; set; }

        public MainWindowViewModel()
        {
            iOController = new IOController();
            selectionController = new SelectionController();
            ImportDone = false;
        }

        //starts when import is clicked with 2 excel files entered
        public void ImportCSV(string masterDataFilepath, string routeNumberFilepath)
        {
            //delete all data in database when import is clicked and create space for new data
            using (FynbusBackupModel db = new FynbusBackupModel())
            {
                db.Database.ExecuteSqlCommand("truncate TABLE Offerstable");
                db.Database.ExecuteSqlCommand("truncate TABLE Contractorstable");
                db.Database.ExecuteSqlCommand("truncate TABLE RouteNumberstable");
            }
            //starts the import with excel file to database
            iOController.InitializeImport(masterDataFilepath, routeNumberFilepath);
        }
        public string ChooseCSVFile()
        {
            string filename = "Ingen fil er valgt";
            openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "CVS filer (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
                return filename;
            }
            return filename;
        }

        public void SaveCSVCallFile()
        {
            if (SelectionDone == true)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();

                saveDlg.Filter = "CSV filer (*.csv)|*.csv|All files (*.*)|*.*";
                saveDlg.InitialDirectory = @"C:\%USERNAME%\";
                saveDlg.ShowDialog();

                string path = saveDlg.FileName;
                iOController.InitializeExportToCallingList(path);
                MessageBox.Show("Filen er gemt.");
            }
            else
            {
                MessageBox.Show("Du har ikke udvalgt vinderne endnu.. Kør Udvælgelse først!");
            }
        }
        public void SaveCSVPublishFile()
        {
            if (SelectionDone == true)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();

                saveDlg.Filter = "CSV filer (*.csv)|*.csv|All files (*.*)|*.*";
                saveDlg.InitialDirectory = @"C:\%USERNAME%\";
                saveDlg.ShowDialog();

                string path = saveDlg.FileName;

                iOController.InitializeExportToPublishList(path);
                MessageBox.Show("Filen er gemt.");
            }
            else
            {
                MessageBox.Show("Du har ikke udvalgt vinderne endnu.. Kør Udvælgelse først!");
            }
        }

        //starts the selection when the "start udvælgesen" button is clicked
        public void InitializeSelection()
        {
            using (FynbusBackupModel db = new FynbusBackupModel())
            {
                //checks wether or not we have data in database
                var data = db.OffersTables.FirstOrDefault();

                //if there is data in the database we use that and start the import
                if (data != null)
                {
                    ImportDone = true;
                    //starts import without excel files using the database instead
                    iOController.InitializeImport(null, null);
                }
            }
            if (ImportDone)
            {
                SelectionDone = true;
                selectionController.SelectWinners();
            }
            else
            {
                MessageBox.Show("Du skal importere filerne først.");
            }
        }
    }
}
