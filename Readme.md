<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/167182596/18.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830475)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Dashboard for WPF - How to Set Master Filter in the DashboardControl

The following example demonstrates how to set master filter in the [DashboardControl](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl) control.

The DashboardControl loads a dashboard with two master filter items - the Grid and Range Filter dashboard items. The Chart item displays the filtered data.  

The [DashboardControl.ConfigureDataConnection](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.ConfigureDataConnection) event is handled to specify the [Extract Data Source](https://docs.devexpress.com/Dashboard/115900/creating-dashboards/creating-dashboards-in-the-winforms-designer/providing-data/extract-data-source) filename.

A custom template inserts a command button in the dashboard title with a click action that sets the dashboard's master filter.

The [DashboardControl.SetMasterFilter](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.SetMasterFilter.overloads) method selects the rows in the [Grid]( https://docs.devexpress.com/Dashboard/15150)  dashboard item. The [DashboardControl.SetRange](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.SetRange.overloads) method selects the range in the [Range Filter](https://docs.devexpress.com/Dashboard/15265) dashboard item.

This example also demonstrates how to handle the [DashboardControl.MasterFilterSet](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.MasterFilterSet) and [DashboardControl.MasterFilterCleared](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.MasterFilterCleared) events.

![screenshot](https://github.com/DevExpress-Examples/wpf-dashboard-how-to-set-master-filter/blob/18.2.4%2B/images/screenshot.png)

## Documentation

- [Master Filtering](https://docs.devexpress.com/Dashboard/400011/wpf-viewer/manage-interactivity-capabilities#master-filtering)
- [Extract Data Source](https://docs.devexpress.com/Dashboard/115900/winforms-dashboard/winforms-designer/create-dashboards-in-the-winforms-designer/providing-data/extract-data-source)

## More Examples

- [Dashboard for WPF - How to use the DashboardStateChanged event to display user interactions](https://github.com/DevExpress-Examples/wpf-dashboard-viewer-DashboardStateChanged-event)
- [Dashboard for WPF - How to Synchronize Master Filter and Drill Down Actions Between Dashboards](https://github.com/DevExpress-Examples/wpf-dashboard-linked-interactivity)
