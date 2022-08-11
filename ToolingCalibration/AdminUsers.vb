'Imports System.Web.UI.WebControls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data

Public Class AdminUsers
    Dim daAdminUsers As SqlClient.SqlDataAdapter
    Dim dsAdminUsers As New DataSet
    Public dataSaved As String

    Private Sub AdminUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        connAdmin.ConnectionString = sqlStringTool

        'Check if user is allowed to use---------------------------------
        Dim Uname As String = Environment.UserName
        daAdminUsers = New SqlClient.SqlDataAdapter("Select Username from tblAdmin Where Username = '" & Uname & "' and IsAdmin = 'True'", connAdmin)
        daAdminUsers.Fill(dsAdminUsers, "ADMIN")
        Dim test As Integer = dsAdminUsers.Tables("ADMIN").Rows.Count

        If test >= 1 Then
            'Allow access

            dataSaved = "yes"

            daAdminUsers = New SqlClient.SqlDataAdapter("Select * from tblAdmin Order By Division", connAdmin)
            daAdminUsers.Fill(dsAdminUsers, "ADMINGRID")
            Me.bsAdmin.DataSource = dsAdminUsers.Tables("ADMINGRID")
            gridAdmin.DataSource = Me.bsAdmin
        Else
            MsgBox("You do not have permission to access the admin page")
            dataSaved = "yes"
            Me.Close()
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.daAdmin.Update(dsAdminUsers, "ADMINGRID")
        MsgBox("Data Saved")
        dataSaved = "yes"
        Me.Close()
    End Sub

    Private Sub AdminUsers_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If dataSaved <> "yes" Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save the changes?", "Title", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                'Me.daAdminUsers.Update(dsAdminUsers, "ADMINGRID")
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

    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs)

        Dim View As GridView = CType(sender, GridView)
        Dim userCol As GridColumn = View.Columns("Username")
        'Dim username As String = View.GetRowCellValue(e.RowHandle, colUsername)
        Dim username As String

        'Validate row if there is no username
        'If IsDBNull(View.GetRowCellValue(e.RowHandle, colUsername)) Or username = "" Then
        If IsDBNull(View.GetRowCellValue(e.RowHandle, colUsername)) Then
            username = ""
            e.Valid = False
            'Set errors with specific descriptions for the columns 
            View.SetColumnError(colUsername, "The username must contain a value")
        End If

    End Sub

End Class