Imports System.ComponentModel
Imports System.Data.OracleClient
Imports System.IO
Imports System.Text
Imports DevExpress.Data
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Office.Interop

Public Class Tools
    Dim daUsers As SqlClient.SqlDataAdapter
    Dim dsUsers As New DataSet
    Dim da As SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Dim daComboBoxes As SqlClient.SqlDataAdapter
    Dim dsComboBoxes As New DataSet
    Public dataSaved As String
    Public changesSaved As String
    'If there is a change to the grid: just change the name of the following two files
    Dim Path As String = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "XtraGrid_LayoutCalgarySecond.xml")
    Dim Path2 As String = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "XtraGrid_LayoutOthersSecond.xml")
    Public isUser As String = ""
    'Dim fileName As String = "c:\XtraGrid_SaveLayoutToXML.xml"

    Private Sub frmGridLookUp_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ' Save the layout/formatting of the grid to an XML file when the form gets closed
        If IsCalgary = "Yes" Then
            GridControl1.MainView.SaveLayoutToXml(Path)
        Else
            GridControl1.MainView.SaveLayoutToXml(Path2)
        End If

        'changesSaved = "yes"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SqlConnection1.ConnectionString = sqlStringTool


        'CHANGE:  UseEmbeddedNavigator was set to False in the properties of the GridControl 08/24/21
        'CHANGE:  The following buttons of the EmbeddedNavigator had their Visible property set to False 08/24/21:
        '           CancelEdit, Edit, EndEdit, Next, Prev
        'CHANGE:  Save button disabled. Now add or edit a record is done with "Add New Tool" and "Edit Tool" buttons.  08/24/21
        btnSaveGrid.Visible = False



        'Check if user is allowed to use application ---------------------------------
        Dim Uname As String = Environment.UserName
        daUsers = New SqlClient.SqlDataAdapter("Select Username from tblAdmin Where Username = '" & Uname & "' and IsAdmin = 'True'", SqlConnection1)
        daUsers.Fill(dsUsers, "USERS")
        If dsUsers.Tables("USERS").Rows.Count = 0 Then
            'If not user just allow to view the main scren(Tools)
            ReportsToolStripMenuItem.Enabled = False
            btnVendor.Enabled = False
            btnMfr.Enabled = False
            btnToolAssign.Enabled = False
            btnAdminUsers.Enabled = False
            btnCreateRecord.Enabled = False
            btnToolIssues.Enabled = False
            btnAddNew.Enabled = False
            btnEditTool.Enabled = False
            btnDelete.Enabled = False
        Else
            'Permit the User to Use Everything
            isUser = "Yes"

            If MsgBox("Is your location Calgary?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                IsCalgary = "Yes"
            End If
        End If

        dsUsers.Tables("USERS").Clear()
        dsUsers.Tables("USERS").Dispose()
        '---------------------------------------------------------------------------



        'Save user settings --------------------------------------------------------

        'If CloseTheForm <> "yes" Then
        If IsCalgary = "Yes" Then
            'Check if the xml file that will contain the settings saved exists
            If System.IO.File.Exists(Path) Then
                'The next two lines of code gets the layout of the grid as it was when the page was closed.  This layout is saved in a xml file
                GridControl1.ForceInitialize()
                ' Restore the previously saved layout 
                GridControl1.MainView.RestoreLayoutFromXml(Path)
            Else
                ' Create or overwrite the file.
                Dim fs As FileStream = File.Create(Path)

                ' Add text to the file.
                Dim sBody As String
                sBody = "<?xml version=""1.0"" ?>" & vbCrLf & vbCrLf & vbCrLf & "<XMLFileForMyProject>" & vbCrLf & vbCrLf & "</XMLFileForMyProject>"
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(sBody)
                fs.Write(info, 0, info.Length)
                fs.Close()
            End If
            'End If

        Else

            If System.IO.File.Exists(Path2) Then
                'The next two lines of code gets the layout of the grid as it was when the page was closed.  This layout is saved in a xml file
                GridControl1.ForceInitialize()
                ' Restore the previously saved layout 
                GridControl1.MainView.RestoreLayoutFromXml(Path2)
            Else
                ' Create or overwrite the file.
                Dim fs As FileStream = File.Create(Path2)

                ' Add text to the file.
                Dim sBody As String
                sBody = "<?xml version=""1.0"" ?>" & vbCrLf & vbCrLf & vbCrLf & "<XMLFileForMyProject>" & vbCrLf & vbCrLf & "</XMLFileForMyProject>"
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(sBody)
                fs.Write(info, 0, info.Length)
                fs.Close()
            End If
        End If


        ''Save User Settings 2
        'GridControl1.ForceInitialize()
        '' Restore the previously saved layout
        'GridControl1.MainView.RestoreLayoutFromXml(fileName)




        changesSaved = "yes"

        GetData()

        'Make the following columns not visible
        GridView1.Columns("NumOfIntervals").Visible = False
        GridView1.Columns("IssuedTo").Visible = False



        'If it is not a Calgary user then hide the following columns   
        If IsCalgary <> "Yes" Then
            GridView1.Columns("NomValue").Visible = False
            GridView1.Columns("NomValueTwo").Visible = False
            GridView1.Columns("NomValueThree").Visible = False
            GridView1.Columns("NomValueFour").Visible = False
            GridView1.Columns("NomValueFive").Visible = False
            GridView1.Columns("NomValueSix").Visible = False
            GridView1.Columns("NomValueSeven").Visible = False

            GridView1.Columns("DateIssued").Visible = False
            GridView1.Columns("AssignedWorkOrder").Visible = False
        Else
            'Commented the next 7 lines and added the following 7 after I got rid(commented) of the code related to "IsCalgary"
            'GridView1.Columns("NomValue").Visible = True
            'GridView1.Columns("NomValueTwo").Visible = True
            'GridView1.Columns("NomValueThree").Visible = True
            'GridView1.Columns("NomValueFour").Visible = True
            'GridView1.Columns("NomValueFive").Visible = True
            'GridView1.Columns("NomValueSix").Visible = True
            'GridView1.Columns("NomValueSeven").Visible = True

            GridView1.Columns("NomValue").Visible = False
            GridView1.Columns("NomValueTwo").Visible = False
            GridView1.Columns("NomValueThree").Visible = False
            GridView1.Columns("NomValueFour").Visible = False
            GridView1.Columns("NomValueFive").Visible = False
            GridView1.Columns("NomValueSix").Visible = False
            GridView1.Columns("NomValueSeven").Visible = False

            GridView1.Columns("DateIssued").Visible = True
            GridView1.Columns("AssignedWorkOrder").Visible = True

            ReportsToolStripMenuItem.Enabled = False
            btnVendor.Visible = False
            btnMfr.Visible = False
            btnCreateRecord.Visible = False
        End If
    End Sub

    Public Function GetData()
        'Dim NextCalibrationDt As Date

        'Fill gridcontrol with data-----------------------------------------------------------------------------
        If IsCalgary = "Yes" Then
            da = New SqlClient.SqlDataAdapter("Select * from tblToolCalibration Where Division = 'Calgary' Order By ToolID", SqlConnection1)
        Else
            da = New SqlClient.SqlDataAdapter("Select * from tblToolCalibration Where Division != 'Calgary' Order By ToolID", SqlConnection1)
        End If

        da.Fill(ds, "TOOLS")
        Me.BindingSource1.DataSource = ds.Tables("TOOLS")
        GridControl1.DataSource = Me.BindingSource1

        'ds.Tables("TOOLS").Clear()
        'ds.Tables("TOOLS").Dispose()



        'Dim paymentDate As String
        'If paymentDate = "" Then
        '    If (IsDBNull(Trim(ds.Tables("TOOLS").Rows(1).Item("Dept")))) Then
        '        paymentDate = ""          'String.Empty
        '    Else
        '        paymentDate = "Test"
        '    End If
        'End If


        'Give values to CalibrationVendor combobox-----------------------------------------------------------------------
        daComboBoxes = New SqlClient.SqlDataAdapter("Select Distinct CalibrationVendor from tblCalibrationVendor Where CalibrationVendor is not null and CalibrationVendor != ' ' Order By CalibrationVendor ASC", SqlConnection1)
        daComboBoxes.Fill(dsComboBoxes, "VENDOR")

        Dim i As Integer = 0
        While i <= dsComboBoxes.Tables("VENDOR").Rows.Count - 1
            RepositoryItemComboBox4.Items.Add(dsComboBoxes.Tables("VENDOR").Rows(i).Item("CalibrationVendor"))
            i = i + 1
        End While
        dsComboBoxes.Tables("VENDOR").Clear()
        dsComboBoxes.Tables("VENDOR").Dispose()

        'Give values to Manufacturer combobox----------------------------------------------------------------------------
        daComboBoxes = New SqlClient.SqlDataAdapter("Select Distinct MfrName from tblManufacturerCalibration Where MfrName is not null and MfrName != ' ' Order By MfrName ASC", SqlConnection1)
        daComboBoxes.Fill(dsComboBoxes, "MFR")

        i = 0
        While i <= dsComboBoxes.Tables("MFR").Rows.Count - 1
            RepositoryItemComboBox5.Items.Add(dsComboBoxes.Tables("MFR").Rows(i).Item("MfrName"))
            i = i + 1
        End While
        dsComboBoxes.Tables("MFR").Clear()
        dsComboBoxes.Tables("MFR").Dispose()

        ''Give values to AssignedTo combobox----------------------------------------------------------------------------

        'daComboBoxes = New SqlClient.SqlDataAdapter("Select Distinct Username from tblToolAssignment Where Username is not null and Username != ' ' Order By Username ASC", SqlConnection1)
        'daComboBoxes.Fill(dsComboBoxes, "TASSIGN")

        'i = 0
        'While i <= dsComboBoxes.Tables("TASSIGN").Rows.Count - 1
        '    RepositoryItemComboBox6.Items.Add(dsComboBoxes.Tables("TASSIGN").Rows(i).Item("Username"))
        '    i = i + 1
        'End While
        'dsComboBoxes.Tables("TASSIGN").Clear()
        'dsComboBoxes.Tables("TASSIGN").Dispose()



        ''Give values to AssignedTo combobox----------------------------------------------------------------------------
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
        '    RepositoryItemComboBox6.Items.Add(drOracle.GetString(0))
        'Loop

        'cmdOracle.Parameters.Clear()
        'drOracle.Close()
        'OracleConnection1.Close()
    End Function

    Private Sub btnEditView_Click(sender As Object, e As EventArgs) Handles btnCreateRecord.Click

        ToleranceMin = ""
        TolerancePlus = ""
        NomValue = ""
        NomValueTwo = ""
        NomValueThree = ""
        NomValueFour = ""
        NomValueFive = ""
        NomValueSix = ""
        NomValueSeven = ""


        'Get Record ID
        Try
            If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RecordID")) Then
                'Nothing
            Else
                'Error if there is no ToolID
                If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ToolID")) Then
                    MsgBox("Enter Tool ID")
                    Exit Sub
                End If
                ToolIdToEdit = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RecordID")


                'Get CalibrationInterval
                If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CalibrationInterval")) Then
                    'Nothing
                Else
                    CalibInterval = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CalibrationInterval")
                End If

                'Commented next block of code to get rid of the code related to "IsCalgary"
                ''Get Tolerance Minus, Tolerance Plus, and Nominal Value to use to do the calculations for creating a calibration record
                'If IsCalgary = "Yes" Then

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ToleranceMinus")) Then
                '        MsgBox("Tolerance Minus must be populated before entering a calibration record")
                '        Exit Sub
                '    Else
                '        ToleranceMin = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ToleranceMinus")
                '    End If

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TolerancePlus")) Then
                '        MsgBox("Tolerance Plus must be populated before entering a calibration record")
                '        Exit Sub
                '    Else
                '        TolerancePlus = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TolerancePlus")
                '    End If

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValue")) Then
                '        MsgBox("Nominal Value must be populated before entering a calibration record")
                '        Exit Sub
                '    Else
                '        NomValue = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValue")
                '    End If

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueTwo")) Then
                '        NomValueTwo = ""
                '    Else
                '        NomValueTwo = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueTwo")
                '    End If

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueThree")) Then
                '        NomValueThree = ""
                '    Else
                '        NomValueThree = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueThree")
                '    End If

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueFour")) Then
                '        NomValueFour = ""
                '    Else
                '        NomValueFour = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueFour")
                '    End If

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueFive")) Then
                '        NomValueFive = ""
                '    Else
                '        NomValueFive = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueFive")
                '    End If

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueSix")) Then
                '        NomValueSix = ""
                '    Else
                '        NomValueSix = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueSix")
                '    End If

                '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueSeven")) Then
                '        NomValueSeven = ""
                '    Else
                '        NomValueSeven = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NomValueSeven")
                '    End If

                'End If

            End If

        Catch ex As Exception
            MessageBox.Show("An error occured getting the Record ID." & vbLf & vbLf & ex.Message)
        End Try


        'ToolIdToEdit = Val(txtRecordID.Text)

        'Ask if they want to save changes
        If dataSaved = "no" Then
            dataSaved = "yes"
            ConfirmSave()
        Else
            'Nothing
        End If

        Dim frmCalibrationRecord As New CalibrationRecord
        frmCalibrationRecord.ShowDialog()
        'SearchToolIdToEdit()

        'ToolIdToEdit = Nothing

    End Sub

    Public Function ConfirmSave()

        'If isUser = "Yes" Then
        '    Dim result As DialogResult = MessageBox.Show("Would you like to save changes to the grid before closing?", "Title", MessageBoxButtons.YesNo)

        '    If (result = DialogResult.Yes) Then
        '        'Me.SqlDataAdapter1.Update(ds, "TOOLS")
        '        btnSaveGrid.PerformClick()
        '        changesSaved = "yes"
        '    Else
        ReloadGridData()
        '    End If
        'End If

        ToolIdToEdit = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RecordID")

    End Function

    Public Function ReloadGridData()

        ds.Tables("TOOLS").Clear()
        ds.Tables("TOOLS").Dispose()


        If IsCalgary = "Yes" Then
            da = New SqlClient.SqlDataAdapter("Select * from tblToolCalibration Where Division = 'Calgary' Order By ToolID", SqlConnection1)
        Else
            da = New SqlClient.SqlDataAdapter("Select * from tblToolCalibration Where Division != 'Calgary' Order By ToolID", SqlConnection1)
        End If

        da.Fill(ds, "TOOLS")
        Me.BindingSource1.DataSource = ds.Tables("TOOLS")
        GridControl1.DataSource = Me.BindingSource1

    End Function

    Private Sub btnSaveGrid_Click(sender As Object, e As EventArgs) Handles btnSaveGrid.Click

        Try
            Me.SqlDataAdapter1.Update(ds, "TOOLS")
            MsgBox("Data Saved")
            dataSaved = "yes"
            changesSaved = "yes"

        Catch ex As Exception
            MessageBox.Show("An error occured after clicking on Save Grid." & vbLf & vbLf & ex.Message)
        End Try

    End Sub

    Public Function UpdateGrid()

        Me.DsToolCalibration1.tblToolCalibration.Clear()

        Dim cmdSave As String = Me.SqlDataAdapter1.SelectCommand.CommandText
        Me.SqlDataAdapter1.SelectCommand.CommandText = cmdSave

    End Function

    Private Sub GridView1_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        dataSaved = "no"
        changesSaved = "no"
    End Sub

    Private Sub GridView1_RowDeleted(sender As Object, e As RowDeletedEventArgs) Handles GridView1.RowDeleted
        dataSaved = "no"
        changesSaved = "no"
    End Sub

    Private Sub ToolsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If isUser = "Yes" Then
            If changesSaved <> "yes" Then
                Dim result2 As DialogResult = MessageBox.Show("Do you want to save the changes?", "Title", MessageBoxButtons.YesNo)
                If (result2 = DialogResult.Yes) Then
                    MessageBox.Show("Saving your changes and/or additions?", "Title")
                    ''Me.SqlDataAdapter1.Update(ds, "TOOLS")
                    btnSaveGrid.PerformClick()
                End If
            End If
        End If



        'Below block was already commented out before I commented all the code related to "IsCalgary"
        ''Save Grid Layout when exiting form
        ''If IsCalgary = "Yes" Then
        ''    GridControl1.MainView.SaveLayoutToXml(Path)
        ''Else
        ''    GridControl1.MainView.SaveLayoutToXml(Path2)
        ''End If
    End Sub

    'CHANGE:  Commented out the following block of code 08/24/21
    'Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow

    '    Dim View As GridView = CType(sender, GridView)
    '    Dim toolIDCol As GridColumn = View.Columns("ToolID")
    '    Dim toolID As String = Convert.ToString(View.GetRowCellValue(e.RowHandle, colToolID))

    '    'Validate row if there is no ToolID
    '    If IsDBNull(View.GetRowCellValue(e.RowHandle, colToolID)) Or toolID = "" Then
    '        toolID = ""
    '        e.Valid = False
    '        'Set errors with specific descriptions for the columns 
    '        View.SetColumnError(colToolID, "The tool ID must contain a value")
    '    End If


    '    Dim calibrationIntervalCol As GridColumn = View.Columns("CalibrationInterval")
    '    Dim calibrationInterval As String = Convert.ToString(View.GetRowCellValue(e.RowHandle, colCalibrationInterval))
    '    'Validate row if there is no Interval
    '    If IsDBNull(View.GetRowCellValue(e.RowHandle, colCalibrationInterval)) Or calibrationInterval = "" Then
    '        calibrationInterval = ""
    '        e.Valid = False
    '        'Set errors with specific descriptions for the columns 
    '        View.SetColumnError(colCalibrationInterval, "The interval must contain a value")
    '    End If


    '    'Status must be numeric
    '    'Dim Status As Object = View.GetRowCellValue(e.RowHandle, colStatus)
    '    'If Not IsDBNull(Status) Then
    '    '    If Not IsNumeric(Status) Then
    '    '        If Status <> "" Then
    '    '            e.Valid = False
    '    '            View.SetColumnError(colStatus, "The Status and PO_LineNum must be numeric")
    '    '        End If
    '    '    End If
    '    'End If

    '    'POandLineNumber must be numeric
    '    'Dim PO As Object = View.GetRowCellValue(e.RowHandle, colPOandLineNum)
    '    'If Not IsDBNull(PO) Then
    '    '    If Not IsNumeric(PO) Then
    '    '        If PO <> "" Then
    '    '            e.Valid = False
    '    '            View.SetColumnError(colStatus, "The PO_LineNum and Status must be numeric")
    '    '        End If
    '    '    End If
    '    'End If

    'End Sub

    Private Sub GridView1_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles GridView1.InvalidRowException
        'Suppress displaying the error message box 
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub btnVendor_Click(sender As Object, e As EventArgs) Handles btnVendor.Click
        Dim frmCalibrationVendor As New Vendor
        frmCalibrationVendor.ShowDialog()
    End Sub

    Private Sub btnMfr_Click(sender As Object, e As EventArgs) Handles btnMfr.Click
        Dim frmManufacturer As New Manufacturer
        frmManufacturer.ShowDialog()
    End Sub

    Private Sub btnToolAssignment_Click(sender As Object, e As EventArgs) Handles btnToolAssign.Click
        Dim frmToolAssign As New Tool_Assignment
        frmToolAssign.ShowDialog()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AddOrEditBtn = "Add"
        Dim frmAddNewTool As New AddNewTool
        frmAddNewTool.ShowDialog()
    End Sub

    Private Sub btnEditTool_Click(sender As Object, e As EventArgs) Handles btnEditTool.Click

        ToolIdToEdit = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RecordID")

        AddOrEditBtn = "Edit"

        Dim frmAddNewTool As New AddNewTool
        frmAddNewTool.ShowDialog()
    End Sub

    Private Sub btnAdminUsers_Click(sender As Object, e As EventArgs) Handles btnAdminUsers.Click
        Dim frmAdmin As New AdminUsers
        frmAdmin.ShowDialog()
    End Sub

    Private Sub ExitAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitAppToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GeneralToolReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralToolReportToolStripMenuItem.Click

        ToolIdToEdit = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RecordID")

        Dim frmToolsReport As New frmCalibDueAssignTo
        frmToolsReport.ShowDialog()
    End Sub

    Private Sub CalibrationRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalibrationRecordsToolStripMenuItem.Click

        ToolIdToEdit = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RecordID")

        Dim frmToolsCalibrationReport As New frmCalibrationRecordsReport
        frmToolsCalibrationReport.ShowDialog()
    End Sub

    Private Sub btnToolIssues_Click(sender As Object, e As EventArgs) Handles btnToolIssues.Click

        ToolIdToEdit = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RecordID")
        ToolIDMainScreen = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ToolID")

        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Description")) Then
            DescriptionMainScreen = ""
        Else
            DescriptionMainScreen = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Description")
        End If

        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NextCalibrationDt")) Then
            NextCalibDateMainScreen = ""
        Else
            NextCalibDateMainScreen = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NextCalibrationDt")
        End If


        Dim frmToolIssues As New ToolIssues
        frmToolIssues.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'GetData()
        ReloadGridData()
    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle

        Dim assignedTo As String
        Dim nextCalibDate As Date
        Dim I As Integer
        Dim View As GridView = sender
        'Dim DataRowCount As Integer = GridView1.DataRowCount

        'TOOLS THAT NEED CALIBRATION - COLORED RED
        'For I = 0 To DataRowCount - 1
        'If IsDBNull(GridView1.GetRowCellValue(I, colNextCalibrationDt)) Then
        If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, colNextCalibrationDt)) Then
            'Nothing
        Else
            'nextCalibDate = GridView1.GetRowCellValue(I, colNextCalibrationDt)
            nextCalibDate = GridView1.GetRowCellValue(e.RowHandle, colNextCalibrationDt)

            'Set to red the rows that have next calibration date equal or smaller than today's date and therefore need to be calibrated
            If nextCalibDate <= Today.Date Then
                If (e.RowHandle >= 0) Then
                    e.Appearance.BackColor = Color.Red
                End If
                e.HighPriority = True   'override any other formatting
            End If
        End If
        'Next


        'ASSIGNED TOOLS NOT YET RETURNED - COLORED BLUE
        If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, colAssignedTo)) Then
            'Nothing
        Else
            assignedTo = GridView1.GetRowCellValue(e.RowHandle, colAssignedTo)

            'Set to blue the rows that have AssignedTo assigned to someone
            If assignedTo <> "Not Issued" Then
                If assignedTo <> "" Then
                    If (e.RowHandle >= 0) Then
                        e.Appearance.BackColor = Color.LightBlue
                    End If
                    e.HighPriority = True   'override any other formatting
                End If
            End If
        End If



        'Example I may need in the future
        '-------------------------------------------------------------------------------------------------------------------

        'Dim quantity As Integer = Convert.ToInt32(MyGridView.GetRowCellValue(e.RowHandle, "QuantityField"))


        'Another Example I may need in the future
        '-------------------------------------------------------------------------------------------------------------------
        'Dim View As GridView = sender
        'If (e.RowHandle >= 0) Then
        '    Dim CumulativeElapsed As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("CumulativeElap"))
        '    Dim Standard As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StdTime"))

        '    If CumulativeElapsed > Standard Then
        '        e.Appearance.BackColor = Color.Yellow
        '    End If

        'End If

    End Sub


    'This is to disallow editing in existing rows(and allow to create a new row)
    Private Sub GridView1_ShowingEditor(sender As Object, e As CancelEventArgs) Handles GridView1.ShowingEditor

        Dim rowHandle As Integer = GridView1.FocusedRowHandle
        If GridView1.FocusedRowHandle >= 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim ToolIdToDelete As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RecordID")

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the selected record?", "Title", MessageBoxButtons.YesNo)
        If (result = DialogResult.Yes) Then
            u.ExecuteSQL(SqlConnection1, "Delete From tblToolCalibration Where RecordID = '" & ToolIdToDelete & "'")
            ReloadGridData()
            MsgBox("Record has been deleted.")
        Else
            'Nothing
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        GridControl1.ExportToXlsx("C:\Temp\FilteredGridExport.xlsx")
        'MsgBox("Grid has been exported to C:\temp\FilteredGridExport.xlsx.")


        Dim Path As String = "C:\Temp\FilteredGridExport.xlsx"
        Dim Excel As Excel.Application = New Excel.Application
        Excel.DisplayAlerts = False
        Excel.Visible = True
        Dim WorkBook As Excel.Workbook = Excel.Workbooks.Open(Path)
    End Sub





    'da = New SqlClient.SqlDataAdapter("Select RecordID, ToolID From tblToolCalibration", SqlConnection1)
    'da.Fill(ds, "fillTable")

    'Dim x As Integer = 0

    'While x <= ds.Tables("fillTable").Rows.Count - 1
    '   Dim recordIDWhile As String = ds.Tables("fillTable").Rows(x).Item("RecordID")
    '   Dim toolIDWhile As String = ds.Tables("fillTable").Rows(x).Item("ToolID")

    '        u.ExecuteSQL(SqlConnection1, "Update tblToolIssues Set ToolIDFromToolCalibrationTbl = '" & toolIDWhile & "' Where ToolRecordID = '" & recordIDWhile & "'")
    '        x = x + 1
    'End While
    '    x = 0





    'Private Sub GridView1_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView1.RowUpdated
    '    Dim test As Integer = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ToolID")
    '    If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ToolID")) Or GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ToolID") Is Nothing Then
    '        MsgBox("Enter Tool ID")
    '        Exit Sub
    '    End If
    'End Sub


    'Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow

    '    Dim view As GridView = TryCast(sender, GridView)
    '    view.SetRowCellValue(e.RowHandle, view.Columns(0), 1)
    '    view.SetRowCellValue(e.RowHandle, view.Columns(1), 2)
    '    view.SetRowCellValue(e.RowHandle, view.Columns(2), 3)

    'End Sub

End Class
