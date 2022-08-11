Imports System.Data.SqlClient
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms

Public Class frmCalibrationRecordsReport
    Public dtpDateCalibratedValue As Nullable(Of Date)
    Private cmdSql As SqlCommand
    Dim daAdminUsers As SqlClient.SqlDataAdapter
    Dim dsAdminUsers As New DataSet

    Private Sub frmCalibrationRecordsReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SqlConnection1.ConnectionString = sqlStringTool

        'Check if user is allowed to use---------------------------------
        Dim Uname As String = Environment.UserName
        daAdminUsers = New SqlClient.SqlDataAdapter("Select Username from tblAdmin Where Username = '" & Uname & "' and IsAdmin = 'True'", SqlConnection1)
        daAdminUsers.Fill(dsAdminUsers, "ADMIN")
        Dim test As Integer = dsAdminUsers.Tables("ADMIN").Rows.Count

        If test >= 1 Then
            'Allow access

            txtRecordID.Text = ToolIdToEdit

            dtpDateCalibratedValue = Nothing
            dtpDateCalibrated.CustomFormat = " "
            dtpDateCalibrated.Format = DateTimePickerFormat.Custom

            Dim cmdSql As New SqlCommand
            Dim dr As SqlDataReader
            SqlConnection1.Open()
            cmdSql.Connection = SqlConnection1
            cmdSql.CommandText = "Select Distinct CalibratedBy from tblToolCalibrationRecord Where CalibratedBy is not null and CalibratedBy != ' ' Order By CalibratedBy ASC"
            dr = cmdSql.ExecuteReader()
            Do While dr.Read = True
                cbCalibratedBy.Items.Add(dr.GetString(0))
            Loop
            cmdSql.Parameters.Clear()
            dr.Close()
            SqlConnection1.Close()

        Else
            MsgBox("You do not have permission to access the admin page")
            Me.Close()
        End If

    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click

        ToolIdToEdit = Nothing

        Dim sqlString As String

        If txtRecordID.Text <> "" Then
            If Not IsNumeric(txtRecordID.Text) Then
                MessageBox.Show("Enter a number for Record ID")
                Exit Sub
            End If
        End If


        Dim crReport As New crToolsCalibrationRecord
        crReport.SetDatabaseLogon("sa1", "The water is wet!")


        If txtRecordID.Text <> "" Then
            sqlString = "ToolID = '" & txtRecordID.Text & "'"
            crParamFeed = "Record ID:  " & txtRecordID.Text
            'Else
            '    MsgBox("Enter the record ID")
            '    Exit Sub
        End If

        If dtpDateCalibratedValue IsNot Nothing Then
            If sqlString <> "" Then
                sqlString = sqlString & " and "
            End If
            sqlString = sqlString & "DateCalibrated = '" & dtpDateCalibratedValue & "'"
            crParamFeed += "  Date Calibrated:  " & dtpDateCalibrated.Value
        End If

        If cbCalibratedBy.Text <> "" Then
            If sqlString <> "" Then
                sqlString = sqlString & " and "
            End If
            sqlString = sqlString & "CalibratedBy = '" & cbCalibratedBy.Text & "'"
            crParamFeed += "  Calibrated By:  " & cbCalibratedBy.Text
        End If

        'If parameters are chosen
        If sqlString = "" Then
            crParamFeed = "No Parameters Chosen"
            GlobalSqlString = "Select * from tblToolCalibrationRecord"
            'If no parameters are chosen
        Else
            GlobalSqlString = "Select * from tblToolCalibrationRecord Where " & sqlString & ""
        End If

        Dim frm As New frmViewReport
        frm.ReportType = "CalibToolRecord"
        frm.Report2 = crReport
        frm.Show()
        Me.Close()

    End Sub

    Private Sub dtpDateCalibrated_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateCalibrated.ValueChanged

        If dtpDateCalibrated.Format = DateTimePickerFormat.Custom AndAlso dtpDateCalibrated.CustomFormat = " " Then
            dtpDateCalibrated.Format = DateTimePickerFormat.Short
        End If

        dtpDateCalibratedValue = dtpDateCalibrated.Value
    End Sub
End Class