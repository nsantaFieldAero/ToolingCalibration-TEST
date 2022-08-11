Imports System.Data.SqlClient
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms

Public Class frmCalibDueAssignTo
    Dim daAdminUsers As SqlClient.SqlDataAdapter
    Dim dsAdminUsers As New DataSet

    Private Sub frmCalibDueAssignTo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SqlConnection1.ConnectionString = sqlStringTool

        'Check if user is allowed to use---------------------------------
        Dim Uname As String = Environment.UserName
        daAdminUsers = New SqlClient.SqlDataAdapter("Select Username from tblAdmin Where Username = '" & Uname & "' and IsAdmin = 'True'", SqlConnection1)
        daAdminUsers.Fill(dsAdminUsers, "ADMIN")
        Dim test As Integer = dsAdminUsers.Tables("ADMIN").Rows.Count

        If test >= 1 Then
            'Allow access

            txtRecordID.Text = ToolIdToEdit

            Dim cmdSql As New SqlCommand
            Dim dr As SqlDataReader
            SqlConnection1.Open()
            cmdSql.Connection = SqlConnection1


            'Get combo boxes drop-down items
            cmdSql.CommandText = "Select Distinct AssignedTo from tblToolCalibration Where AssignedTo is not null and AssignedTo != '' Order By AssignedTo ASC"
            dr = cmdSql.ExecuteReader()
            Do While dr.Read = True
                cboAssignedTo.Items.Add(dr.GetString(0))
            Loop

            cmdSql.Parameters.Clear()
            dr.Close()
            cmdSql.CommandText = "Select Distinct MfrName from tblManufacturerCalibration Where MfrName is not null and MfrName != '' Order By MfrName ASC"
            dr = cmdSql.ExecuteReader()
            Do While dr.Read = True
                cboManufacturer.Items.Add(dr.GetString(0))
            Loop

            cmdSql.Parameters.Clear()
            dr.Close()
            cmdSql.CommandText = "SELECT Distinct Items FROM tblDropDownItems WHERE ColumnName = 'Division' and ColumnName is not null and ColumnName != ' '"
            dr = cmdSql.ExecuteReader()
            Do While dr.Read = True
                cbDivision.Items.Add(dr.GetString(0))
            Loop

            SqlConnection1.Close()

        Else
            MsgBox("You do not have permission to access this page")
            Me.Close()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnGenerateReport_Click(sender As Object, e As EventArgs) Handles btnGenerateReport.Click

        ToolIdToEdit = Nothing

        Dim sqlString As String
        Dim PastDue As String

        If txtRecordID.Text <> "" Then
            If Not IsNumeric(txtRecordID.Text) Then
                MessageBox.Show("Enter a number for Record ID")
                Exit Sub
            End If
        End If


        Dim crReport As New crCalibDueAssignTo
        crReport.SetDatabaseLogon("sa1", "The water is wet!")

        'crParamFeed = "Params From Date:  " & Format(dtDateFrom.Value, "MM/dd/yyyy") & "  To Date:  " & Format(Me.dtDateTo.Value, "MM/dd/yyyy") & "  ToolID:  " & txtToolID.Text & "  NextCalibrationDt:  " & cbPastDue.Checked & "  AssignedTo :  " & cboAssignedTo.Text & "  Manufacturer:  " & cboManufacturer.Text

        'Lines I had yesterday
        'Dim dtFrom As Date = Format(dtDateFrom.Value, "MM-dd-yyyy")
        'Dim dateFrom As String
        'dateFrom = Year(dtFrom).ToString.PadLeft(2, "0"c) & "-" & Month(dtFrom).ToString.PadLeft(2, "0"c) & "-" & DatePart("d", dtFrom).ToString.PadLeft(2, "0"c)

        'Dim dtTo As Date = Format(dtDateTo.Value, "MM-dd-yyyy")
        'Dim dateTo As String
        'dateTo = Year(dtTo).ToString.PadLeft(2, "0"c) & "-" & Month(dtTo).ToString.PadLeft(2, "0"c) & "-" & DatePart("d", dtTo).ToString.PadLeft(2, "0"c)


        If cbDates.Checked = True Then
            sqlString = "(LastCalibrationDt >= '" & Format(dtDateFrom.Value, "MM/dd/yyyy") & "' AND LastCalibrationDt <= '" & Format(dtDateTo.Value, "MM/dd/yyyy") & "')"
            crParamFeed = "Params From Date:  " & Format(dtDateFrom.Value, "MM/dd/yyyy") & "  To Date:  " & Format(Me.dtDateTo.Value, "MM/dd/yyyy")
        End If

        If txtRecordID.Text <> "" Then
            If sqlString <> "" Then
                sqlString = sqlString & " and "
            End If
            sqlString = sqlString & "RecordID = '" & txtRecordID.Text & "'"
            crParamFeed += "  Record ID:  " & txtRecordID.Text
            'Else
            '    MsgBox("Enter the record ID")
            '    Exit Sub
        End If

        If txtToolID.Text <> "" Then
            If sqlString <> "" Then
                sqlString = sqlString & " and "
            End If
            sqlString = sqlString & "ToolID = '" & txtToolID.Text & "'"
            crParamFeed += "  Tool ID:  " & txtToolID.Text
        End If

        If cbDivision.Text <> "" Then
            If sqlString <> "" Then
                sqlString = sqlString & " and "
            End If
            sqlString = sqlString & "Division = '" & cbDivision.Text & "'"
            crParamFeed += "  Division :  " & cbDivision.Text
        End If

        If cboAssignedTo.Text <> "" Then
            If sqlString <> "" Then
                sqlString = sqlString & " and "
            End If
            sqlString = sqlString & "AssignedTo = '" & cboAssignedTo.Text & "'"
            crParamFeed += "  Assigned To :  " & cboAssignedTo.Text
        End If

        If cboManufacturer.Text <> "" Then
            If sqlString <> "" Then
                sqlString = sqlString & " and "
            End If
            sqlString = sqlString & "Manufacturer = '" & cboManufacturer.Text & "'"
            crParamFeed += "  Manufacturer:  " & cboManufacturer.Text
        End If

        If cbPastDue.Checked = True Then
            If sqlString <> "" Then
                sqlString = sqlString & " and "
            End If
            Dim todayDate As Date = Date.Today
            sqlString = sqlString & "(NextCalibrationDt < " & "'" & todayDate & "'" & ")"
            crParamFeed += "  Next Calibration Date:  " & cbPastDue.Checked
        End If

        'If parameters are chosen
        If sqlString = "" Then
            crParamFeed = "No Parameters Chosen"
            GlobalSqlString = "Select * from tblToolCalibration"
            'If no parameters are chosen
        Else
            GlobalSqlString = "Select * from tblToolCalibration Where " & sqlString & ""
        End If

        Dim frm As New frmViewReport
        frm.ReportType = "CalibToolDue"
        frm.Report = crReport
        frm.Show()
        Me.Close()

    End Sub

End Class