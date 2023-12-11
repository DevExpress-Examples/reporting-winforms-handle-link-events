<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128597725/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1129)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Reporting for WinForms - How to Handle Link Events

This example demonstrates how you can use an [empty link](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase) (shipped with the [XtraPrinting Library](https://docs.devexpress.com/WindowsForms/2079/controls-and-libraries/printing-exporting)) to create a simple report. An empty link allows you to populate your report section by section.

The example shows the following event handlers:

* [CreateDetailArea](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.CreateDetailArea)
* [CreateMarginalHeaderArea](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.CreateMarginalHeaderArea)
* [CreateDetailHeaderArea](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.CreateDetailHeaderArea)
* [CreateDetailFooterArea](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.CreateDetailFooterArea)

## Files to Review

* [Form1.cs](./CS/UseLinkEvents/Form1.cs) (VB: [Form1.vb](./VB/UseLinkEvents/Form1.vb))
