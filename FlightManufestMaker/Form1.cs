using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;


namespace FlightManufestMaker
{
    public partial class frmMain : Form
    {
        DataTable dgTable;

        //Create COM Objects to write manifest.
        //ExcelApp.Application manifestExcel = new ExcelApp.Application();
        //ExcelApp.Workbook manifestWorkbook;
        //ExcelApp.Worksheet manifestWorksheet;
        //ExcelApp.Range manifestCellrange;

        public frmMain()
        {
            InitializeComponent();
            
        }

        //Create COM Objects to read countries.
        //ExcelApp.Application countryExcel = new ExcelApp.Application();
        DataRow myNewRow;
        DataTable myTable;
        private DataTable dtCountry;

        string localNat;

        private void frmMain_Load(object sender, EventArgs e)
        {
            radShip.Checked = true;

            btnGenerate.Enabled = false;
            btnSave.Enabled = false;

            //txtPaxCount.Text = "5";
            //txtShipFlight.Text = "UL256";

            localNat = ConfigurationManager.AppSettings["localNat"];
            txtLocalNat.Text = localNat;
            txtLocalNat.ReadOnly = true;

            loadCountries();
        }

        private DataTable getShipManifestColums()
        {
            DataTable table = new System.Data.DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("GIVENNAME", typeof(string));
            table.Columns.Add("LASTNAME", typeof(string));
            table.Columns.Add("NATIONALITY", typeof(string));
            table.Columns.Add("GENDER", typeof(string));
            table.Columns.Add("DOB", typeof(string));
            table.Columns.Add("TYPE", typeof(string));
            table.Columns.Add("DOCUMENTNO", typeof(string));
            table.Columns.Add("DOCUMENTTYPE", typeof(string));
            table.Columns.Add("EXPIRYDATE", typeof(string));
            
            return table;
        }

        private DataTable getFlightManifestColums()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("GIVENNAME", typeof(string));
            table.Columns.Add("LASTNAME", typeof(string));
            table.Columns.Add("NATIONALITY", typeof(string));
            table.Columns.Add("DOCUMENTNO", typeof(string));
            table.Columns.Add("GENDER", typeof(string));
            table.Columns.Add("DOB", typeof(string));
            table.Columns.Add("TYPE", typeof(string));
            table.Columns.Add("DOCUMENTTYPE", typeof(string));
            table.Columns.Add("EXPIRYDATE", typeof(string));

            return table;
        }

        private void addRows(int paxCount)
        {
            for (int i = 1; i <= paxCount; i++)
            {


                DataRow country = rndCountry();
                string alpha2 = country[1].ToString();
                string alpha3 = country[2].ToString();
                string paxType = "FOREIGN";
                string docType = "NP";

                if (alpha3 == localNat)
                {
                    paxType = "LOCAL";
                }

                if (radShip.Checked)
                {
                        dgTable.Rows.Add(i, generateName(5), generateName(7), alpha3, rndGender(), rndDOB(), paxType, rndTravelDoc(alpha2), docType, rndExpiryDate());
                }
                else
                {
                        dgTable.Rows.Add(i, generateName(5), generateName(7), alpha3, rndTravelDoc(alpha2), rndGender(), rndDOB(), paxType, docType, rndExpiryDate());
                }

            }
        }

