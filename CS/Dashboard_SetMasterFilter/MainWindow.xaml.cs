using DevExpress.DashboardCommon;
using DevExpress.DashboardWpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Dashboard_SetMasterFilter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DashboardControl_ConfigureDataConnection(object sender, DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventArgs e)
        {
            ExtractDataSourceConnectionParameters parameters = e.ConnectionParameters as ExtractDataSourceConnectionParameters;
            if (parameters != null)
                parameters.FileName = System.IO.Path.GetFileName(parameters.FileName);
        }

        private void DashboardControl_MasterFilterSet(object sender, DevExpress.DashboardCommon.MasterFilterSetEventArgs e)
        {
            DashboardControl viewer = (DashboardControl)sender;
            // If the Master Filter includes Anne Dodsworth as Sales Person, disable print and export.
            if (e.DashboardItemName.Contains("grid"))
                viewer.AllowPrintDashboard = e.SelectedValues.Select(value => value[1].ToString()).Contains("Anne Dodsworth") ? false : true;
        }

        private void DashboardControl_MasterFilterCleared(object sender, DevExpress.DashboardCommon.MasterFilterClearedEventArgs e)
        {
            MessageBox.Show("Selection cleared in the " + e.DashboardItemName + "Master Filter item.");
        }

        private void BtnSetMasterFilter_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            // Create a list with values to select in the Grid dashboard item.
            List<object> rowValues1 = new List<object>();
            rowValues1.AddRange(new[] { "UK", "Anne Dodsworth" });
            List<object> rowValues2 = new List<object>();
            rowValues2.AddRange(new[] { "USA", "Andrew Fuller" });
            List<IList> selectedRows = new List<IList>(new[] { rowValues1, rowValues2 });

            // Create a selection range and specify its minimum and maximum values.
            DateTime minimumValue = new DateTime(2015, 3, 1);
            DateTime maximumValue = new DateTime(2016, 3, 1);
            RangeFilterSelection selectedRange = new RangeFilterSelection(minimumValue, maximumValue);

            // Select the values in the Grid dashboard item.
            dashboardControl.SetMasterFilter("gridDashboardItem1", selectedRows);
            // Select the range in the Range Filter dashboard item.
            dashboardControl.SetRange("rangeFilterDashboardItem1", selectedRange);
        }
    }
}
