Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Office.Interop

Public Class ToolIssues
    Dim daToolIssues As SqlClient.SqlDataAdapter
    Dim dsToolIssues As New DataSet
    Dim daIssuedTo As SqlClient.SqlDataAdapter
    Dim dsIssuedTo As New DataSet
    Dim daPrograms As SqlClient.SqlDataAdapter
    Dim dsPrograms As New DataSet
    Dim da As SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Public dataIssuesSaved As String
    Public CountRows As Integer
    Public dataSaved As String
    'Public 
    Dim daAdminUsers As SqlClient.SqlDataAdapter
    Dim dsAdminUsers As New DataSet

    Private Sub ToolIssues_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SqlConnection1.ConnectionString = sqlStringTool

        dataIssuesSaved = "yes"
        dataSaved = "yes"


        'Fill grid with data
        daToolIssues = New SqlClient.SqlDataAdapter("Select * from tblToolIssues Where ToolRecordID = " & ToolIdToEdit & "", SqlConnection1)
        daToolIssues.Fill(dsToolIssues, "ToolIssuesRecord")
        Me.bsToolIssues.DataSource = dsToolIssues.Tables("ToolIssuesRecord")
        gridToolIssues.DataSource = Me.bsToolIssues


        'Give values to IssuedTo combobox----------------------------------------------------------------------------

        'daIssuedTo = New SqlClient.SqlDataAdapter("Select Distinct Username from tblToolAssignment Where Username != ' ' and Username is not null Order By Username ASC", SqlConnection1)
        'daIssuedTo.Fill(dsIssuedTo, "ASSIGNEDTO")

        'Dim i As Integer = 0
        'While i <= dsIssuedTo.Tables("ASSIGNEDTO").Rows.Count - 1
        '    RepositoryItemComboBox1.Items.Add(dsIssuedTo.Tables("ASSIGNEDTO").Rows(i).Item("Username"))
        '    i = i + 1
        'End While


        'FOLLOWING BLOCK OF CODE WAS COMMENTED TO SOLVE THE ORACLE ERROR ABOUT HAVING AN ORACLE VERSION GREATER THAN... 
        'Dim cmdOracle As New OracleCommand
        'Dim drOracle As OracleDataReader
        'OracleConnection1.Open()
        'cmdOracle.Connection = OracleConnection1
        ''daOracle = New OracleClient.OracleDataAdapter("Select YAALPH From CRPDTA.F060116", OracleConnection1)
        ''dsOracle = New DataSet()
        ''daOracle.Fill(dsOracle, "EmployeesName")
        'cmdOracle.CommandText = "Select YAALPH From CRPDTA.F060116 Where YAPAST = '0' Order By YAALPH ASC"
        'drOracle = cmdOracle.ExecuteReader()
        'Do While drOracle.Read = True
        '    RepositoryItemComboBox1.Items.Add(drOracle.GetString(0))
        'Loop

        'cmdOracle.Parameters.Clear()
        'drOracle.Close()
        'OracleConnection1.Close()


        'Give values to Program combobox----------------------------------------------------------------------------
        daPrograms = New SqlClient.SqlDataAdapter("Select Distinct ProgramName from tblPrograms Where ProgramName != ' ' and ProgramName is not null Order By ProgramName ASC", SqlConnection1)
        daPrograms.Fill(dsPrograms, "PROGRAMS")

        Dim i As Integer = 0
        i = 0
        While i <= dsPrograms.Tables("PROGRAMS").Rows.Count - 1
            RepositoryItemComboBox2.Items.Add(dsPrograms.Tables("PROGRAMS").Rows(i).Item("ProgramName"))
            i = i + 1
        End While

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Division As String = ""


        'SET TOOL RECORD ID CELL VALUE AS THE ONE FROM THE CELL ABOVE
        Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns.ColumnByFieldName("ToolRecordID")
        If Col Is Nothing Then Exit Sub
        'Obtain the number of data rows.  
        Dim DataRowCount As Integer = GridView1.DataRowCount
        DataRowCount -= 1
        GridView1.SetRowCellValue(DataRowCount, Col, ToolIdToEdit)

        'Set AssignedTo on the main page to the last one set in the IssuedTo column in the tblToolIssues
        SetAssignedToOnMainPage()

        'Update Tool Issues Table
        Try
            Me.SqlDataAdapter1.Update(dsToolIssues, "ToolIssuesRecord")
            dataIssuesSaved = "yes"
        Catch ex As Exception
            MessageBox.Show("An error occured while updating after clicking Save." & vbLf & vbLf & ex.Message)
        End Try


        SaveAddedRow()


        If IsCalgary = "Yes" Then
            Division = "Calgary"
        End If

        'Save the ToolID of the newly issued tool into the tblToolIssues, which is shown in the Tools Issued screen
        u.ExecuteSQL(SqlConnection1, "Update tblToolIssues Set ToolIDFromToolCalibrationTbl = '" & ToolIDMainScreen & "', Description = '" & DescriptionMainScreen & "', NextCalibrationDate = '" & NextCalibDateMainScreen & "', Division = '" & Division & "' Where ToolRecordID = '" & ToolIdToEdit & "'")


        MsgBox("Data Saved")
        dataSaved = "yes"


        Try
            'Insert into tblPrograms the program the user typed in. This way they can manage the programs from tblPrograms directly with the Program drop-down
            Dim sqlString As String = "DELETE From tblPrograms INSERT INTO tblPrograms (ProgramName) Select Distinct Program From tblToolIssues where Program is not null and Program != ''"
            Dim toolCmd As New SqlCommand(sqlString, SqlConnection1)
            toolCmd.Connection.Open()
            toolCmd.ExecuteNonQuery()
            toolCmd.Connection.Close()
        Catch ex As Exception
            MessageBox.Show("An error occured while inserting the new program you typed in." & vbLf & vbLf & ex.Message)
        End Try

        'Reload grid data of the Tools page
        Tools.ReloadGridData()

        Me.Close()

    End Sub

    Public Function SaveAddedRow()

        Dim Uname As String = Environment.UserName
        Dim I As Integer
        Dim DataRowCount As Integer = GridView1.DataRowCount

        Try
            'Set Required Return Date for the new records equal to today's date if it is empty
            Dim ReturnDateCol As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns.ColumnByFieldName("RequiredReturnDate")
            For I = 0 To DataRowCount - 1
                If IsDBNull(GridView1.GetRowCellValue(I, colToolRecordID)) Then
                    If IsDBNull(GridView1.GetRowCellValue(I, colRequiredReturnDate)) Then
                        GridView1.SetRowCellValue(I, ReturnDateCol, Today)
                    End If
                End If
            Next


            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns.ColumnByFieldName("ToolRecordID")
            'Set all cells under ToolRecordID equal to ToolIdToEdit
            For I = 0 To DataRowCount + 1
                GridView1.SetRowCellValue(I, Col, ToolIdToEdit)
            Next


            Dim IssuedByCol As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns.ColumnByFieldName("IssuedBy")
            'Set new cells under IssuedBy equal to the username of the user using the app
            For I = 0 To DataRowCount - 1
                If IsDBNull(GridView1.GetRowCellValue(I, colIssuedBy)) Then
                    GridView1.SetRowCellValue(I, IssuedByCol, Uname)
                End If
            Next


            Me.SqlDataAdapter1.Update(dsToolIssues, "ToolIssuesRecord")
            dataSaved = "yes"

        Catch ex As Exception
            MessageBox.Show("An error occured in the SaveAddedRow function." & vbLf & vbLf & ex.Message)
        End Try

    End Function


    Public Function SetAssignedToOnMainPage()

        Dim IssuedTo As String
        Dim ReturnedDate As Date
        Dim AssignedWorkOrder As String
        Dim DateIssued As Date


        Dim DataRowCount As Integer = GridView1.DataRowCount
        DataRowCount -= 1


        'Following if statement sets AssignedTo, AssignedWorkOrder and DateIssued on main page to something
        Try

            If IsCalgary = "Yes" Then
                If IsDBNull(GridView1.GetRowCellValue(DataRowCount, colWorkOrder)) Then
                    AssignedWorkOrder = ""
                Else
                    AssignedWorkOrder = GridView1.GetRowCellValue(DataRowCount, colWorkOrder)
                End If

                If IsDBNull(GridView1.GetRowCellValue(DataRowCount, colDateIssued)) Then
                    DateIssued = ""
                Else
                    DateIssued = GridView1.GetRowCellValue(DataRowCount, colDateIssued)
                End If
            End If


            If IsDBNull(GridView1.GetRowCellValue(DataRowCount, colDateReturned)) Then
                If IsDBNull(GridView1.GetRowCellValue(DataRowCount, colIssuedTo)) Then
                    IssuedTo = ""
                Else
                    IssuedTo = GridView1.GetRowCellValue(DataRowCount, colIssuedTo)
                End If

                'In the grid of the main page, set AssignedTo equal to the person the tool has been issued to on the ToolIssues page
                Dim sqlString As String = "UPDATE tblToolCalibration SET AssignedTo = '" & IssuedTo & "', AssignedWorkOrder = '" & AssignedWorkOrder & "', DateIssued = '" & DateIssued & "' Where RecordID = '" & ToolIdToEdit & "'"
                Dim Cmd As New SqlCommand(sqlString, SqlConnection1)
                Cmd.Connection.Open()
                Cmd.ExecuteNonQuery()
                Cmd.Connection.Close()
            Else

                'In the grid of the main page, set AssignedTo equal to Not Issued when the tool is returned(return date is not null)
                Dim sqlString As String = "UPDATE tblToolCalibration SET AssignedTo = 'Not Issued', AssignedWorkOrder = '" & AssignedWorkOrder & "', DateIssued = '" & DateIssued & "' where RecordID = '" & ToolIdToEdit & "'"
                Dim Cmd As New SqlCommand(sqlString, SqlConnection1)
                Cmd.Connection.Open()
                Cmd.ExecuteNonQuery()
                Cmd.Connection.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("An error occured in the update in the SetAssignedToOnMainPage function." & vbLf & vbLf & ex.Message)
        End Try

    End Function

    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView1.ValidateRow

        Dim View As GridView = CType(sender, GridView)

        Dim IssuedToCol As GridColumn = View.Columns("IssuedTo")
        Dim IssuedTo As String = Convert.ToString(View.GetRowCellValue(e.RowHandle, colIssuedTo))

        Dim DateIssuedCol As GridColumn = View.Columns("DateIssued")
        Dim DateIssued As String = Convert.ToString(View.GetRowCellValue(e.RowHandle, colDateIssued))

        Dim WorkOrderCol As GridColumn = View.Columns("WorkOrder")
        Dim WorkOrder As String = Convert.ToString(View.GetRowCellValue(e.RowHandle, colWorkOrder))


        'Validate IssuedTo contains a value
        If IsDBNull(View.GetRowCellValue(e.RowHandle, colIssuedTo)) Or IssuedTo = "" Then
            IssuedTo = ""
            e.Valid = False
            'Set errors with specific descriptions for the columns 
            View.SetColumnError(colIssuedTo, "Issued To must contain a value")
        End If

        'Validate DateIssued contains a value
        If IsDBNull(View.GetRowCellValue(e.RowHandle, colDateIssued)) Or DateIssued = "" Then
            DateIssued = ""
            e.Valid = False
            'Set errors with specific descriptions for the columns 
            View.SetColumnError(colDateIssued, "Date Issued must contain a value")
        End If

        'If it is Calgary, validate there is a Work Order(which will then be used to populate AssignedWorkOrder in the main grid)
        If IsCalgary = "Yes" Then
            If IsDBNull(View.GetRowCellValue(e.RowHandle, colWorkOrder)) Or WorkOrder = "" Then
                WorkOrder = ""
                e.Valid = False
                'Set errors with specific descriptions for the columns 
                View.SetColumnError(colWorkOrder, "Work Order must contain a value")
            End If
        End If
    End Sub

    Private Sub ToolIssues_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If dataSaved <> "yes" Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save the changes?", "Title", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                btnSave.PerformClick()
            End If
        End If

    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As CellValueChangedEventArgs)
        dataSaved = "no"
    End Sub

    Private Sub GridView1_RowDeleted(sender As Object, e As RowDeletedEventArgs)
        dataSaved = "no"
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        gridToolIssues.ExportToXlsx("C:\Temp\ToolTrackingExport.xlsx")

        Dim Path As String = "C:\Temp\ToolTrackingExport.xlsx"
        Dim Excel As Excel.Application = New Excel.Application
        Excel.DisplayAlerts = False
        Excel.Visible = True
        Dim WorkBook As Excel.Workbook = Excel.Workbooks.Open(Path)

    End Sub

    Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow

        'User cannot issue a tool if it has not been returned yet
        da = New SqlClient.SqlDataAdapter("Select * From tblToolIssues Where ToolRecordID = '" & ToolIdToEdit & "' And (DateReturned Is Null Or DateReturned = '')", SqlConnection1)
        da.Fill(ds, "ToolsNotReturned")
        If ds.Tables("ToolsNotReturned").Rows.Count > 0 Then
            MsgBox("Tool cannot be issued as it has not been returned yet. Populate empty Date Returned above.")
            ds.Tables("ToolsNotReturned").Clear()
            ds.Tables("ToolsNotReturned").Dispose()
            Me.Close()
            Exit Sub
        End If

    End Sub
End Class