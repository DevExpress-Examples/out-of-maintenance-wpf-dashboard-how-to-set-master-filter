Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWpf
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls

Namespace Dashboard_SetMasterFilter

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub DashboardControl_ConfigureDataConnection(ByVal sender As Object, ByVal e As DashboardConfigureDataConnectionEventArgs)
            Dim parameters As ExtractDataSourceConnectionParameters = TryCast(e.ConnectionParameters, ExtractDataSourceConnectionParameters)
            If parameters IsNot Nothing Then parameters.FileName = IO.Path.GetFileName(parameters.FileName)
        End Sub

        Private Sub DashboardControl_MasterFilterSet(ByVal sender As Object, ByVal e As MasterFilterSetEventArgs)
            Dim viewer As DashboardControl = CType(sender, DashboardControl)
            ' If the Master Filter includes Anne Dodsworth as Sales Person, disable print and export.
            If e.DashboardItemName.Contains("grid") Then viewer.AllowPrintDashboard = If(e.SelectedValues.[Select](Function(value) value(1).ToString()).Contains("Anne Dodsworth"), False, True)
        End Sub

        Private Sub DashboardControl_MasterFilterCleared(ByVal sender As Object, ByVal e As MasterFilterClearedEventArgs)
            MessageBox.Show("Selection cleared in the " & e.DashboardItemName & "Master Filter item.")
        End Sub

        Private Sub BtnSetMasterFilter_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            ' Create a list with values to select in the Grid dashboard item.
            Dim rowValues1 As List(Of Object) = New List(Of Object)()
            rowValues1.AddRange({"UK", "Anne Dodsworth"})
            Dim rowValues2 As List(Of Object) = New List(Of Object)()
            rowValues2.AddRange({"USA", "Andrew Fuller"})
            Dim selectedRows As List(Of IList) = New List(Of IList)({rowValues1, rowValues2})
            ' Create a selection range and specify its minimum and maximum values.
            Dim minimumValue As Date = New DateTime(2015, 3, 1)
            Dim maximumValue As Date = New DateTime(2016, 3, 1)
            Dim selectedRange As RangeFilterSelection = New RangeFilterSelection(minimumValue, maximumValue)
            ' Select the values in the Grid dashboard item.
            Me.dashboardControl.SetMasterFilter("gridDashboardItem1", selectedRows)
            ' Select the range in the Range Filter dashboard item.
            Me.dashboardControl.SetRange("rangeFilterDashboardItem1", selectedRange)
        End Sub
    End Class
End Namespace
