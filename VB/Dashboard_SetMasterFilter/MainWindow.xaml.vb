Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWpf
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation

Namespace Dashboard_SetMasterFilter
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub DashboardControl_ConfigureDataConnection(ByVal sender As Object, ByVal e As DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventArgs)
			Dim parameters As ExtractDataSourceConnectionParameters = TryCast(e.ConnectionParameters, ExtractDataSourceConnectionParameters)
			If parameters IsNot Nothing Then
				parameters.FileName = System.IO.Path.GetFileName(parameters.FileName)
			End If
		End Sub

		Private Sub DashboardControl_MasterFilterSet(ByVal sender As Object, ByVal e As DevExpress.DashboardCommon.MasterFilterSetEventArgs)
			Dim viewer As DashboardControl = DirectCast(sender, DashboardControl)
			' If the Master Filter includes Anne Dodsworth as Sales Person, disable print and export.
			If e.DashboardItemName.Contains("grid") Then
				viewer.AllowPrintDashboard = If(e.SelectedValues.Select(Function(value) value(1).ToString()).Contains("Anne Dodsworth"), False, True)
			End If
		End Sub

		Private Sub DashboardControl_MasterFilterCleared(ByVal sender As Object, ByVal e As DevExpress.DashboardCommon.MasterFilterClearedEventArgs)
			MessageBox.Show("Selection cleared in the " & e.DashboardItemName & "Master Filter item.")
		End Sub

		Private Sub BtnSetMasterFilter_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			' Create a list with values to select in the Grid dashboard item.
			Dim rowValues1 As New List(Of Object)()
			rowValues1.AddRange( { "UK", "Anne Dodsworth" })
			Dim rowValues2 As New List(Of Object)()
			rowValues2.AddRange( { "USA", "Andrew Fuller" })
			Dim selectedRows As New List(Of IList)( { rowValues1, rowValues2 })

			' Create a selection range and specify its minimum and maximum values.
			Dim minimumValue As New Date(2015, 3, 1)
			Dim maximumValue As New Date(2016, 3, 1)
			Dim selectedRange As New RangeFilterSelection(minimumValue, maximumValue)

			' Select the values in the Grid dashboard item.
			dashboardControl.SetMasterFilter("gridDashboardItem1", selectedRows)
			' Select the range in the Range Filter dashboard item.
			dashboardControl.SetRange("rangeFilterDashboardItem1", selectedRange)
		End Sub
	End Class
End Namespace