        public static string generateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        private string rndGender()
        {
            string[] genders = { "M", "F" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 2;
            return genders[index];
        }

        private string rndDOB()
        {
            DateTime start = new DateTime(1945, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private string rndExpiryDate()
        {
            DateTime start = DateTime.Today;
            int range = 100;
            return start.AddDays(gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private Random gen = new Random();

        public int randomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private readonly Random _random = new Random();


        private string rndTravelDoc(string prefix)
        {
            var tdBuilder = new StringBuilder();
            tdBuilder.Append(prefix);
            tdBuilder.Append(randomNumber(10000, 99999));

            return tdBuilder.ToString();
        }

        private void saveManifest(string fileName)
        {
            ExcelApp.Application manifestExcel = new ExcelApp.Application();
            ExcelApp.Workbook manifestWorkbook = manifestExcel.Workbooks.Add(Type.Missing);

            try
            {
                //manifestExcel = new ExcelApp.Application();
                manifestExcel.Visible = false;
                manifestExcel.DisplayAlerts = false;
                //manifestWorkbook = manifestExcel.Workbooks.Add(Type.Missing);


                ExcelApp.Worksheet manifestWorksheet = (ExcelApp.Worksheet)manifestWorkbook.ActiveSheet;
                //manifestWorksheet = (ExcelApp.Worksheet)manifestWorkbook.ActiveSheet;
                manifestWorksheet.Name = "Passenger Data";

                
                manifestWorksheet.Cells[1, 1] = txtShipFlight.Text;
                manifestWorksheet.Cells.Font.Size = 11;
            

            for (int i = 1; i <= dgTable.Columns.Count; i++)
            {
                manifestWorksheet.Cells[2, i] = dgTable.Columns[i - 1].ColumnName;
                manifestWorksheet.Cells.Font.Color = System.Drawing.Color.Black;
            }





            int worksheetRow = 2;

            foreach (DataRow datarow in dgTable.Rows)
            {
                worksheetRow += 1;
                                               
                    for (int i = 1; i <= dgTable.Columns.Count; i++)
                    {
                    manifestWorksheet.Cells[worksheetRow, i] = "'" + datarow[i - 1].ToString();
                    
                    }

            }


            

                manifestWorkbook.SaveAs(fileName);
                manifestWorkbook.Close();
                //manifestExcel.Quit();

            }

            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //manifestWorksheet = null;
                //manifestCellrange = null;
                //manifestWorkbook = null;

                //if (manifestWorkbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(manifestWorkbook);
                //GC.Collect();
                manifestExcel?.Quit();
                Thread.Sleep(5000);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtShipFlight.ReadOnly = true;
            txtPaxCount.ReadOnly = true;
            btnGenerate.Enabled = false;
            int paxCount = Int32.Parse(txtPaxCount.Text);
            addRows(paxCount);
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            dataGridView1.ReadOnly = true;

            string fileName;

            if (radShip.Checked)
            {
                fileName = "SHIP_";
                radFlight.Visible = false;
            }
            else
            {
                fileName = "FLIGHT_";
                radShip.Visible = false;

            }

            fileName += txtShipFlight.Text + "_";

            fileName += DateTime.Now.ToString("yyyyMMddHHmmss");

            saveManifest(fileName);
            MessageBox.Show(fileName + " Saved !");

            radShip.Visible = true;
            radFlight.Visible = true;
            dataGridView1.ReadOnly = false;
        }

        private void radShip_CheckedChanged(object sender, EventArgs e)
        {
            radCheckedChange();
        }

        private void radFlight_CheckedChanged(object sender, EventArgs e)
        {
            radCheckedChange();
        }

        private void radCheckedChange()
        {
            btnGenerate.Enabled = false;
            btnSave.Enabled = false;

            if (radShip.Checked)
            {
                dgTable = getShipManifestColums();
                lblName.Text = "Ship Name";
                
            }
            else
            {
                dgTable = getFlightManifestColums();
                lblName.Text = "Flight Name";

            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dgTable;

            txtShipFlight.ReadOnly = false;
            txtPaxCount.ReadOnly = false;

            txtChanged();
        }

        private void txtShipFlight_TextChanged(object sender, EventArgs e)
        {
            txtChanged();
        }

        private void txtPaxCount_TextChanged(object sender, EventArgs e)
        {
            txtChanged();
        }

        private int getNameLength()
        {
            return txtShipFlight.Text.Length;
        }

        private int getPaxCount()
        {
            if (txtPaxCount.Text.Length>0)
            {
                return Int32.Parse(txtPaxCount.Text);
            }
            else
            {
                return 0;
            }
        }

        private void txtChanged()
        {
            if ((getNameLength() > 2)&&(getPaxCount()>0))
            {
                btnGenerate.Enabled = true;
            }
            else
            {
                btnGenerate.Enabled = false;
            }
        }

        private void txtPaxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        

        private void loadCountries()
        {
            try
            {
                var GetDirectory = AppContext.BaseDirectory;

                dtCountry = ReadExcel(GetDirectory + "\\Countries.xlsx"); //read excel file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataRow rndCountry()
        {

            Random r = new Random();
            int rInt = r.Next(1, dtCountry.Rows.Count);

            DataRow countryRow = dtCountry.Rows[rInt];

            return countryRow;
        }

        private DataTable ReadExcel(string fileName)
        {
            ExcelApp.Application countryExcel = new ExcelApp.Application();
            ExcelApp.Workbook excelBook = countryExcel.Workbooks.Open(fileName);

            try
            {
                //Open Excel file

                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                ExcelApp.Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;

                //Set DataTable Name and Columns Name
                myTable = new DataTable(excelSheet.Name);

                //first row using for heading
                for (int i = 1; i <= cols; i++)
                {
                    myTable.Columns.Add(excelRange.Cells[1, i].Value2.ToString(), typeof(string));
                }

                if (rows > 1)
                {
                    //first row using for heading, start second row for data
                    for (int r = 2; r <= rows; r++)
                    {
                        myNewRow = myTable.NewRow();
                        for (int c = 1; c <= cols; c++)
                        {
                            string cellVal = "";

                            if (myTable.Columns[c - 1].ColumnName.Contains("Date"))
                            {
                                DateTime conv = DateTime.FromOADate(excelRange.Cells[r, c].Value2);
                                cellVal = conv.ToShortDateString();
                            }
                            else
                            {
                                cellVal = Convert.ToString(excelRange.Cells[r, c].Value2);
                            }
                            myNewRow[c - 1] = cellVal;


                        }
                        myTable.Rows.Add(myNewRow);
                    }
                }
                else
                {
                    DataRow newrow = myTable.NewRow();

                    for (int i = 0; i < cols; i++)
                    {
                        newrow[i] = "";
                    }

                    myTable.Rows.Add(newrow);
                }

                excelBook.Close();
                return myTable;
            }
            finally
            {
                //if (excelBook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelBook);
                //GC.Collect();
                countryExcel?.Quit();
                Thread.Sleep(5000);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();

        }
    }
}
