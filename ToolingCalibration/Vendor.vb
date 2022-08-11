Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class Vendor
    Dim daVendor As SqlClient.SqlDataAdapter
    Dim dsVendor As New DataSet
    Public dataSaved As String
    Dim daAdminUsers As SqlClient.SqlDataAdapter
    Dim dsAdminUsers As New DataSet

    Private Sub Vendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConnVendor.ConnectionString = sqlStringTool

        'Check if user is allowed to use---------------------------------
        Dim Uname As String = Environment.UserName
        daAdminUsers = New SqlClient.SqlDataAdapter("Select Username from tblAdmin Where Username = '" & Uname & "' and IsAdmin = 'True'", ConnVendor)
        daAdminUsers.Fill(dsAdminUsers, "ADMIN")
        Dim test As Integer = dsAdminUsers.Tables("ADMIN").Rows.Count

        If test >= 1 Then
            'Allow access

            dataSaved = "yes"

            'Fill gridCalibrationRecord gridcontrol with data
            daVendor = New SqlClient.SqlDataAdapter("Select * from tblCalibrationVendor", ConnVendor)
            daVendor.Fill(dsVendor, "tblCalibrationVendor")
            Me.bsVendorCalibration.DataSource = dsVendor.Tables("tblCalibrationVendor")
            gridVendor.DataSource = Me.bsVendorCalibration

        Else
            MsgBox("You do not have permission to access this page")
            dataSaved = "yes"
            Me.Close()
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Me.SqlDataAdapter1.Update(dsVendor, "tblCalibrationVendor")
            MsgBox("Data Saved")
            dataSaved = "yes"
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("An error occured after clicking on Save." & vbLf & vbLf & ex.Message)
        End Try

    End Sub

    Private Sub CalibrationVendor_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If dataSaved <> "yes" Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save the changes?", "Title", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                'Me.SqlDataAdapter1.Update(dsVendor, "tblCalibrationVendor")
                btnSave.PerformClick()
            End If
        End If

    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        dataSaved = "no"
    End Sub

    'Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow
    '    dataSaved = "no"
    'End Sub

    Private Sub GridView1_RowDeleted(sender As Object, e As RowDeletedEventArgs) Handles GridView1.RowDeleted
        dataSaved = "no"
    End Sub

End Class