Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class AddNewTool
    Private cmdSql As SqlCommand
    Public ExitSubIfErrors As String
    Public lastCalibDateEdit As String
    Public purchasedDateEdit As String
    Public lastCalibDateCreate As String
    Public purchasedDateCreate As String
    Public LastCalibDateWasChanged As String
    Public CalibDateInCreateTool As String
    Public DateCalibratedEdit As String
    Public DateCalibratedCreate As String

    Public daOracle As OracleDataAdapter
    Public dsOracle As DataSet
    Dim da As SqlClient.SqlDataAdapter
    Dim ds As New DataSet

    Private Sub AddNewTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SqlConnection1.ConnectionString = sqlStringTool


        'Set last calibration date and purchased date to one without the day name
        dtpLastCalibDtEdit.CustomFormat = "MMM-dd-yyyy"
        dtpLastCalibDtEdit.Format = DateTimePickerFormat.Custom

        dtpLastCalibDtCreate.CustomFormat = "MMM-dd-yyyy"
        dtpLastCalibDtCreate.Format = DateTimePickerFormat.Custom

        dtpPurchasedDtEdit.CustomFormat = "MMM-dd-yyyy"
        dtpPurchasedDtEdit.Format = DateTimePickerFormat.Custom

        dtpPurchasedDtCreate.CustomFormat = "MMM-dd-yyyy"
        dtpPurchasedDtCreate.Format = DateTimePickerFormat.Custom

        'Set datetimepickers to empty
        dtpLastCalibDtCreate.CustomFormat = " "
        dtpLastCalibDtCreate.Format = DateTimePickerFormat.Custom

        dtpPurchasedDtCreate.CustomFormat = " "
        dtpPurchasedDtCreate.Format = DateTimePickerFormat.Custom


        Select Case AddOrEditBtn

            Case "Add"
                AddBtnClick()

            Case "Edit"
                EditBtnClick()

        End Select


        LastCalibDateWasChanged = ""
        'ToolIdToEdit = Nothing

    End Sub

    Private Sub EditBtnClick()

        btnCreate.Visible = False
        BtnEdit.Visible = True
        txtDivisionEdit.Visible = True
        cbDivisionCreate.Visible = False
        txtDeptEdit.Visible = True
        cbDeptCreate.Visible = False
        cbIntervalEdit.Visible = True
        cbCalibIntervalCreate.Visible = False
        cbVendorEdit.Visible = True
        cbCalibVendorCreate.Visible = False

        'cbAssignedToEdit.Visible = True
        'cbAssignedToCreate.Visible = False
        cbAssignedToEdit.Visible = False
        cbAssignedToCreate.Visible = False

        cbStatusEdit.Visible = True
        cbStatusCreate.Visible = False
        cbMfrEdit.Visible = True
        cbManufacturerCreate.Visible = False
        txtToolID.ReadOnly = True
        dtpLastCalibDtCreate.Visible = False
        dtpLastCalibDtEdit.Visible = True
        dtpPurchasedDtCreate.Visible = False
        dtpPurchasedDtEdit.Visible = True


        If IsCalgary <> "Yes" Then

            lblDivision.BackColor = Color.Red
            lblDept.BackColor = Color.Red
            lblToolID.BackColor = Color.Red
            lblInterval.BackColor = Color.Red
            lblStatus.BackColor = Color.Red

            lblNomValue.Enabled = False
            txtNomValue.Enabled = False
            lblNomValueTwo.Enabled = False
            txtNomValueTwo.Enabled = False
            lblNomValueThree.Enabled = False
            txtNomValueThree.Enabled = False
            lblNomValueFour.Enabled = False
            txtNomValueFour.Enabled = False
            lblNomValueFive.Enabled = False
            txtNomValueFive.Enabled = False
            lblNomValueSix.Enabled = False
            txtNomValueSix.Enabled = False
            lblNomValueSeven.Enabled = False
            txtNomValueSeven.Enabled = False
            txtAisle.Visible = False
            lblAisle.Visible = False

        ElseIf IsCalgary = "Yes" Then

            lblDivision.BackColor = Color.Red
            lblToolID.BackColor = Color.Red
            lblACType.BackColor = Color.Red
            lblAisle.BackColor = Color.Red
            lblShelf.BackColor = Color.Red
            lblBin.BackColor = Color.Red

            'Commented next 3 lines to get rid of the code related to "IsCalgary"
            '    lblNomValue.BackColor = Color.Red
            '    lblToleranceMinus.BackColor = Color.Red
            '    lblTolerancePlus.BackColor = Color.Red

            cbACType.Items.Clear()
            da = New SqlClient.SqlDataAdapter("Select * From tblCalgaryTypes", SqlConnection1)
            da.Fill(ds, "CalgaryTypes")
            Dim i As Integer = 0

            While i <= ds.Tables("CalgaryTypes").Rows.Count - 1
                Me.cbACType.Items.Add(ds.Tables("CalgaryTypes").Rows(i).Item("Type"))
                i = i + 1
            End While

            ds.Tables("CalgaryTypes").Clear()
            ds.Tables("CalgaryTypes").Dispose()

        End If


        'Dim sqlString As String = " where RecordID = '" & ToolIdToEdit & "'"
        'daEdit.SelectCommand.CommandText() += sqlString
        'daEdit.Fill(DsEdit1.tblToolCalibration)

        'txtDivision.DataBindings.Add("Text", bsEdit, "Division")
        'txtDept.DataBindings.Add("Text", bsEdit, "Dept")
        'txtToolID.DataBindings.Add("Text", bsEdit, "ToolID")
        'txtSerial.DataBindings.Add("Text", bsEdit, "SerialNum")
        'txtDesc.DataBindings.Add("Text", bsEdit, "Description")
        'txtAssignedTo.DataBindings.Add("Text", bsEdit, "AssignedTo")
        'txtACType.DataBindings.Add("Text", bsEdit, "ACType")
        'txtAisle.DataBindings.Add("Text", bsEdit, "Aisle")
        'txtShelf.DataBindings.Add("Text", bsEdit, "Shelf")
        'txtBin.DataBindings.Add("Text", bsEdit, "BinCal")
        'txtComment.DataBindings.Add("Text", bsEdit, "Comment")
        'txtLastCalibDt.DataBindings.Add("Text", bsEdit, "LastCalibrationDt")
        'cbInterval.DataBindings.Add("Text", bsEdit, "CalibrationInterval")
        'txtNumIntervals.DataBindings.Add("Text", bsEdit, "NumOfIntervals")
        'cbVendor.DataBindings.Add("Text", bsEdit, "CalibrationVendor")
        'txtMaintenanceComments.DataBindings.Add("Text", bsEdit, "MaintenanceComments")
        'txtAssetNum.DataBindings.Add("Text", bsEdit, "AssetNum")
        'txtModelNum.DataBindings.Add("Text", bsEdit, "ModelNum")
        'cbMfr.DataBindings.Add("Text", bsEdit, "Manufacturer")
        'txtUOM.DataBindings.Add("Text", bsEdit, "UOM")
        'txtPurchased.DataBindings.Add("Text", bsEdit, "Purchased")
        'txtTolerancePlus.DataBindings.Add("Text", bsEdit, "TolerancePlus")
        'txtToleranceMinus.DataBindings.Add("Text", bsEdit, "ToleranceMinus")
        'txtStatus.DataBindings.Add("Text", bsEdit, "Status")
        'txtPOLineNum.DataBindings.Add("Text", bsEdit, "POandLineNum")
        'txtWONum.DataBindings.Add("Text", bsEdit, "WONum")
        'txtIssueNum.DataBindings.Add("Text", bsEdit, "IssueNum")
        'txtIssuedTo.DataBindings.Add("Text", bsEdit, "IssuedTo")
        'txtContainer.DataBindings.Add("Text", bsEdit, "Container")


        'Fill textboxes with data
        Try
            Using cmd As SqlCommand = New SqlCommand("SELECT * FROM tblToolCalibration WHERE RecordID = '" & ToolIdToEdit & "'")
                cmd.CommandType = CommandType.Text
                cmd.Connection = SqlConnection1
                SqlConnection1.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    sdr.Read()
                    txtDivisionEdit.Text = sdr("Division").ToString()
                    txtDeptEdit.Text = sdr("Dept").ToString()
                    txtToolID.Text = sdr("ToolID").ToString()
                    'cbAssignedToEdit.Text = sdr("AssignedTo").ToString()
                    txtSerial.Text = sdr("SerialNum").ToString()
                    txtDesc.Text = sdr("Description").ToString()
                    cbACType.Text = sdr("ACType").ToString()
                    txtLocation.Text = sdr("Location").ToString()
                    txtAisle.Text = sdr("Aisle").ToString()
                    txtShelf.Text = sdr("Shelf").ToString()
                    txtBin.Text = sdr("BinCal").ToString()
                    txtComment.Text = sdr("Comment").ToString()


                    lastCalibDateEdit = sdr("LastCalibrationDt").ToString()
                    If lastCalibDateEdit = "" Then
                        'Nothing
                        dtpLastCalibDtEdit.CustomFormat = " "
                        dtpLastCalibDtEdit.Format = DateTimePickerFormat.Custom
                    Else
                        dtpLastCalibDtEdit.Value = lastCalibDateEdit
                    End If

                    cbIntervalEdit.Text = sdr("CalibrationInterval").ToString()
                    'txtNumIntervals.Text = sdr("NumOfIntervals").ToString()
                    cbVendorEdit.Text = sdr("CalibrationVendor").ToString()
                    txtMaintenanceComments.Text = sdr("MaintenanceComments").ToString()
                    txtAssetNum.Text = sdr("AssetNum").ToString()
                    txtModelNum.Text = sdr("ModelNum").ToString()
                    cbMfrEdit.Text = sdr("Manufacturer").ToString()
                    cbUOM.Text = sdr("UOM").ToString()

                    purchasedDateEdit = sdr("Purchased").ToString()
                    If purchasedDateEdit = "" Then
                        'Nothing
                        dtpPurchasedDtEdit.CustomFormat = " "
                        dtpPurchasedDtEdit.Format = DateTimePickerFormat.Custom
                    Else
                        dtpPurchasedDtEdit.Value = purchasedDateEdit
                    End If

                    txtTolerancePlus.Text = sdr("TolerancePlus").ToString()
                    txtToleranceMinus.Text = sdr("ToleranceMinus").ToString()
                    cbStatusEdit.Text = sdr("Status").ToString()
                    txtPOLineNum.Text = sdr("POandLineNum").ToString()
                    txtWONum.Text = sdr("WONum").ToString()
                    txtIssueNum.Text = sdr("IssueNum").ToString()
                    'txtIssuedTo.Text = sdr("IssuedTo").ToString()
                    txtContainer.Text = sdr("Container").ToString()
                    If IsDBNull(sdr("PreventativeMaintenance")) Then
                        'Nothing
                    ElseIf sdr("PreventativeMaintenance") = True Then
                        chkPreventative.Checked = True
                    End If

                    If IsCalgary = "Yes" Then
                        txtNomValue.Text = sdr("NomValue").ToString()
                        txtNomValueTwo.Text = sdr("NomValueTwo").ToString()
                        txtNomValueThree.Text = sdr("NomValueThree").ToString()
                        txtNomValueFour.Text = sdr("NomValueFour").ToString()
                        txtNomValueFive.Text = sdr("NomValueFive").ToString()
                        txtNomValueSix.Text = sdr("NomValueSix").ToString()
                        txtNomValueSeven.Text = sdr("NomValueSeven").ToString()
                    End If

                End Using

                SqlConnection1.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occured while trying to fill the textboxes and dropdowns of the edit page." & vbLf & vbLf & ex.Message)
        End Try

    End Sub

    Private Sub AddBtnClick()

        btnCreate.Visible = True
        BtnEdit.Visible = False
        txtDivisionEdit.Visible = False
        cbDivisionCreate.Visible = True
        txtDeptEdit.Visible = False
        cbDeptCreate.Visible = True
        cbIntervalEdit.Visible = False
        cbCalibIntervalCreate.Visible = True
        cbVendorEdit.Visible = False
        cbCalibVendorCreate.Visible = True

        'cbAssignedToEdit.Visible = False
        'cbAssignedToCreate.Visible = True
        cbAssignedToEdit.Visible = False
        cbAssignedToCreate.Visible = False

        cbStatusEdit.Visible = False
        cbStatusCreate.Visible = True
        cbMfrEdit.Visible = False
        cbManufacturerCreate.Visible = True
        txtToolID.ReadOnly = False
        dtpLastCalibDtCreate.Visible = True
        dtpLastCalibDtEdit.Visible = False
        dtpPurchasedDtCreate.Visible = True
        dtpPurchasedDtEdit.Visible = False


        If IsCalgary <> "Yes" Then

            lblDivision.BackColor = Color.Red
            lblDept.BackColor = Color.Red
            lblToolID.BackColor = Color.Red
            lblInterval.BackColor = Color.Red
            lblStatus.BackColor = Color.Red

            lblNomValue.Enabled = False
            txtNomValue.Enabled = False
            lblNomValueTwo.Enabled = False
            txtNomValueTwo.Enabled = False
            lblNomValueThree.Enabled = False
            txtNomValueThree.Enabled = False
            lblNomValueFour.Enabled = False
            txtNomValueFour.Enabled = False
            lblNomValueFive.Enabled = False
            txtNomValueFive.Enabled = False
            lblNomValueSix.Enabled = False
            txtNomValueSix.Enabled = False
            lblNomValueSeven.Enabled = False
            txtNomValueSeven.Enabled = False
            txtAisle.Visible = False
            lblAisle.Visible = False

        ElseIf IsCalgary = "Yes" Then

            lblDivision.BackColor = Color.Red
            lblToolID.BackColor = Color.Red
            lblACType.BackColor = Color.Red
            lblAisle.BackColor = Color.Red
            lblShelf.BackColor = Color.Red
            lblBin.BackColor = Color.Red
            'Commented next 3 lines to get rid of the code related to "IsCalgary"
            '    lblNomValue.BackColor = Color.Red
            '    lblToleranceMinus.BackColor = Color.Red
            '    lblTolerancePlus.BackColor = Color.Red
        End If


        Dim cmdSql As New SqlCommand
        Dim dr As SqlDataReader
        SqlConnection1.Open()
        cmdSql.Connection = SqlConnection1

        'Get combo boxes drop-down items
        cmdSql.CommandText = "SELECT Items FROM tblDropDownItems WHERE ColumnName = 'Division' and ColumnName is not null and ColumnName != ' '"
        dr = cmdSql.ExecuteReader()
        Do While dr.Read = True
            cbDivisionCreate.Items.Add(dr.GetString(0))
        Loop

        cmdSql.Parameters.Clear()
        dr.Close()
        cmdSql.CommandText = "SELECT Items FROM tblDropDownItems WHERE ColumnName = 'Department' and ColumnName is not null and ColumnName != ' '"
        dr = cmdSql.ExecuteReader()
        Do While dr.Read = True
            cbDeptCreate.Items.Add(dr.GetString(0))
        Loop

        cmdSql.Parameters.Clear()
        dr.Close()
        cmdSql.CommandText = "SELECT Items FROM tblDropDownItemsCalibInterval WHERE ColumnName = 'CalibrationInterval' and ColumnName is not null and ColumnName != ' '"
        dr = cmdSql.ExecuteReader()
        Do While dr.Read = True
            cbCalibIntervalCreate.Items.Add(dr.GetString(0))
        Loop

        cmdSql.Parameters.Clear()
        dr.Close()
        cmdSql.CommandText = "Select Distinct CalibrationVendor from tblCalibrationVendor Where CalibrationVendor is not null and CalibrationVendor != ' ' Order By CalibrationVendor ASC"
        dr = cmdSql.ExecuteReader()
        Do While dr.Read = True
            cbCalibVendorCreate.Items.Add(dr.GetString(0))
        Loop

        'cmdSql.Parameters.Clear()
        'dr.Close()
        'cmdSql.CommandText = "Select Distinct Username from tblToolAssignment Where Username is not null and Username != ' ' Order By Username ASC"
        'dr = cmdSql.ExecuteReader()
        'Do While dr.Read = True
        '    cbAssignedToCreate.Items.Add(dr.GetString(0))
        'Loop


        'Fill AssignedTo with Employees from Oracle database
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
        '    cbAssignedToCreate.Items.Add(drOracle.GetString(0))
        'Loop

        'cmdOracle.Parameters.Clear()
        'drOracle.Close()
        'OracleConnection1.Close()


        cmdSql.Parameters.Clear()
        dr.Close()
        cmdSql.CommandText = "Select Distinct MfrName from tblManufacturerCalibration Where MfrName is not null and MfrName != ' ' Order By MfrName ASC"
        dr = cmdSql.ExecuteReader()
        Do While dr.Read = True
            cbManufacturerCreate.Items.Add(dr.GetString(0))
        Loop


        If IsCalgary = "Yes" Then
            cbACType.Items.Clear()
            cmdSql.Parameters.Clear()
            dr.Close()
            cmdSql.CommandText = "Select Distinct Type From tblCalgaryTypes"
            dr = cmdSql.ExecuteReader()
            Do While dr.Read = True
                cbACType.Items.Add(dr.GetString(0))
            Loop

            'For Calgary, pre-fill Calibration Interval and Status
            cbCalibIntervalCreate.Text = "N - Not Required"
            cbStatusCreate.Text = "N/A"
        End If



        SqlConnection1.Close()

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        'Validate entries
        If ValidateEntries() = False Then
            Exit Sub
        End If


        'Last Calibration Date
        If lastCalibDateCreate = "" Then
            lastCalibDateCreate = "NULL"
        Else
            lastCalibDateCreate = "'" & dtpLastCalibDtCreate.Value & "'"
        End If

        'Purchased Date
        If purchasedDateCreate = "" Then
            purchasedDateCreate = "NULL"
        Else
            purchasedDateCreate = "'" & dtpPurchasedDtCreate.Value & "'"
        End If

        'Status
        Dim Status As String = cbStatusCreate.Text
        Dim statusArray() As String = Split(Status)
        Status = statusArray(0)

        'Interval
        Dim Interval As String = cbCalibIntervalCreate.Text
        Dim intervalArray() As String = Split(Interval)
        Interval = intervalArray(0)
        If Interval = "Calibration" Then
            Interval = "Calibration Not Required"
        End If

        'Preventative Maintenance
        Dim PreventativeMaintCreate As String = ""
        If chkPreventative.Checked = True Then
            PreventativeMaintCreate = 1
        Else
            PreventativeMaintCreate = 0
        End If

        Try
            'u.ExecuteSQL(SqlConnection1, "INSERT INTO tblToolCalibration (Division, Dept, ToolID, SerialNum, Description, ACType, Aisle, Shelf, BinCal, Comment, LastCalibrationDt, CalibrationInterval, CalibrationVendor, MaintenanceComments, AssetNum, ModelNum, Manufacturer, UOM, Purchased, TolerancePlus, ToleranceMinus, Status, POandLineNum, WONum, IssueNum, Container) Values ('" & Me.cbDivisionCreate.Text & "', '" & Me.cbDeptCreate.Text & "', '" & Me.txtToolID.Text & "', '" & Me.txtSerial.Text & "', '" & Me.txtDesc.Text & "', '" & Me.txtACType.Text & "', '" & Me.txtAisle.Text & "', '" & Me.txtShelf.Text & "', '" & Me.txtBin.Text & "', '" & Me.txtComment.Text & "', " & lastCalibDateCreate & ", '" & Me.cbCalibIntervalCreate.Text & "', '" & Me.cbCalibVendorCreate.Text & "', '" & Me.txtMaintenanceComments.Text & "', '" & Me.txtAssetNum.Text & "', '" & Me.txtModelNum.Text & "', '" & Me.cbManufacturerCreate.Text & "', '" & Me.txtUOM.Text & "', " & purchasedDateCreate & ", '" & Me.txtTolerancePlus.Text & "', '" & Me.txtToleranceMinus.Text & "', '" & cbStatusCreate.Text & "', '" & Me.txtPOLineNum.Text & "', '" & Me.txtWONum.Text & "', '" & Me.txtIssueNum.Text & "', '" & Me.txtContainer.Text & "')")
            u.ExecuteSQL(SqlConnection1, "INSERT INTO tblToolCalibration (Division, Dept, ToolID, SerialNum, Description, ACType, Aisle, Shelf, BinCal, Comment, LastCalibrationDt, CalibrationInterval, CalibrationVendor, MaintenanceComments, AssetNum, ModelNum, Manufacturer, UOM, Purchased, TolerancePlus, ToleranceMinus, Status, POandLineNum, WONum, IssueNum, Container,NomValue,NomValueTwo,NomValueThree,NomValueFour,NomValueFive,NomValueSix,NomValueSeven,PreventativeMaintenance,Location) Values ('" & Me.cbDivisionCreate.Text & "', '" & Me.cbDeptCreate.Text & "', '" & convertQuotes(Me.txtToolID.Text) & "', '" & convertQuotes(Me.txtSerial.Text) & "', '" & convertQuotes(Me.txtDesc.Text) & "', '" & convertQuotes(Me.cbACType.Text) & "', '" & convertQuotes(Me.txtAisle.Text) & "', '" & convertQuotes(Me.txtShelf.Text) & "', '" & convertQuotes(Me.txtBin.Text) & "', '" & convertQuotes(Me.txtComment.Text) & "', " & lastCalibDateCreate & ", '" & Interval & "', '" & Me.cbCalibVendorCreate.Text & "', '" & convertQuotes(Me.txtMaintenanceComments.Text) & "', '" & convertQuotes(Me.txtAssetNum.Text) & "', '" & convertQuotes(Me.txtModelNum.Text) & "', '" & Me.cbManufacturerCreate.Text & "', '" & convertQuotes(cbUOM.Text) & "', " & purchasedDateCreate & ", '" & convertQuotes(Me.txtTolerancePlus.Text) & "', '" & convertQuotes(Me.txtToleranceMinus.Text) & "', '" & Status & "', '" & convertQuotes(Me.txtPOLineNum.Text) & "', '" & convertQuotes(Me.txtWONum.Text) & "', '" & convertQuotes(Me.txtIssueNum.Text) & "', '" & convertQuotes(Me.txtContainer.Text) & "', '" & convertQuotes(Me.txtNomValue.Text) & "', '" & convertQuotes(Me.txtNomValueTwo.Text) & "', '" & convertQuotes(Me.txtNomValueThree.Text) & "', '" & convertQuotes(Me.txtNomValueFour.Text) & "', '" & convertQuotes(Me.txtNomValueFive.Text) & "', '" & convertQuotes(Me.txtNomValueSix.Text) & "', '" & convertQuotes(Me.txtNomValueSeven.Text) & "'," & PreventativeMaintCreate & ", '" & u.FTM(txtLocation.Text) & "')")
            If u.executeSQLError = False Then


                MsgBox("Tool Created")
            Else
                MsgBox("Tool Not Created")
            End If
        Catch ex As SystemException
            MessageBox.Show("An error occured while inserting the new record to the database." & vbLf & vbLf & ex.Message)
        End Try


        'Calculate Next Calibration Date
        da = New SqlClient.SqlDataAdapter("Select TOP 1 RecordID From tblToolCalibration Order By RecordID Desc", SqlConnection1)
        da.Fill(ds, "RecordIDForCreate")
        If ds.Tables("RecordIDForCreate").Rows.Count > 0 Then
            ToolIdToEdit = ds.Tables("RecordIDForCreate").Rows(0).Item("RecordID")
            ds.Tables("RecordIDForCreate").Clear()
            ds.Tables("RecordIDForCreate").Dispose()
        End If

        LastAndNextCalibrationDtForEditScreen()


        'Refresh the grid in the Tools page
        Tools.ReloadGridData()

        ClearTextAndCombo()

    End Sub

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function

    Private Function ValidateEntries()

        Dim ValueReturned As String = ""
        Dim errors As String = ""
        Dim numberOfDecimalsTolMinus As String = ""
        Dim numberOfDecimalsTolPlus As String = ""


        'If AddOrEditBtn = "Add" Then

        'Check the same ToolID does not already exists
        If AddOrEditBtn = "Add" Then
            da = New SqlClient.SqlDataAdapter("Select ToolID From tblToolCalibration Where ToolID = '" & txtToolID.Text & "'", SqlConnection1)
            da.Fill(ds, "ExistToolID")
            If ds.Tables("ExistToolID").Rows.Count > 0 Then
                errors = "The Tool ID you entered already exists"
                ds.Tables("ExistToolID").Clear()
                ds.Tables("ExistToolID").Dispose()
            End If
        End If


        'Validation for Calgary users
        If IsCalgary = "Yes" Then
            If AddOrEditBtn = "Add" Then
                If Me.cbDivisionCreate.Text = "" Then
                    errors = errors + "Your are required to enter a division." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtToolID.Text = "" Then
                    errors = errors + "You are required to enter a tool ID." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.cbACType.Text = "" Then
                    errors = errors + "Your are required to enter a Type." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtAisle.Text = "" Then
                    errors = errors + "Your are required to enter a Aisle." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtShelf.Text = "" Then
                    errors = errors + "Your are required to enter a Shelf." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtBin.Text = "" Then
                    errors = errors + "Your are required to enter a Bin." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

            Else
                If Me.txtDivisionEdit.Text = "" Then
                    errors = errors + "You are required to enter a Division." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtToolID.Text = "" Then
                    errors = errors + "You are required to enter a tool ID." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.cbACType.Text = "" Then
                    errors = errors + "Your are required to enter a Type." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtAisle.Text = "" Then
                    errors = errors + "Your are required to enter a Aisle." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtShelf.Text = "" Then
                    errors = errors + "Your are required to enter a Shelf." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtBin.Text = "" Then
                    errors = errors + "Your are required to enter a Bin." & Environment.NewLine & "" & Environment.NewLine & ""
                End If
            End If

        Else

            If AddOrEditBtn = "Add" Then
                If Me.cbDivisionCreate.Text = "" Then
                    errors = errors + "Your are required to enter a division." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.cbDeptCreate.Text = "" Then
                    errors = errors + "You are required to enter a department." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtToolID.Text = "" Then
                    errors = errors + "You are required to enter a tool ID." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                'If Me.cbAssignedToCreate.Text = "" Then
                '    errors = errors + "You are required to enter assigned to." & Environment.NewLine & "" & Environment.NewLine & ""
                'End If

                If Me.cbCalibIntervalCreate.Text = "" Then
                    errors = errors + "Your are required to enter an interval." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If cbStatusCreate.Text = "" Then
                    errors = errors + "You are required to enter the status." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

            Else
                If Me.txtDivisionEdit.Text = "" Then
                    errors = errors + "Your are required to enter a division." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtDeptEdit.Text = "" Then
                    errors = errors + "You are required to enter a department." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.txtToolID.Text = "" Then
                    errors = errors + "You are required to enter a tool ID." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If Me.cbIntervalEdit.Text = "" Then
                    errors = errors + "Your are required to enter an interval." & Environment.NewLine & "" & Environment.NewLine & ""
                End If

                If cbStatusEdit.Text = "" Then
                    errors = errors + "You are required to enter the status." & Environment.NewLine & "" & Environment.NewLine & ""
                End If
            End If

        End If

            'End If



            '---------Commented next block of code to get rid of the code related to "IsCalgary"--------------------------------------------------------------------
            'If IsCalgary = "Yes" Then

            '    'If Calgary, check they they have Nominal Value, Tolerance Minus and Tolerance Plus
            '    If txtNomValue.Text = "" Or txtToleranceMinus.Text = "" Or txtTolerancePlus.Text = "" Then

            '        errors = errors + "You are required to enter Tolerance -, Tolerance +, and at least one nominal value." & Environment.NewLine & "" & Environment.NewLine & ""

            '    Else
            '        'Make sure they enter a number in the Tolerance Minus and Tolerance Plus fields, and in the Tolerance fields
            '        Dim TolMinusValue As Decimal
            '        If Decimal.TryParse(txtToleranceMinus.Text, TolMinusValue) Then
            '            txtToleranceMinus.Text = TolMinusValue
            '        Else
            '            errors = errors + " Please enter a number in the Tolerance - field."
            '        End If

            '        Dim TolPlusValue As Decimal
            '        If Decimal.TryParse(txtTolerancePlus.Text, TolPlusValue) Then
            '            txtTolerancePlus.Text = TolPlusValue
            '        Else
            '            errors = errors + " Please enter a number in the Tolerance + field."
            '        End If

            '        Dim NomValueValue As Decimal
            '        If Decimal.TryParse(txtNomValue.Text, NomValueValue) Then
            '            txtNomValue.Text = NomValueValue
            '        Else
            '            errors = errors + " Please enter a number in the Nominal Value field."
            '        End If

            '        'Validate that the numbers entered in the ToleranceMinus, TolerancePlus And NominalValue fields have the same number of decimal places
            '        Dim Position As Integer = Convert.ToInt16(Convert.ToString(txtToleranceMinus.Text).IndexOf("."))
            '        numberOfDecimalsTolMinus = txtToleranceMinus.Text.Substring(Position + 1)

            '        Dim PositionTwo As Integer = Convert.ToInt16(Convert.ToString(txtTolerancePlus.Text).IndexOf("."))
            '        numberOfDecimalsTolPlus = txtTolerancePlus.Text.Substring(PositionTwo + 1)

            '        Dim PositionThree As Integer = Convert.ToInt16(Convert.ToString(txtNomValue.Text).IndexOf("."))
            '        Dim numberOfDecimalsNomValue As String = txtNomValue.Text.Substring(PositionThree + 1)

            '        If numberOfDecimalsTolMinus.Length <> numberOfDecimalsTolPlus.Length Then
            '            errors = errors + "Please enter the same number of decimals in Tolerance Minus and Tolerance Plus fields."
            '        ElseIf numberOfDecimalsTolMinus.Length <> numberOfDecimalsNomValue.Length Then
            '            errors = errors + "Please enter the same number of decimals in Nominal Value as in Tolerance Minus and Tolerance Plus fields."
            '        End If
            '    End If

            '    'If all the other nominal values fields contain something make sure it is a number
            '    If txtNomValueTwo.Text <> "" Then
            '        Dim NomValueTwoValue As Decimal
            '        If Decimal.TryParse(txtNomValueTwo.Text, NomValueTwoValue) Then
            '            txtNomValueTwo.Text = NomValueTwoValue
            '        Else
            '            errors = errors + "Please enter a number in the Nominal Value Two field."
            '        End If

            '        'Validate that the numbers entered in the ToleranceMinus, TolerancePlus And NominalValueTwo fields have the same number of decimal places
            '        Dim Position As Integer = Convert.ToInt16(Convert.ToString(txtNomValueTwo.Text).IndexOf("."))
            '        Dim numberOfDecimalsNomValueTwo As String = txtNomValueTwo.Text.Substring(Position + 1)

            '        If numberOfDecimalsTolMinus.Length <> numberOfDecimalsNomValueTwo.Length Then
            '            errors = errors + "Please enter the same number of decimals in Nominal Value Two as in Tolerance Minus and Tolerance Plus fields."
            '        End If
            '    End If

            '    If txtNomValueThree.Text <> "" Then
            '        Dim NomValueThreeValue As Decimal
            '        If Decimal.TryParse(txtNomValueThree.Text, NomValueThreeValue) Then
            '            txtNomValueThree.Text = NomValueThreeValue
            '        Else
            '            errors = errors + "Please enter a number in the Nominal Value Three field."
            '        End If

            '        'Validate that the numbers entered in the ToleranceMinus, TolerancePlus And NominalValueThree fields have the same number of decimal places
            '        Dim Position As Integer = Convert.ToInt16(Convert.ToString(txtNomValueThree.Text).IndexOf("."))
            '        Dim numberOfDecimalsNomValueThree As String = txtNomValueThree.Text.Substring(Position + 1)

            '        If numberOfDecimalsTolMinus.Length <> numberOfDecimalsNomValueThree.Length Then
            '            errors = errors + "Please enter the same number of decimals in Nominal Value Three as in Tolerance Minus and Tolerance Plus fields."
            '        End If
            '    End If

            '    If txtNomValueFour.Text <> "" Then
            '        Dim NomValueFourValue As Decimal
            '        If Decimal.TryParse(txtNomValueFour.Text, NomValueFourValue) Then
            '            txtNomValueFour.Text = NomValueFourValue
            '        Else
            '            errors = errors + "Please enter a number in the Nominal Value Four field."
            '        End If

            '        'Validate that the numbers entered in the ToleranceMinus, TolerancePlus And NominalValueFour fields have the same number of decimal places
            '        Dim Position As Integer = Convert.ToInt16(Convert.ToString(txtNomValueFour.Text).IndexOf("."))
            '        Dim numberOfDecimalsNomValueFour As String = txtNomValueFour.Text.Substring(Position + 1)

            '        If numberOfDecimalsTolMinus.Length <> numberOfDecimalsNomValueFour.Length Then
            '            errors = errors + "Please enter the same number of decimals in Nominal Value Four as in Tolerance Minus and Tolerance Plus fields."
            '        End If
            '    End If

            '    If txtNomValueFive.Text <> "" Then
            '        Dim NomValueFiveValue As Decimal
            '        If Decimal.TryParse(txtNomValueFive.Text, NomValueFiveValue) Then
            '            txtNomValueFive.Text = NomValueFiveValue
            '        Else
            '            errors = errors + "Please enter a number in the Nominal Value Five field."
            '        End If

            '        'Validate that the numbers entered in the ToleranceMinus, TolerancePlus And NominalValueFive fields have the same number of decimal places
            '        Dim Position As Integer = Convert.ToInt16(Convert.ToString(txtNomValueFive.Text).IndexOf("."))
            '        Dim numberOfDecimalsNomValueFive As String = txtNomValueFive.Text.Substring(Position + 1)

            '        If numberOfDecimalsTolMinus.Length <> numberOfDecimalsNomValueFive.Length Then
            '            errors = errors + "Please enter the same number of decimals in Nominal Value Five as in Tolerance Minus and Tolerance Plus fields."
            '        End If
            '    End If

            '    If txtNomValueSix.Text <> "" Then
            '        Dim NomValueSixValue As Decimal
            '        If Decimal.TryParse(txtNomValueSix.Text, NomValueSixValue) Then
            '            txtNomValueSix.Text = NomValueSixValue
            '        Else
            '            errors = errors + "Please enter a number in the Nominal Value Six field."
            '        End If

            '        'Validate that the numbers entered in the ToleranceMinus, TolerancePlus And NominalValueSix fields have the same number of decimal places
            '        Dim Position As Integer = Convert.ToInt16(Convert.ToString(txtNomValueSix.Text).IndexOf("."))
            '        Dim numberOfDecimalsNomValueSix As String = txtNomValueSix.Text.Substring(Position + 1)

            '        If numberOfDecimalsTolMinus.Length <> numberOfDecimalsNomValueSix.Length Then
            '            errors = errors + "Please enter the same number of decimals in Nominal Value Six as in Tolerance Minus and Tolerance Plus fields."
            '        End If
            '    End If

            '    If txtNomValueSeven.Text <> "" Then
            '        Dim NomValueSevenValue As Decimal
            '        If Decimal.TryParse(txtNomValueSeven.Text, NomValueSevenValue) Then
            '            txtNomValueSeven.Text = NomValueSevenValue
            '        Else
            '            errors = errors + "Please enter a number in the Nominal Value Seven field."
            '        End If

            '        'Validate that the numbers entered in the ToleranceMinus, TolerancePlus And NominalValueSeven fields have the same number of decimal places
            '        Dim Position As Integer = Convert.ToInt16(Convert.ToString(txtNomValueSeven.Text).IndexOf("."))
            '        Dim numberOfDecimalsNomValueSeven As String = txtNomValueSeven.Text.Substring(Position + 1)

            '        If numberOfDecimalsTolMinus.Length <> numberOfDecimalsNomValueSeven.Length Then
            '            errors = errors + "Please enter the same number of decimals in Nominal Value Seven as in Tolerance Minus and Tolerance Plus fields."
            '        End If
            '    End If

            'End If
            '---------------------------------------------------------------------------------------------------------------------------------------------------




            'Below block of code was already commented out before I commented the "IsCalgary" code
            ''Dim regex As Regex = New Regex("(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$")

            ''If txtLastCalibDt.Text <> "" Then
            ''    Dim dt2 As DateTime
            ''    Dim dtLastCalib = txtLastCalibDt.Text
            ''    Dim dt3 = DateTime.TryParse(dtLastCalib, CultureInfo.InvariantCulture, DateTimeStyles.None, dt2)
            ''    If Not dt3 Then

            ''        'Verify last calibration date is in MM/dd/yyyy format
            ''        'Dim isValidLastCalibDate As Boolean = regex.IsMatch(txtLastCalibDt.Text.Trim)

            ''        'Verify whether entered date Is Valid date
            ''        'Dim dt As DateTime
            ''        'isValidLastCalibDate = DateTime.TryParseExact(txtLastCalibDt.Text, "MM/dd/yyyy", New CultureInfo("en-US"), DateTimeStyles.None, dt)
            ''        'If Not isValidLastCalibDate Then
            ''        MessageBox.Show("Enter last calibration date in mm/dd/yyyy format.")
            ''        ValueReturned = "False"
            ''    End If
            ''End If
            ''If txtPurchased.Text <> "" Then
            ''    Dim dt4 As DateTime
            ''    Dim dtPurchased = txtPurchased.Text
            ''    Dim dt5 = DateTime.TryParse(dtPurchased, CultureInfo.InvariantCulture, DateTimeStyles.None, dt4)
            ''    If Not dt5 Then

            ''        'Verify purchased date is in MM/dd/yyyy format
            ''        'Dim isValidPurchasedDate As Boolean = regex.IsMatch(txtPurchased.Text.Trim)

            ''        'Verify purchased date Is Valid date
            ''        'Dim dt2 As DateTime
            ''        'isValidPurchasedDate = DateTime.TryParseExact(txtPurchased.Text, "MM/dd/yyyy", New CultureInfo("en-US"), DateTimeStyles.None, dt2)
            ''        'If Not isValidPurchasedDate Then
            ''        MessageBox.Show("Enter purchased date in mm/dd/yyyy format.")
            ''        ValueReturned = "False"
            ''    End If
            ''End If


            ''If txtNumIntervals.Text <> "" Then
            ''    If Not IsNumeric(txtNumIntervals.Text) Then
            ''        MessageBox.Show("Enter a number for number of intervals.")
            ''        ValueReturned = "False"
            ''    End If
            ''End If




            If errors <> "" Then
            errors = errors + " Please correct the errors above and submit."
            MsgBox(errors)
            ValueReturned = "False"
        End If


        If ValueReturned = "False" Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub ClearTextAndCombo()
        lastCalibDateCreate = ""
        purchasedDateCreate = ""

        'Clear textboxes and comboboxes
        cbDivisionCreate.SelectedIndex = -1
        cbDeptCreate.SelectedIndex = -1
        txtToolID.Text = ""
        'cbAssignedToCreate.SelectedIndex = -1
        txtSerial.Text = ""
        txtDesc.Text = ""
        cbACType.SelectedIndex = -1
        txtLocation.Text = ""
        txtAisle.Text = ""
        txtShelf.Text = ""
        txtBin.Text = ""
        txtComment.Text = ""
        cbCalibIntervalCreate.SelectedIndex = -1
        'txtNumIntervals.Text = ""
        cbCalibVendorCreate.SelectedIndex = -1
        txtMaintenanceComments.Text = ""
        txtAssetNum.Text = ""
        txtModelNum.Text = ""
        cbManufacturerCreate.SelectedIndex = -1
        cbUOM.SelectedIndex = -1
        txtTolerancePlus.Text = ""
        txtToleranceMinus.Text = ""
        cbStatusCreate.SelectedIndex = -1
        txtPOLineNum.Text = ""
        txtWONum.Text = ""
        txtIssueNum.Text = ""
        'txtIssuedTo.Text = ""
        txtContainer.Text = ""
        txtDivisionEdit.Text = ""
        txtDeptEdit.Text = ""
        cbIntervalEdit.SelectedIndex = -1
        cbVendorEdit.SelectedIndex = -1
        cbMfrEdit.Text = ""
        chkPreventative.Checked = False

        dtpLastCalibDtCreate.CustomFormat = " "
        dtpLastCalibDtCreate.Format = DateTimePickerFormat.Custom

        dtpPurchasedDtCreate.CustomFormat = " "
        dtpPurchasedDtCreate.Format = DateTimePickerFormat.Custom

        txtNomValue.Text = ""
        txtNomValueTwo.Text = ""
        txtNomValueThree.Text = ""
        txtNomValueFour.Text = ""
        txtNomValueFive.Text = ""
        txtNomValueSix.Text = ""
        txtNomValueSeven.Text = ""
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click

        If ValidateEntries() = False Then
            Exit Sub
        End If

        'Dim dtLastCalib As String
        'If txtLastCalibDt.Text <> "" Then
        '    dtLastCalib = "'" & txtLastCalibDt.Text & "'"
        'Else
        '    dtLastCalib = "NULL"
        'End If

        'Dim dtPurchased As String
        'If txtPurchased.Text <> "" Then
        '    dtPurchased = "'" & txtPurchased.Text & "'"
        'Else
        '    dtPurchased = "NULL"
        'End If


        'Last Calibration Date
        If lastCalibDateEdit = "" Then
            lastCalibDateEdit = "NULL"
        Else
            lastCalibDateEdit = "'" & dtpLastCalibDtEdit.Value & "'"
        End If

        'Purchase Date
        If purchasedDateEdit = "" Then
            purchasedDateEdit = "NULL"
        Else
            purchasedDateEdit = "'" & dtpPurchasedDtEdit.Value & "'"
        End If

        'Status
        Dim Status As String = cbStatusEdit.Text
        Dim statusArray() As String = Split(Status)
        Status = statusArray(0)

        'Interval
        Dim Interval As String = cbIntervalEdit.Text
        Dim intervalArray() As String = Split(Interval)
        Interval = intervalArray(0)
        If Interval = "Calibration" Then
            Interval = "Calibration Not Required"
        End If


        'Calculate Next Calibration Date
        LastAndNextCalibrationDtForEditScreen()



        Try
            'u.ExecuteSQL(SqlConnection1, "UPDATE tblToolCalibration Set Division = '" & txtDivisionEdit.Text & "', Dept = '" & txtDeptEdit.Text & "', ToolID = '" & txtToolID.Text & "', SerialNum = '" & txtSerial.Text & "', Description = '" & txtDesc.Text & "', ACType = '" & txtACType.Text & "', Aisle = '" & txtAisle.Text & "', Shelf = '" & txtShelf.Text & "', BinCal = '" & txtBin.Text & "', Comment = '" & txtComment.Text & "', LastCalibrationDt = " & lastCalibDateEdit & ", CalibrationInterval = '" & cbIntervalEdit.Text & "', CalibrationVendor = '" & cbVendorEdit.Text & "', MaintenanceComments = '" & txtMaintenanceComments.Text & "', AssetNum = '" & txtAssetNum.Text & "', ModelNum = '" & txtModelNum.Text & "', Manufacturer = '" & cbMfrEdit.Text & "', UOM = '" & txtUOM.Text & "', Purchased = " & purchasedDateEdit & ", TolerancePlus = '" & txtTolerancePlus.Text & "', ToleranceMinus = '" & txtToleranceMinus.Text & "', Status = '" & cbStatusEdit.Text & "', POandLineNum = '" & txtPOLineNum.Text & "', WONum = '" & txtWONum.Text & "', IssueNum = '" & txtIssueNum.Text & "', Container = '" & txtContainer.Text & "' WHERE RecordID = '" & ToolIdToEdit & "'")
            u.ExecuteSQL(SqlConnection1, "UPDATE tblToolCalibration Set Division = '" & txtDivisionEdit.Text & "', Dept = '" & txtDeptEdit.Text & "', ToolID = '" & txtToolID.Text & "', SerialNum = '" & convertQuotes(txtSerial.Text) & "', Description = '" & convertQuotes(txtDesc.Text) & "', ACType = '" & convertQuotes(cbACType.Text) & "', Aisle = '" & convertQuotes(txtAisle.Text) & "', Shelf = '" & convertQuotes(txtShelf.Text) & "', BinCal = '" & convertQuotes(txtBin.Text) & "', Comment = '" & convertQuotes(txtComment.Text) & "', LastCalibrationDt = " & lastCalibDateEdit & ", CalibrationInterval = '" & Interval & "', CalibrationVendor = '" & cbVendorEdit.Text & "', MaintenanceComments = '" & convertQuotes(txtMaintenanceComments.Text) & "', AssetNum = '" & convertQuotes(txtAssetNum.Text) & "', ModelNum = '" & convertQuotes(txtModelNum.Text) & "', Manufacturer = '" & cbMfrEdit.Text & "', UOM = '" & convertQuotes(cbUOM.Text) & "', Purchased = " & purchasedDateEdit & ", TolerancePlus = '" & convertQuotes(txtTolerancePlus.Text) & "', ToleranceMinus = '" & convertQuotes(txtToleranceMinus.Text) & "', Status = '" & Status & "', POandLineNum = '" & convertQuotes(txtPOLineNum.Text) & "', WONum = '" & convertQuotes(txtWONum.Text) & "', IssueNum = '" & convertQuotes(txtIssueNum.Text) & "', Container = '" & convertQuotes(txtContainer.Text) & "', NomValue = '" & convertQuotes(txtNomValue.Text) & "', NomValueTwo = '" & convertQuotes(txtNomValueTwo.Text) & "', NomValueThree = '" & convertQuotes(txtNomValueThree.Text) & "', NomValueFour = '" & convertQuotes(txtNomValueFour.Text) & "', NomValueFive = '" & convertQuotes(txtNomValueFive.Text) & "', NomValueSix = '" & convertQuotes(txtNomValueSix.Text) & "', NomValueSeven = '" & convertQuotes(txtNomValueSeven.Text) & "', PreventativeMaintenance = '" & chkPreventative.CheckState & "', Location = '" & txtLocation.Text & "' WHERE RecordID = '" & ToolIdToEdit & "'")
            If u.executeSQLError = False Then
                MsgBox("Tool Edited")
            Else
                MsgBox("Tool Not Edited")
            End If
        Catch ex As SystemException
            MessageBox.Show("An error occured while updating the new record to the database." & vbLf & vbLf & ex.Message)
        End Try



        'Refresh the grid in the Tools page
        Tools.ReloadGridData()

        ToolIdToEdit = Nothing
        AddOrEditBtn = ""
        Me.Close()

    End Sub

    Public Function LastAndNextCalibrationDtForEditScreen()

        Dim DateCalibrated As Date
        Dim NextCalibrationDt As String


        If LastCalibDateWasChanged = "Yes" Then

            Try
                DateCalibrated = DateCalibratedEdit

                'Set NextCalibrationDt
                Select Case cbIntervalEdit.Text
                    Case "D - Daily"
                        NextCalibrationDt = DateAdd(DateInterval.Day, 1, DateCalibrated)
                    Case "D"
                        NextCalibrationDt = DateAdd(DateInterval.Day, 1, DateCalibrated)
                    Case "W - Weekly"
                        NextCalibrationDt = DateAdd(DateInterval.Day, 7, DateCalibrated)
                    Case "W"
                        NextCalibrationDt = DateAdd(DateInterval.Day, 7, DateCalibrated)
                    Case "M - Monthly"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 1, DateCalibrated)
                    Case "M"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 1, DateCalibrated)
                    Case "2mos - 2 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 2, DateCalibrated)
                    Case "2mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 2, DateCalibrated)
                    Case "3mos - 3 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 3, DateCalibrated)
                    Case "3mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 3, DateCalibrated)
                    Case "4mos - 4 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 4, DateCalibrated)
                    Case "4mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 4, DateCalibrated)
                    Case "6mos - 6 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 6, DateCalibrated)
                    Case "6mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 6, DateCalibrated)
                    Case "7mos - 7 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 7, DateCalibrated)
                    Case "7mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 7, DateCalibrated)
                    Case "8mos - 8 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 8, DateCalibrated)
                    Case "8mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 8, DateCalibrated)
                    Case "9mos - 9 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 9, DateCalibrated)
                    Case "9mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 9, DateCalibrated)
                    Case "Y - Yearly"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 1, DateCalibrated)
                    Case "Y"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 1, DateCalibrated)
                    Case "15mos - 15 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 15, DateCalibrated)
                    Case "15mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 15, DateCalibrated)
                    Case "18mos - 18 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 18, DateCalibrated)
                    Case "18mos"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 18, DateCalibrated)
                    Case "24mos - 24 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 2, DateCalibrated)
                    Case "24mos"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 2, DateCalibrated)
                    Case "36mos - 36 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 3, DateCalibrated)
                    Case "36mos"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 3, DateCalibrated)
                    Case "48mos - 48 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 4, DateCalibrated)
                    Case "48mos"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 4, DateCalibrated)
                    Case "60mos - 60 Months"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 5, DateCalibrated)
                    Case "60mos"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 5, DateCalibrated)
                    Case "N - Not Required"
                        NextCalibrationDt = "NULL"
                    Case "N"
                        NextCalibrationDt = "NULL"
                    Case "Calibration Not Required"
                        NextCalibrationDt = "NULL"
                    Case Else
                        NextCalibrationDt = "NULL"
                End Select

                If NextCalibrationDt <> "NULL" Then
                    NextCalibrationDt = "'" & NextCalibrationDt & "'"
                End If

                'In the grid of the Tools page, set LastCalibrationDt equal to the date of the last record added and NextCalibrationDt to a date based on the interval
                Dim sqlString As String = "UPDATE tblToolCalibration SET LastCalibrationDt = '" & DateCalibrated & "', NextCalibrationDt = " & NextCalibrationDt & " where RecordID = '" & ToolIdToEdit & "'"
                Dim toolCmd As New SqlCommand(sqlString, connToolingCalib)
                    toolCmd.Connection.Open()
                    toolCmd.ExecuteNonQuery()
                toolCmd.Connection.Close()

            Catch ex As Exception
                MessageBox.Show("An error occured in the LastandNextCalibrationDates function." & vbLf & vbLf & ex.Message)
            End Try

            LastCalibDateWasChanged = ""


        ElseIf CalibDateInCreateTool = "Yes" Then

            Try
                DateCalibrated = DateCalibratedCreate
                Dim CalibrationInterval As String = cbCalibIntervalCreate.Text

                'Set NextCalibrationDt
                Select Case CalibrationInterval
                    Case "D - Daily"
                        NextCalibrationDt = DateAdd(DateInterval.Day, 1, DateCalibrated)
                    Case "W - Weekly"
                        NextCalibrationDt = DateAdd(DateInterval.Day, 7, DateCalibrated)
                    Case "M - Monthly"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 1, DateCalibrated)
                    Case "2mos - 2 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 2, DateCalibrated)
                    Case "3mos - 3 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 3, DateCalibrated)
                    Case "4mos - 4 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 4, DateCalibrated)
                    Case "6mos - 6 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 6, DateCalibrated)
                    Case "7mos - 7 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 7, DateCalibrated)
                    Case "8mos - 8 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 8, DateCalibrated)
                    Case "9mos - 9 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 9, DateCalibrated)
                    Case "Y - Yearly"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 1, DateCalibrated)
                    Case "15mos - 15 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 15, DateCalibrated)
                    Case "18mos - 18 months"
                        NextCalibrationDt = DateAdd(DateInterval.Month, 18, DateCalibrated)
                    Case "24mos - 24 months"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 2, DateCalibrated)
                    Case "36mos - 36 months"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 3, DateCalibrated)
                    Case "48mos - 48 months"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 4, DateCalibrated)
                    Case "60mos - 60 months"
                        NextCalibrationDt = DateAdd(DateInterval.Year, 5, DateCalibrated)
                    Case "N - Not Required"
                        NextCalibrationDt = "NULL"
                    Case "Calibration Not Required"
                        NextCalibrationDt = "NULL"
                    Case Else
                        NextCalibrationDt = "NULL"
                End Select

                If NextCalibrationDt <> "NULL" Then
                    NextCalibrationDt = "'" & NextCalibrationDt & "'"
                End If

                'In the grid of the Tools page, set LastCalibrationDt equal to the date of the last record added and NextCalibrationDt to a date based on the interval
                Dim sqlString As String = "UPDATE tblToolCalibration SET LastCalibrationDt = '" & DateCalibrated & "', NextCalibrationDt = " & NextCalibrationDt & " where RecordID = '" & ToolIdToEdit & "'"
                Dim toolCmd As New SqlCommand(sqlString, connToolingCalib)
                toolCmd.Connection.Open()
                toolCmd.ExecuteNonQuery()
                toolCmd.Connection.Close()

            Catch ex As Exception
                MessageBox.Show("An error occured in the LastandNextCalibrationDates function." & vbLf & vbLf & ex.Message)
            End Try

            CalibDateInCreateTool = ""
        End If

    End Function

    Private Sub dtpLastCalibDt_ValueChanged(sender As Object, e As EventArgs) Handles dtpLastCalibDtEdit.ValueChanged

        If dtpLastCalibDtEdit.Format = DateTimePickerFormat.Custom AndAlso dtpLastCalibDtEdit.CustomFormat = " " Then
            dtpLastCalibDtEdit.Format = DateTimePickerFormat.Short
        End If
        lastCalibDateEdit = "Has Date Now"

        'If Last Calibration Date was changed then calculate the NextCalibrationDate
        LastCalibDateWasChanged = "Yes"
        DateCalibratedEdit = dtpLastCalibDtEdit.Value

    End Sub

    Private Sub dtpPurchasedDtEdit_ValueChanged(sender As Object, e As EventArgs) Handles dtpPurchasedDtEdit.ValueChanged

        If dtpPurchasedDtEdit.Format = DateTimePickerFormat.Custom AndAlso dtpPurchasedDtEdit.CustomFormat = " " Then
            dtpPurchasedDtEdit.Format = DateTimePickerFormat.Short
        End If
        purchasedDateEdit = "Has Date Now"

    End Sub

    Private Sub dtpLastCalibDtCreate_ValueChanged(sender As Object, e As EventArgs) Handles dtpLastCalibDtCreate.ValueChanged

        If dtpLastCalibDtCreate.Format = DateTimePickerFormat.Custom AndAlso dtpLastCalibDtCreate.CustomFormat = " " Then
            dtpLastCalibDtCreate.Format = DateTimePickerFormat.Short
        End If
        lastCalibDateCreate = "Has Date Now"

        'If Last Calibration Date was changed then calculate the NextCalibrationDate
        CalibDateInCreateTool = "Yes"
        DateCalibratedCreate = dtpLastCalibDtCreate.Value

    End Sub

    Private Sub dtpPurchasedDtCreate_ValueChanged(sender As Object, e As EventArgs) Handles dtpPurchasedDtCreate.ValueChanged

        If dtpPurchasedDtCreate.Format = DateTimePickerFormat.Custom AndAlso dtpPurchasedDtCreate.CustomFormat = " " Then
            dtpPurchasedDtCreate.Format = DateTimePickerFormat.Short
        End If
        purchasedDateCreate = "Has Date Now"

    End Sub

    Private Sub AddNewToolForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AddOrEditBtn = ""
    End Sub

    'Private Sub cbAssignedToEdit_Click(sender As Object, e As EventArgs) Handles cbAssignedToEdit.Click

    '    'Dim daComboBoxes As SqlClient.SqlDataAdapter
    '    'Dim dsComboBoxes As New DataSet

    '    ''Fill comboboxes
    '    'daComboBoxes = New SqlClient.SqlDataAdapter("Select Distinct Username from tblToolAssignment Where Username is not null and Username != ' ' Order By Username ASC", SqlConnection1)
    '    'daComboBoxes.Fill(dsComboBoxes, "EMPLOYEE")

    '    'Dim i As Integer = 0
    '    'While i <= dsComboBoxes.Tables("EMPLOYEE").Rows.Count - 1
    '    '    cbAssignedToEdit.Items.Add(dsComboBoxes.Tables("EMPLOYEE").Rows(i).Item("Username"))
    '    '    i = i + 1
    '    'End While
    '    'dsComboBoxes.Tables("EMPLOYEE").Clear()
    '    'dsComboBoxes.Tables("EMPLOYEE").Dispose()

    '    'Fill AssignedTo with Employees from Oracle database
    '    Dim cmdOracle As New OracleCommand
    '    Dim drOracle As OracleDataReader
    '    OracleConnection1.Open()
    '    cmdOracle.Connection = OracleConnection1

    '    cmdOracle.CommandText = "Select YAALPH From CRPDTA.F060116 Where YAPAST = '0' Order By YAALPH ASC"
    '    drOracle = cmdOracle.ExecuteReader()
    '    Do While drOracle.Read = True
    '        cbAssignedToEdit.Items.Add(drOracle.GetString(0))
    '    Loop

    '    cmdOracle.Parameters.Clear()
    '    drOracle.Close()
    '    OracleConnection1.Close()

    'End Sub

    Private Sub cbVendor_Click(sender As Object, e As EventArgs) Handles cbVendorEdit.Click

        Dim daComboBoxes As SqlClient.SqlDataAdapter
        Dim dsComboBoxes As New DataSet

        Dim i As Integer = 0
        daComboBoxes = New SqlClient.SqlDataAdapter("Select Distinct CalibrationVendor from tblCalibrationVendor Where CalibrationVendor is not null and CalibrationVendor != ' ' Order By CalibrationVendor ASC", SqlConnection1)
        daComboBoxes.Fill(dsComboBoxes, "VENDOR")

        While i <= dsComboBoxes.Tables("VENDOR").Rows.Count - 1
            cbVendorEdit.Items.Add(dsComboBoxes.Tables("VENDOR").Rows(i).Item("CalibrationVendor"))
            i = i + 1
        End While
        dsComboBoxes.Tables("VENDOR").Clear()
        dsComboBoxes.Tables("VENDOR").Dispose()

    End Sub

    Private Sub cbMfr_Click(sender As Object, e As EventArgs) Handles cbMfrEdit.Click

        Dim daComboBoxes As SqlClient.SqlDataAdapter
        Dim dsComboBoxes As New DataSet

        daComboBoxes = New SqlClient.SqlDataAdapter("Select Distinct MfrName from tblManufacturerCalibration Where MfrName is not null and MfrName != ' ' Order By MfrName ASC", SqlConnection1)
        daComboBoxes.Fill(dsComboBoxes, "MFR")

        Dim i As Integer = 0
        While i <= dsComboBoxes.Tables("MFR").Rows.Count - 1
            cbMfrEdit.Items.Add(dsComboBoxes.Tables("MFR").Rows(i).Item("MfrName"))
            i = i + 1
        End While
        dsComboBoxes.Tables("MFR").Clear()
        dsComboBoxes.Tables("MFR").Dispose()

    End Sub

    'Disable typing in the following three comboboxes.  If I use "dropdownlist" in the properties for these comboboxes, the combobox would not fill with pre-existing
    'Private Sub cbAssignedToEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAssignedToEdit.KeyPress
    '    e.Handled = True
    'End Sub

    'Disable typing in the following four comboboxes.  If I use "dropdownlist" in the properties for these comboboxes, the combobox would not fill with pre-existing value
    Private Sub cbVendor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbVendorEdit.KeyPress
        e.Handled = True
    End Sub

    Private Sub cbMfr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbMfrEdit.KeyPress
        e.Handled = True
    End Sub

    Private Sub cbIntervalEdit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbIntervalEdit.KeyPress
        e.Handled = True
    End Sub

    Private Sub cbStatusEdit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbStatusEdit.KeyPress
        e.Handled = True
    End Sub

    Private Sub cbIntervalEdit_TextChanged(sender As Object, e As EventArgs) Handles cbIntervalEdit.TextChanged

        'If dtpLastCalibDtEdit.Format = DateTimePickerFormat.Custom AndAlso dtpLastCalibDtEdit.CustomFormat = " " Then
        '    dtpLastCalibDtEdit.Format = DateTimePickerFormat.Short
        'End If
        'lastCalibDateEdit = "Has Date Now"

        'If Last Calibration Date was changed then calculate the NextCalibrationDate
        If lastCalibDateEdit = "" Then
            'Nothing
        Else
            LastCalibDateWasChanged = "Yes"
            DateCalibratedEdit = dtpLastCalibDtEdit.Value
        End If

    End Sub
End Class