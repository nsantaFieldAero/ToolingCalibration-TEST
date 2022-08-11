'PREVIOUS LINE, THIS WAY ORACLE DID NOT WORK ON SOME USERS COMPUTER
'Imports System.Data.OracleClient

Imports Oracle.ManagedDataAccess.Client
Imports System.Data.SqlClient
Imports DevExpress.Data
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class CalibrationRecord
    Dim daCalibRecord As SqlClient.SqlDataAdapter
    Dim dsCalibRecord As New DataSet
    Public dataSaved As String
    Dim daAdminUsers As SqlClient.SqlDataAdapter
    Dim dsAdminUsers As New DataSet
    Dim da As SqlClient.SqlDataAdapter
    Dim ds As New DataSet

    Dim conString As String = "User Id=JDE;Password=jde;Data Source=JDE9DB"
    Dim cmdString As String

    Private Sub CalibrationRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        connCalibrationRecord.ConnectionString = sqlStringTool

        'Check if user is allowed to use application---------------------------------
        Dim Uname As String = Environment.UserName
        daAdminUsers = New SqlClient.SqlDataAdapter("Select Username from tblAdmin Where Username = '" & Uname & "' and IsAdmin = 'True'", connCalibrationRecord)
        daAdminUsers.Fill(dsAdminUsers, "ADMIN")
        Dim test As Integer = dsAdminUsers.Tables("ADMIN").Rows.Count

        If test >= 1 Then
            'Allow access

            lblRecordID.Text = ToolIdToEdit
            dataSaved = "yes"

            'Fill gridCalibrationRecord gridcontrol with data
            daCalibRecord = New SqlClient.SqlDataAdapter("Select * from tblToolCalibrationRecord Where ToolID = " & ToolIdToEdit & "", connCalibrationRecord)
            daCalibRecord.Fill(dsCalibRecord, "ToolCalibrationRecord")
            Me.bsCalibrationRecord.DataSource = dsCalibRecord.Tables("ToolCalibrationRecord")
            gridCalibrationRecord.DataSource = Me.bsCalibrationRecord

            'SearchToolIdToEdit()


            'Give values to CalibratedBy combobox----------------------------------------------------------------------------

            'daCalibRecord = New SqlClient.SqlDataAdapter("Select Distinct Username from tblToolAssignment Where Username != ' ' and Username is not null Order By Username ASC", connCalibrationRecord)
            'daCalibRecord.Fill(dsCalibRecord, "CALIBRATEDBY")

            'Dim i As Integer = 0
            'While i <= dsCalibRecord.Tables("CALIBRATEDBY").Rows.Count - 1
            '    RepositoryItemComboBox1.Items.Add(dsCalibRecord.Tables("CALIBRATEDBY").Rows(i).Item("Username"))
            '    i = i + 1
            'End While
            'dsCalibRecord.Tables("CALIBRATEDBY").Clear()
            'dsCalibRecord.Tables("CALIBRATEDBY").Dispose()

            'PREVIOUS BLOCK OF CODE, IT DID NOT WORK ON SOME USERS COMPUTER
            ''Fill CalibratedBy with Employees from Oracle database
            'Dim cmdOracle As New OracleCommand
            'Dim drOracle As OracleDataReader
            'OracleConnection1.Open()
            'cmdOracle.Connection = OracleConnection1

            'cmdOracle.CommandText = "Select YAALPH From CRPDTA.F060116 Where YAPAST = '0' Order By YAALPH ASC"
            'drOracle = cmdOracle.ExecuteReader()
            'Do While drOracle.Read = True
            '    RepositoryItemComboBox1.Items.Add(drOracle.GetString(0))
            'Loop

            'cmdOracle.Parameters.Clear()
            'drOracle.Close()
            'OracleConnection1.Close()


            'FOLLOWING BLOCK OF CODE WAS COMMENTED TO SOLVE THE ORACLE ERROR ABOUT HAVING AN ORACLE VERSION GREATER THAN... 
            'Try

            'OracleConnection1.Open()
            'cmdString = ""
            'cmdString = "Select YAALPH From CRPDTA.F060116 Where YAPAST = '0' Order By YAALPH ASC"
            'Dim adapter As OracleDataAdapter = New OracleDataAdapter(cmdString, conString)
            'Dim ds As DataSet = New DataSet()
            'adapter.Fill(ds, "Data")

            'If ds.Tables("Data").Rows.Count > 0 Then
            '    Dim i As Integer = 0
            '    While i <= ds.Tables("Data").Rows.Count - 1
            '        RepositoryItemComboBox1.Items.Add(ds.Tables("Data").Rows(i).Item("YAALPH"))
            '        i = i + 1
            '    End While

            '    ds.Tables("Data").Clear()
            '    ds.Tables("Data").Dispose()
            'End If

            'OracleConnection1.Close()

            'Catch ex As Exception
            '    MessageBox.Show("Error with code starting at cmdString." & ex.Message)
            '    Exit Sub
            'End Try

        Else
            MsgBox("You do not have permission to access this page")
            dataSaved = "yes"
            Me.Close()
        End If


        If IsCalgary <> "Yes" Then
            GridView1.Columns("NomValue").Visible = False
            GridView1.Columns("TolMin").Visible = False
            GridView1.Columns("TolPlus").Visible = False
            GridView1.Columns("NomValueTwo").Visible = False
            GridView1.Columns("TolMinTwo").Visible = False
            GridView1.Columns("TolPlusTwo").Visible = False
            GridView1.Columns("NomValueThree").Visible = False
            GridView1.Columns("TolMinThree").Visible = False
            GridView1.Columns("TolPlusThree").Visible = False
            GridView1.Columns("NomValueFour").Visible = False
            GridView1.Columns("TolMinFour").Visible = False
            GridView1.Columns("TolPlusFour").Visible = False
            GridView1.Columns("NomValueFive").Visible = False
            GridView1.Columns("TolMinFive").Visible = False
            GridView1.Columns("TolPlusFive").Visible = False
            GridView1.Columns("NomValueSix").Visible = False
            GridView1.Columns("TolMinSix").Visible = False
            GridView1.Columns("TolPlusSix").Visible = False
            GridView1.Columns("NomValueSeven").Visible = False
            GridView1.Columns("TolMinSeven").Visible = False
            GridView1.Columns("TolPlusSeven").Visible = False
            GridView1.Columns("Temperature").Visible = False
            GridView1.Columns("Humidity").Visible = False
            GridView1.Columns("CalStandardID").Visible = False
            GridView1.Columns("Instructions").Visible = False
            GridView1.Columns("ActualValue").Visible = False
            GridView1.Columns("ActualValueTwo").Visible = False
            GridView1.Columns("ActualValueThree").Visible = False
            GridView1.Columns("ActualValueFour").Visible = False
            GridView1.Columns("ActualValueFive").Visible = False
            GridView1.Columns("ActualValueSix").Visible = False
            GridView1.Columns("ActualValueSeven").Visible = False
            GridView1.Columns("FunctionalAndSecure").Visible = False
            GridView1.Columns("ReviewedBy").Visible = False

        Else
            GridView1.Columns("AdditionalNotes").Visible = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'SET TOOL RECORD ID CELL VALUE AS THE ONE FROM THE CELL ABOVE
        Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns.ColumnByFieldName("ToolID")
        If Col Is Nothing Then Exit Sub
        'Obtain the number of data rows.  
        Dim DataRowCount As Integer = GridView1.DataRowCount
        DataRowCount -= 1
        'Dim CellValue As Object = GridView1.GetRowCellValue(0, Col)
        'Dim NewValue As Integer = Convert.ToDouble(CellValue)
        'GridView1.SetRowCellValue(DataRowCount, Col, NewValue)
        GridView1.SetRowCellValue(DataRowCount, Col, ToolIdToEdit)

        'Set Last and Next calibration dates in the grid of the Tools page
        LastAndNextCalibrationDates()

        'Update Calibration Record Table
        Try
            Me.SqlDataAdapter2.Update(dsCalibRecord, "ToolCalibrationRecord")
            MsgBox("Data Saved")
            dataSaved = "yes"
        Catch ex As Exception
            MessageBox.Show("An error occured while updating after clicking on Save." & vbLf & vbLf & ex.Message)
        End Try

        SaveAddedRow()

        'Reload grid data of the Tools page
        Tools.ReloadGridData()

        Me.Close()

    End Sub

    Public Function SaveAddedRow()

        Try
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns.ColumnByFieldName("ToolID")
            Dim DataRowCount As Integer = GridView1.DataRowCount

            Dim I As Integer
            'Set all cells under ToolID equal to ToolIdToEdit
            For I = 0 To DataRowCount + 1
                'Dim CellValue As Object = GridView1.GetRowCellValue(0, Col)
                'Dim NewValue As Integer = Convert.ToDouble(CellValue)
                'GridView1.SetRowCellValue(I, Col, NewValue)
                GridView1.SetRowCellValue(I, Col, ToolIdToEdit)
            Next

            Me.SqlDataAdapter2.Update(dsCalibRecord, "ToolCalibrationRecord")

        Catch ex As Exception
            MessageBox.Show("An error occured in the SaveAddedRow function." & vbLf & vbLf & ex.Message)
        End Try

    End Function

    Public Function LastAndNextCalibrationDates()

        Try
            Dim DataRowCount As Integer = GridView1.DataRowCount
            DataRowCount -= 1
            Dim DateCalibrated As Date = GridView1.GetRowCellValue(DataRowCount, colDateCalibrated)
            Dim NextCalibrationDt As String

            'Set NextCalibrationDt
            Select Case CalibInterval
                Case "D"
                    NextCalibrationDt = DateAdd(DateInterval.Day, 1, DateCalibrated)
                Case "W"
                    NextCalibrationDt = DateAdd(DateInterval.Day, 7, DateCalibrated)
                Case "M"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 1, DateCalibrated)
                Case "2mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 2, DateCalibrated)
                Case "3mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 3, DateCalibrated)
                Case "4mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 4, DateCalibrated)
                Case "6mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 6, DateCalibrated)
                Case "7mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 7, DateCalibrated)
                Case "8mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 8, DateCalibrated)
                Case "9mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 9, DateCalibrated)
                Case "Y"
                    NextCalibrationDt = DateAdd(DateInterval.Year, 1, DateCalibrated)
                Case "15mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 15, DateCalibrated)
                Case "18mos"
                    NextCalibrationDt = DateAdd(DateInterval.Month, 18, DateCalibrated)
                Case "24mos"
                    NextCalibrationDt = DateAdd(DateInterval.Year, 2, DateCalibrated)
                Case "36mos"
                    NextCalibrationDt = DateAdd(DateInterval.Year, 3, DateCalibrated)
                Case "48mos"
                    NextCalibrationDt = DateAdd(DateInterval.Year, 4, DateCalibrated)
                Case "60mos"
                    NextCalibrationDt = DateAdd(DateInterval.Year, 5, DateCalibrated)
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
            Dim toolCmd As New SqlCommand(sqlString, connCalibrationRecord)
            toolCmd.Connection.Open()
            toolCmd.ExecuteNonQuery()
            toolCmd.Connection.Close()

        Catch ex As Exception
            MessageBox.Show("An error occured in the LastandNextCalibrationDates function." & vbLf & vbLf & ex.Message)
        End Try

    End Function

    Private Sub CalibrationRecord_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If dataSaved <> "yes" Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save the changes?", "Title", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                'Me.SqlDataAdapter2.Update(dsCalibRecord, "ToolCalibrationRecord")
                btnSave.PerformClick()
            End If
        End If

    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        dataSaved = "no"
    End Sub

    Private Sub GridView1_RowDeleted(sender As Object, e As RowDeletedEventArgs) Handles GridView1.RowDeleted
        dataSaved = "no"
    End Sub

    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView1.ValidateRow

        Dim View As GridView = CType(sender, GridView)
        Dim DtCalibratedCol As GridColumn = View.Columns("DateCalibrated")
        Dim DateCalibrated As String = Convert.ToString(View.GetRowCellValue(e.RowHandle, colDateCalibrated))

        'Validate row if there is no ToolID
        If IsDBNull(View.GetRowCellValue(e.RowHandle, colDateCalibrated)) Or DateCalibrated = "" Then
            DateCalibrated = ""
            e.Valid = False
            'Set errors with specific descriptions for the columns 
            View.SetColumnError(colDateCalibrated, "Date Calibrated must contain a date")
        End If

        'Make sure CalibratedBy has data
        Dim CalibratedBy As String = Convert.ToString(View.GetRowCellValue(e.RowHandle, colCalibratedBy))
        If IsDBNull(View.GetRowCellValue(e.RowHandle, colDateCalibrated)) Or CalibratedBy = "" Then
            CalibratedBy = ""
            e.Valid = False
            'Set errors with specific descriptions for the columns 
            View.SetColumnError(colCalibratedBy, "Calibrated By must be entered")
        End If


        'Temperature must be number with one decimal
        Dim Temperature As Object = View.GetRowCellValue(e.RowHandle, colTemperature)
        If Not IsDBNull(Temperature) Then
            Dim Position As Integer = Convert.ToInt16(Convert.ToString(Temperature).IndexOf("."))
            Dim stringTemperature As String = Temperature
            Dim numberOfDecimals As String = stringTemperature.Substring(Position + 1)

            If numberOfDecimals.Length > 1 Then
                e.Valid = False
                View.SetColumnError(colTemperature, "Temperature must be numeric with one decimal")
                MsgBox("Temperature must be numeric with one decimal")
            End If

            If Not IsNumeric(Temperature) Then
                If Temperature <> "" Then
                    e.Valid = False
                    View.SetColumnError(colTemperature, "Temperature must be numeric with one decimal")
                End If
            End If

        Else
            If Not IsDBNull(Temperature) Then
                If Not IsNumeric(Temperature) Then
                    If Temperature <> "" Then
                        e.Valid = False
                        View.SetColumnError(colTemperature, "Temperature must be entered")
                    End If
                End If
            End If
        End If


        'Humidity must be number with one decimal
        Dim Humidity As Object = View.GetRowCellValue(e.RowHandle, colHumidity)
        If Not IsDBNull(Humidity) Then
            Dim Position As Integer = Convert.ToInt16(Convert.ToString(Humidity).IndexOf("."))
            Dim stringHumidity As String = Humidity
            Dim numberOfDecimals As String = stringHumidity.Substring(Position + 1)

            If numberOfDecimals.Length > 1 Then
                e.Valid = False
                View.SetColumnError(colHumidity, "Humidity must be numeric with one decimal")
            End If

            If Not IsNumeric(Humidity) Then
                If Humidity <> "" Then
                    e.Valid = False
                    View.SetColumnError(colHumidity, "Humidity must be numeric with one decimal")
                End If
            End If

        Else
            If Not IsDBNull(Humidity) Then
                If Not IsNumeric(Humidity) Then
                    If Humidity <> "" Then
                        e.Valid = False
                        View.SetColumnError(colHumidity, "Humidity must be entered")
                    End If
                End If
            End If
        End If


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

    End Sub

    Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow

        Dim CalculatedTolMin As String = ""
        Dim CalculatedTolPlus As String = ""
        Dim CalculatedTolMinTwo As String = ""
        Dim CalculatedTolPlusTwo As String = ""
        Dim CalculatedTolMinThree As String = ""
        Dim CalculatedTolPlusThree As String = ""
        Dim CalculatedTolMinFour As String = ""
        Dim CalculatedTolPlusFour As String = ""
        Dim CalculatedTolMinFive As String = ""
        Dim CalculatedTolPlusFive As String = ""
        Dim CalculatedTolMinSix As String = ""
        Dim CalculatedTolPlusSix As String = ""
        Dim CalculatedTolMinSeven As String = ""
        Dim CalculatedTolPlusSeven As String = ""


        'Fill out calculated columns: Nominal Value - ToleranceMin  AND  Nominal Value + TolerancePlus
        If IsCalgary = "Yes" Then

            'Calculate Calculated Tolerance Minus and Plus, and fill out the relative fields
            CalculatedTolMin = (Convert.ToDecimal(NomValue) - Convert.ToDecimal(ToleranceMin)).ToString
            CalculatedTolPlus = (Convert.ToDecimal(NomValue) + Convert.ToDecimal(TolerancePlus)).ToString

            Dim view As GridView = TryCast(sender, GridView)

            view.SetRowCellValue(e.RowHandle, view.Columns(6), NomValue)
            view.SetRowCellValue(e.RowHandle, view.Columns(7), CalculatedTolMin)
            view.SetRowCellValue(e.RowHandle, view.Columns(8), CalculatedTolPlus)
            'GridView1.SetRowCellValue(0, Col, ToolIdToEdit)

            'Calculate Other Fields, if there were other nominal values
            If NomValueTwo <> "" Then
                CalculatedTolMinTwo = (Convert.ToDecimal(NomValueTwo) - Convert.ToDecimal(ToleranceMin)).ToString
                CalculatedTolPlusTwo = (Convert.ToDecimal(NomValueTwo) + Convert.ToDecimal(TolerancePlus)).ToString

                'Dim view As GridView = TryCast(sender, GridView)
                view.SetRowCellValue(e.RowHandle, view.Columns(9), NomValueTwo)
                view.SetRowCellValue(e.RowHandle, view.Columns(10), CalculatedTolMinTwo)
                view.SetRowCellValue(e.RowHandle, view.Columns(11), CalculatedTolPlusTwo)
            End If

            If NomValueThree <> "" Then
                CalculatedTolMinThree = (Convert.ToDecimal(NomValueThree) - Convert.ToDecimal(ToleranceMin)).ToString
                CalculatedTolPlusThree = (Convert.ToDecimal(NomValueThree) + Convert.ToDecimal(TolerancePlus)).ToString

                view.SetRowCellValue(e.RowHandle, view.Columns(12), NomValueThree)
                view.SetRowCellValue(e.RowHandle, view.Columns(13), CalculatedTolMinThree)
                view.SetRowCellValue(e.RowHandle, view.Columns(14), CalculatedTolPlusThree)
            End If

            If NomValueFour <> "" Then
                CalculatedTolMinFour = (Convert.ToDecimal(NomValueFour) - Convert.ToDecimal(ToleranceMin)).ToString
                CalculatedTolPlusFour = (Convert.ToDecimal(NomValueFour) + Convert.ToDecimal(TolerancePlus)).ToString

                view.SetRowCellValue(e.RowHandle, view.Columns(15), NomValueFour)
                view.SetRowCellValue(e.RowHandle, view.Columns(16), CalculatedTolMinFour)
                view.SetRowCellValue(e.RowHandle, view.Columns(17), CalculatedTolPlusFour)
            End If

            If NomValueFive <> "" Then
                CalculatedTolMinFive = (Convert.ToDecimal(NomValueFive) - Convert.ToDecimal(ToleranceMin)).ToString
                CalculatedTolPlusFive = (Convert.ToDecimal(NomValueFive) + Convert.ToDecimal(TolerancePlus)).ToString

                view.SetRowCellValue(e.RowHandle, view.Columns(18), NomValueFive)
                view.SetRowCellValue(e.RowHandle, view.Columns(19), CalculatedTolMinFive)
                view.SetRowCellValue(e.RowHandle, view.Columns(20), CalculatedTolPlusFive)
            End If

            If NomValueSix <> "" Then
                CalculatedTolMinSix = (Convert.ToDecimal(NomValueSix) - Convert.ToDecimal(ToleranceMin)).ToString
                CalculatedTolPlusSix = (Convert.ToDecimal(NomValueSix) + Convert.ToDecimal(TolerancePlus)).ToString

                view.SetRowCellValue(e.RowHandle, view.Columns(21), NomValueSix)
                view.SetRowCellValue(e.RowHandle, view.Columns(22), CalculatedTolMinSix)
                view.SetRowCellValue(e.RowHandle, view.Columns(23), CalculatedTolPlusSix)
            End If

            If NomValueSeven <> "" Then
                CalculatedTolMinSeven = (Convert.ToDecimal(NomValueSeven) - Convert.ToDecimal(ToleranceMin)).ToString
                CalculatedTolPlusSeven = (Convert.ToDecimal(NomValueSeven) + Convert.ToDecimal(TolerancePlus)).ToString

                view.SetRowCellValue(e.RowHandle, view.Columns(24), NomValueSeven)
                view.SetRowCellValue(e.RowHandle, view.Columns(25), CalculatedTolMinSeven)
                view.SetRowCellValue(e.RowHandle, view.Columns(26), CalculatedTolPlusSeven)
            End If

        End If


        'Fill out the Instructions field drop-down
        RepositoryItemComboBox2.Items.Clear()

        da = New SqlClient.SqlDataAdapter("Select Distinct DropDownValues From tblInstructionsDropDown Order By DropDownValues", connCalibrationRecord)
        da.Fill(ds, "Instructions")

        Dim i As Integer = 0
        While i <= ds.Tables("Instructions").Rows.Count - 1
            RepositoryItemComboBox2.Items.Add(ds.Tables("Instructions").Rows(i).Item("DropDownValues"))
            i = i + 1
        End While

        ds.Tables("Instructions").Clear()
        ds.Tables("Instructions").Dispose()


        'Fill out the AdditionalNotesAndActions field drop-down
        RepositoryItemComboBox4.Items.Clear()

        da = New SqlClient.SqlDataAdapter("Select Distinct DropDownValues From tblAdditionalNotesDropDown Order By DropDownValues", connCalibrationRecord)
        da.Fill(ds, "AdditionalNotes")

        Dim a As Integer = 0
        While a <= ds.Tables("AdditionalNotes").Rows.Count - 1
            RepositoryItemComboBox4.Items.Add(ds.Tables("AdditionalNotes").Rows(a).Item("DropDownValues"))
            a = a + 1
        End While

        ds.Tables("AdditionalNotes").Clear()
        ds.Tables("AdditionalNotes").Dispose()

    End Sub

    Private Sub GridView1_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles GridView1.InvalidRowException
        'Suppress displaying the error message box 
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub



    'Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow

    '    Dim Count As Integer

    '    Dim Col As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns.ColumnByFieldName("ToolID")
    '    If Col Is Nothing Then Exit Sub
    '    'Obtain the number of data rows.  
    '    Dim DataRowCount As Integer = GridView1.DataRowCount
    '    'DataRowCount += 1

    '    Dim I As Integer
    '    For I = 0 To DataRowCount
    '        Dim CellValue As Object = GridView1.GetRowCellValue(I, Col)         
    '        Dim NewValue As Double = Convert.ToDouble(CellValue)
    '        GridView1.SetRowCellValue(I, Col, NewValue)                                                  
    '    Next

    'End Sub


    'Public Function SearchToolIdToEdit()

    'Dim SqlString As String = " Where RecordID = '" & ToolIdToEdit & "'"
    'Me.SqlDataAdapter1.SelectCommand.CommandText() += SqlString

    'End Function

End Class