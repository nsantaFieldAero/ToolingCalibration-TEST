Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Base

Public Class Tool_Assignment
    Dim daToolAssign As SqlClient.SqlDataAdapter
    Dim dsToolAssign As New DataSet
    Public dataSaved As String
    Dim da As SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Dim test As String

    Private Sub Tool_Assignment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SqlConnection1.ConnectionString = sqlStringTool

        'Check if user is allowed to use application---------------------------------
        Dim Uname As String = Environment.UserName
        daToolAssign = New SqlClient.SqlDataAdapter("Select Username from tblAdmin Where Username = '" & Uname & "' and IsAdmin = 'True'", SqlConnection1)
        daToolAssign.Fill(dsToolAssign, "USERS")
        Dim test As Integer = dsToolAssign.Tables("USERS").Rows.Count

        'Dim CloseTheForm As String

        If test >= 1 Then
            'Allow access

            dataSaved = "yes"

            'Next 3 lines fill the gridcontrol With all records from Oracle database
            'OracleDataAdapter1.Fill(DsOracleToolAssign1.F060116)
            'bsOracleToolAssign.DataSource = DsOracleToolAssign1.F060116
            'gridOracleToolAssign.DataSource = bsOracleToolAssign

            'Fill gridcontrol with data-----------------------------------------------------------------------------        
            If IsCalgary = "Yes" Then
                daToolAssign = New SqlClient.SqlDataAdapter("Select * From tblToolIssues Where Division = 'Calgary' And (DateReturned is NULL or DateReturned = '')", SqlConnection1)
            Else
                daToolAssign = New SqlClient.SqlDataAdapter("Select * From tblToolIssues Where Division != 'Calgary' And (DateReturned is NULL or DateReturned = '')", SqlConnection1)
            End If

            daToolAssign.Fill(dsToolAssign, "ToolIssues")
            Me.bsToolIssuedOut.DataSource = dsToolAssign.Tables("ToolIssues")
            GridControl1.DataSource = Me.bsToolIssuedOut

        Else
            MsgBox("You do not have permission to access the tool assignment page")
            dataSaved = "yes"
            Me.Close()
            'CloseTheForm = "yes"
        End If

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        GridControl1.ExportToXlsx("C:\Temp\Export.xlsx")
        MsgBox("Grid has been exported to c:\temp\export.xlsx.")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        SqlDataAdapter1.Update(dsToolAssign, "ToolIssues")
    End Sub

    'Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    '    Try
    '        'Me.SqlDataAdapter1.Update(dsToolAssign, "TOOLASSIGN")
    '        OracleDataAdapter1.Update(DsOracleToolAssign1.F060116)
    '        MsgBox("Data Saved")
    '        dataSaved = "yes"

    '        Me.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("An error occured while updating, after clicking Save." & vbLf & vbLf & ex.Message)
    '    End Try
    'End Sub

    'Private Sub ToolAssign_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    '    If dataSaved <> "yes" Then
    '        Dim result As DialogResult = MessageBox.Show("Do you want to save the changes?", "Title", MessageBoxButtons.YesNo)
    '        If (result = DialogResult.Yes) Then
    '            'Me.SqlDataAdapter1.Update(dsToolAssign, "TOOLASSIGN")
    '            btnSave.PerformClick()
    '        End If
    '    End If

    'End Sub

    'Private Sub GridView1_CellValueChanging(sender As Object, e As CellValueChangedEventArgs)
    '    dataSaved = "no"
    'End Sub

    'Private Sub GridView1_RowDeleted(sender As Object, e As RowDeletedEventArgs)
    '    dataSaved = "no"
    'End Sub

End Class