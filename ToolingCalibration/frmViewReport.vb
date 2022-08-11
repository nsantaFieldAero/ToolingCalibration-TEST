Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms

Public Class frmViewReport
    Public Report As crCalibDueAssignTo
    Public Report2 As crToolsCalibrationRecord
    Dim ds As New DataSet
    Dim da As SqlClient.SqlDataAdapter
    Public ReportType As String

    Private Sub frmViewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SqlConnection1.ConnectionString = sqlStringTool

        If ReportType = "CalibToolDue" Then
            Me.CrystalReportViewer1.Zoom(100)
            da = New SqlClient.SqlDataAdapter(GlobalSqlString, SqlConnection1)
            da.Fill(ds, "Data")
            Report.SetDataSource(ds.Tables("Data"))
            Report.SetParameterValue("DateRange", crParamFeed)
            CrystalReportViewer1.ReportSource = Report

        ElseIf ReportType = "CalibToolRecord" Then
            Me.CrystalReportViewer1.Zoom(100)
            da = New SqlClient.SqlDataAdapter(GlobalSqlString, SqlConnection1)
            da.Fill(ds, "Data")
            Report2.SetDataSource(ds.Tables("Data"))
            Report2.SetParameterValue("GroupBy", crParamFeed)
            CrystalReportViewer1.ReportSource = Report2
        End If

    End Sub
End Class