Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Base

Public Class Manufacturer
    Dim daMfr As SqlClient.SqlDataAdapter
    Dim dsMfr As New DataSet
    Public dataSaved As String
    Dim daAdminUsers As SqlClient.SqlDataAdapter
    Dim dsAdminUsers As New DataSet

    Private Sub Manufacturer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        connManufacturerCalibration.ConnectionString = sqlStringTool

        'Check if user is allowed to use---------------------------------
        Dim Uname As String = Environment.UserName
        daAdminUsers = New SqlClient.SqlDataAdapter("Select Username from tblAdmin Where Username = '" & Uname & "' and IsAdmin = 'True'", connManufacturerCalibration)
        daAdminUsers.Fill(dsAdminUsers, "ADMIN")
        Dim test As Integer = dsAdminUsers.Tables("ADMIN").Rows.Count

        If test >= 1 Then
            'Allow access

            dataSaved = "yes"

            'Fill gridCalibrationRecord gridcontrol with data
            daMfr = New SqlClient.SqlDataAdapter("Select * from tblManufacturerCalibration", connManufacturerCalibration)
            daMfr.Fill(dsMfr, "MANUFACTURER")
            Me.bsManufacturer.DataSource = dsMfr.Tables("MANUFACTURER")
            gridManufacturer.DataSource = Me.bsManufacturer

        Else
            MsgBox("You do not have permission to access this page")
            dataSaved = "yes"
            Me.Close()
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Me.daManufacturer.Update(dsMfr, "MANUFACTURER")
            MsgBox("Data Saved")
            dataSaved = "yes"

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("An error occured updating after clicking Save." & vbLf & vbLf & ex.Message)
        End Try
    End Sub

    Private Sub CalibrationManufacturer_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If dataSaved <> "yes" Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save the changes?", "Title", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                'Me.daManufacturer.Update(dsMfr, "MANUFACTURER")
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

End Class