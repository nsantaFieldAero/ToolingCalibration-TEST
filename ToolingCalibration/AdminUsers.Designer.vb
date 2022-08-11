<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminUsers))
        Me.bsAdmin = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAdmin1 = New ToolingCalibration.dsAdmin()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.connAdmin = New System.Data.SqlClient.SqlConnection()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.daAdmin = New System.Data.SqlClient.SqlDataAdapter()
        Me.gridAdmin = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAdminName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUsername = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmailAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIsAdmin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        CType(Me.bsAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bsAdmin
        '
        Me.bsAdmin.DataMember = "tblAdmin"
        Me.bsAdmin.DataSource = Me.DsAdmin1
        '
        'DsAdmin1
        '
        Me.DsAdmin1.DataSetName = "dsAdmin"
        Me.DsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(13, 720)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(151, 49)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT        tblAdmin.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            tblAdmin"
        Me.SqlSelectCommand1.Connection = Me.connAdmin
        '
        'connAdmin
        '
        Me.connAdmin.ConnectionString = "Data Source=172.16.3.7\getsmart;Initial Catalog=ToolingCalibration;Persist Securi" &
    "ty Info=True;User ID=sa1;Password=""The water is wet!"""
        Me.connAdmin.FireInfoMessageEventOnUserErrors = False
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = resources.GetString("SqlInsertCommand1.CommandText")
        Me.SqlInsertCommand1.Connection = Me.connAdmin
        Me.SqlInsertCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@AdminName", System.Data.SqlDbType.NVarChar, 0, "AdminName"), New System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.NVarChar, 0, "Username"), New System.Data.SqlClient.SqlParameter("@EmailAddress", System.Data.SqlDbType.NVarChar, 0, "EmailAddress"), New System.Data.SqlClient.SqlParameter("@Division", System.Data.SqlDbType.NVarChar, 0, "Division"), New System.Data.SqlClient.SqlParameter("@IsAdmin", System.Data.SqlDbType.Bit, 0, "IsAdmin")})
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = resources.GetString("SqlUpdateCommand1.CommandText")
        Me.SqlUpdateCommand1.Connection = Me.connAdmin
        Me.SqlUpdateCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@AdminName", System.Data.SqlDbType.NVarChar, 0, "AdminName"), New System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.NVarChar, 0, "Username"), New System.Data.SqlClient.SqlParameter("@EmailAddress", System.Data.SqlDbType.NVarChar, 0, "EmailAddress"), New System.Data.SqlClient.SqlParameter("@Division", System.Data.SqlDbType.NVarChar, 0, "Division"), New System.Data.SqlClient.SqlParameter("@IsAdmin", System.Data.SqlDbType.Bit, 0, "IsAdmin"), New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_AdminName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "AdminName", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_AdminName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AdminName", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Username", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Username", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Username", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Username", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_EmailAddress", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "EmailAddress", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_EmailAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmailAddress", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Division", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Division", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Division", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Division", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_IsAdmin", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "IsAdmin", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_IsAdmin", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IsAdmin", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, "ID")})
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = resources.GetString("SqlDeleteCommand1.CommandText")
        Me.SqlDeleteCommand1.Connection = Me.connAdmin
        Me.SqlDeleteCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_AdminName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "AdminName", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_AdminName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AdminName", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Username", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Username", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Username", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Username", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_EmailAddress", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "EmailAddress", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_EmailAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmailAddress", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Division", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Division", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Division", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Division", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_IsAdmin", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "IsAdmin", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_IsAdmin", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IsAdmin", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daAdmin
        '
        Me.daAdmin.DeleteCommand = Me.SqlDeleteCommand1
        Me.daAdmin.InsertCommand = Me.SqlInsertCommand1
        Me.daAdmin.SelectCommand = Me.SqlSelectCommand1
        Me.daAdmin.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblAdmin", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("AdminName", "AdminName"), New System.Data.Common.DataColumnMapping("Username", "Username"), New System.Data.Common.DataColumnMapping("EmailAddress", "EmailAddress"), New System.Data.Common.DataColumnMapping("Division", "Division"), New System.Data.Common.DataColumnMapping("IsAdmin", "IsAdmin")})})
        Me.daAdmin.UpdateCommand = Me.SqlUpdateCommand1
        '
        'gridAdmin
        '
        Me.gridAdmin.DataSource = Me.bsAdmin
        Me.gridAdmin.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.gridAdmin.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.gridAdmin.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.gridAdmin.EmbeddedNavigator.Buttons.First.Visible = False
        Me.gridAdmin.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.gridAdmin.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.gridAdmin.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.gridAdmin.Location = New System.Drawing.Point(13, 26)
        Me.gridAdmin.MainView = Me.GridView1
        Me.gridAdmin.Name = "gridAdmin"
        Me.gridAdmin.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.gridAdmin.Size = New System.Drawing.Size(1261, 673)
        Me.gridAdmin.TabIndex = 2
        Me.gridAdmin.UseEmbeddedNavigator = True
        Me.gridAdmin.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colAdminName, Me.colUsername, Me.colEmailAddress, Me.colIsAdmin, Me.colDivision})
        Me.GridView1.GridControl = Me.gridAdmin
        Me.GridView1.Name = "GridView1"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        '
        'colAdminName
        '
        Me.colAdminName.FieldName = "AdminName"
        Me.colAdminName.Name = "colAdminName"
        Me.colAdminName.Visible = True
        Me.colAdminName.VisibleIndex = 1
        '
        'colUsername
        '
        Me.colUsername.FieldName = "Username"
        Me.colUsername.Name = "colUsername"
        Me.colUsername.Visible = True
        Me.colUsername.VisibleIndex = 2
        '
        'colEmailAddress
        '
        Me.colEmailAddress.FieldName = "EmailAddress"
        Me.colEmailAddress.Name = "colEmailAddress"
        Me.colEmailAddress.Visible = True
        Me.colEmailAddress.VisibleIndex = 3
        '
        'colIsAdmin
        '
        Me.colIsAdmin.FieldName = "IsAdmin"
        Me.colIsAdmin.Name = "colIsAdmin"
        Me.colIsAdmin.Visible = True
        Me.colIsAdmin.VisibleIndex = 4
        '
        'colDivision
        '
        Me.colDivision.ColumnEdit = Me.RepositoryItemComboBox1
        Me.colDivision.FieldName = "Division"
        Me.colDivision.Name = "colDivision"
        Me.colDivision.Visible = True
        Me.colDivision.VisibleIndex = 0
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"Calgary", "Cincinnati", "OKC", "Toronto"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'AdminUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 775)
        Me.Controls.Add(Me.gridAdmin)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "AdminUsers"
        Me.Text = "Admin Users"
        CType(Me.bsAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAdmin1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents SqlSelectCommand1 As SqlClient.SqlCommand
    Friend WithEvents connAdmin As SqlClient.SqlConnection
    Friend WithEvents SqlInsertCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As SqlClient.SqlCommand
    Friend WithEvents daAdmin As SqlClient.SqlDataAdapter
    Friend WithEvents bsAdmin As BindingSource
    Friend WithEvents DsAdmin1 As dsAdmin
    Friend WithEvents gridAdmin As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAdminName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUsername As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmailAddress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIsAdmin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
