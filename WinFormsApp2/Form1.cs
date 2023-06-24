using ExcelDataReader;
using System.Data;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(appPath, "Baza_Danych", "Excel_Baza_danych_zajecia_2.xlsx");

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                var reader = filePath.EndsWith(".xls")
                    ? ExcelReaderFactory.CreateBinaryReader(stream)
                    : ExcelReaderFactory.CreateOpenXmlReader(stream);

                var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });

                var dataTable = dataSet.Tables[0];

                listView1.Items.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    //string mergedColumns = row[0].ToString() + " " + row[1].ToString();
                    string mergedColumns = row[0].ToString() + " " + row[1].ToString();

                    ListViewItem item = new ListViewItem(mergedColumns); // Dodaj pierwsz¹ kolumnê jako pierwsz¹ kolumnê ListViewItem

                    // Dodaj pozosta³e kolumny jako SubItems do ListViewItem
                    for (int i = 1; i < dataTable.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    listView1.Items.Add(item);

                }
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Pobranie wartoœci zaznaczonego elementu listy (wszystkich kolumn)
                List<string> selectedValues = new List<string>();
                foreach (ListViewItem.ListViewSubItem subItem in selectedItem.SubItems)
                {
                    selectedValues.Add(subItem.Text);
                }

                // Tworzenie nowego formularza i przekazywanie wartoœci jako parametr konstruktora
                Form2 newForm = new Form2(selectedValues);
                newForm.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
