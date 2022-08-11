<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manufacturer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manufacturer))
        Me.gridManufacturer = New DevExpress.XtraGrid.GridControl()
        Me.bsManufacturer = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsManufacturer1 = New ToolingCalibration.dsManufacturer()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colRecordID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMfrName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAddr1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAddr2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colState = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPhone = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContactName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.connManufacturerCalibration = New System.Data.SqlClient.SqlConnection()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.daManufacturer = New System.Data.SqlClient.SqlDataAdapter()
        CType(Me.gridManufacturer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsManufacturer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsManufacturer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridManufacturer
        '
        Me.gridManufacturer.DataSource = Me.bsManufacturer
        Me.gridManufacturer.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.gridManufacturer.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.gridManufacturer.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.gridManufacturer.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.gridManufacturer.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.gridManufacturer.Location = New System.Drawing.Point(13, 50)
        Me.gridManufacturer.MainView = Me.GridView1
        Me.gridManufacturer.Name = "gridManufacturer"
        Me.gridManufacturer.Size = New System.Drawing.Size(1447, 598)
        Me.gridManufacturer.TabIndex = 0
        Me.gridManufacturer.UseEmbeddedNavigator = True
        Me.gridManufacturer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'bsManufacturer
        '
        Me.bsManufacturer.DataMember = "tblManufacturerCalibration"
        Me.bsManufacturer.DataSource = Me.DsManufacturer1
        '
        'DsManufacturer1
        '
        Me.DsManufacturer1.DataSetName = "dsManufacturer"
        Me.DsManufacturer1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colRecordID, Me.colMfrName, Me.colAddr1, Me.colAddr2, Me.colCity, Me.colState, Me.colZip, Me.colCountry, Me.colEmail, Me.colPhone, Me.colFax, Me.colContactName})
        Me.GridView1.GridControl = Me.gridManufacturer
        Me.GridView1.Name = "GridView1"
        '
        'colRecordID
        '
        Me.colRecordID.FieldName = "RecordID"
        Me.colRecordID.Name = "colRecordID"
        Me.colRecordID.OptionsColumn.ReadOnly = True
        '
        'colMfrName
        '
        Me.colMfrName.FieldName = "MfrName"
        Me.colMfrName.Name = "colMfrName"
        Me.colMfrName.Visible = True
        Me.colMfrName.VisibleIndex = 0
        '
        'colAddr1
        '
        Me.colAddr1.FieldName = "Addr1"
        Me.colAddr1.Name = "colAddr1"
        Me.colAddr1.Visible = True
        Me.colAddr1.VisibleIndex = 1
        '
        'colAddr2
        '
        Me.colAddr2.FieldName = "Addr2"
        Me.colAddr2.Name = "colAddr2"
        Me.colAddr2.Visible = True
        Me.colAddr2.VisibleIndex = 2
        '
        'colCity
        '
        Me.colCity.FieldName = "City"
        Me.colCity.Name = "colCity"
        Me.colCity.Visible = True
        Me.colCity.VisibleIndex = 3
        '
        'colState
        '
        Me.colState.FieldName = "State"
        Me.colState.Name = "colState"
        Me.colState.Visible = True
        Me.colState.VisibleIndex = 4
        '
        'colZip
        '
        Me.colZip.FieldName = "Zip"
        Me.colZip.Name = "colZip"
        Me.colZip.Visible = True
        Me.colZip.VisibleIndex = 5
        '
        'colCountry
        '
        Me.colCountry.FieldName = "Country"
        Me.colCountry.Name = "colCountry"
        Me.colCountry.Visible = True
        Me.colCountry.VisibleIndex = 6
        '
        'colEmail
        '
        Me.colEmail.FieldName = "Email"
        Me.colEmail.Name = "colEmail"
        Me.colEmail.Visible = True
        Me.colEmail.VisibleIndex = 7
        '
        'colPhone
        '
        Me.colPhone.FieldName = "Phone"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.Visible = True
        Me.colPhone.VisibleIndex = 8
        '
        'colFax
        '
        Me.colFax.FieldName = "Fax"
        Me.colFax.Name = "colFax"
        Me.colFax.Visible = True
        Me.colFax.VisibleIndex = 9
        '
        'colContactName
        '
        Me.colContactName.FieldName = "ContactName"
        Me.colContactName.Name = "colContactName"
        Me.colContactName.Visible = True
        Me.colContactName.VisibleIndex = 10
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(13, 655)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(151, 40)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT        tblManufacturerCalibration.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            tblManufacturerCalibr" &
    "ation"
        Me.SqlSelectCommand1.Connection = Me.connManufacturerCalibration
        '
        'connManufacturerCalibration
        '
        Me.connManufacturerCalibration.ConnectionString = "Data Source=172.16.3.7\getsmart;Initial Catalog=ToolingCalibration;Persist Securi" &
    "ty Info=True;User ID=sa1;Password=""The water is wet!"""
        Me.connManufacturerCalibration.FireInfoMessageEventOnUserErrors = False
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = resources.GetString("SqlInsertCommand1.CommandText")
        Me.SqlInsertCommand1.Connection = Me.connManufacturerCalibration
        Me.SqlInsertCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@MfrName", System.Data.SqlDbType.NVarChar, 0, "MfrName"), New System.Data.SqlClient.SqlParameter("@Addr1", System.Data.SqlDbType.NVarChar, 0, "Addr1"), New System.Data.SqlClient.SqlParameter("@Addr2", System.Data.SqlDbType.NVarChar, 0, "Addr2"), New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 0, "City"), New System.Data.SqlClient.SqlParameter("@State", System.Data.SqlDbType.NVarChar, 0, "State"), New System.Data.SqlClient.SqlParameter("@Zip", System.Data.SqlDbType.NVarChar, 0, "Zip"), New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 0, "Country"), New System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 0, "Email"), New System.Data.SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 0, "Phone"), New System.Data.SqlClient.SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 0, "Fax"), New System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 0, "ContactName")})
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = resources.GetString("SqlUpdateCommand1.CommandText")
        Me.SqlUpdateCommand1.Connection = Me.connManufacturerCalibration
        Me.SqlUpdateCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@MfrName", System.Data.SqlDbType.NVarChar, 0, "MfrName"), New System.Data.SqlClient.SqlParameter("@Addr1", System.Data.SqlDbType.NVarChar, 0, "Addr1"), New System.Data.SqlClient.SqlParameter("@Addr2", System.Data.SqlDbType.NVarChar, 0, "Addr2"), New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 0, "City"), New System.Data.SqlClient.SqlParameter("@State", System.Data.SqlDbType.NVarChar, 0, "State"), New System.Data.SqlClient.SqlParameter("@Zip", System.Data.SqlDbType.NVarChar, 0, "Zip"), New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 0, "Country"), New System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 0, "Email"), New System.Data.SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 0, "Phone"), New System.Data.SqlClient.SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 0, "Fax"), New System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 0, "ContactName"), New System.Data.SqlClient.SqlParameter("@Original_RecordID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecordID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_MfrName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "MfrName", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_MfrName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MfrName", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Addr1", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Addr1", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Addr1", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Addr1", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Addr2", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Addr2", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Addr2", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Addr2", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_City", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_State", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "State", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_State", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "State", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Zip", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Zip", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Zip", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Zip", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Country", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Email", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Email", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Email", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Phone", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Fax", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Fax", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_ContactName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@RecordID", System.Data.SqlDbType.Int, 4, "RecordID")})
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = resources.GetString("SqlDeleteCommand1.CommandText")
        Me.SqlDeleteCommand1.Connection = Me.connManufacturerCalibration
        Me.SqlDeleteCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_RecordID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RecordID", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_MfrName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "MfrName", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_MfrName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "MfrName", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Addr1", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Addr1", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Addr1", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Addr1", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Addr2", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Addr2", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Addr2", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Addr2", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_City", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_State", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "State", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_State", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "State", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Zip", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Zip", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Zip", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Zip", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Country", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Email", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Email", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Email", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Phone", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_Fax", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_Fax", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing), New System.Data.SqlClient.SqlParameter("@IsNull_ContactName", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""), New System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daManufacturer
        '
        Me.daManufacturer.DeleteCommand = Me.SqlDeleteCommand1
        Me.daManufacturer.InsertCommand = Me.SqlInsertCommand1
        Me.daManufacturer.SelectCommand = Me.SqlSelectCommand1
        Me.daManufacturer.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblManufacturerCalibration", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("RecordID", "RecordID"), New System.Data.Common.DataColumnMapping("MfrName", "MfrName"), New System.Data.Common.DataColumnMapping("Addr1", "Addr1"), New System.Data.Common.DataColumnMapping("Addr2", "Addr2"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("State", "State"), New System.Data.Common.DataColumnMapping("Zip", "Zip"), New System.Data.Common.DataColumnMapping("Country", "Country"), New System.Data.Common.DataColumnMapping("Email", "Email"), New System.Data.Common.DataColumnMapping("Phone", "Phone"), New System.Data.Common.DataColumnMapping("Fax", "Fax"), New System.Data.Common.DataColumnMapping("ContactName", "ContactName")})})
        Me.daManufacturer.UpdateCommand = Me.SqlUpdateCommand1
        '
        'Manufacturer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1472, 730)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gridManufacturer)
        Me.Name = "Manufacturer"
        Me.Text = "Manufacturer"
        CType(Me.gridManufacturer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsManufacturer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsManufacturer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridManufacturer As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnSave As Button
    Friend WithEvents SqlSelectCommand1 As SqlClient.SqlCommand
    Friend WithEvents connManufacturerCalibration As SqlClient.SqlConnection
    Friend WithEvents SqlInsertCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As SqlClient.SqlCommand
    Friend WithEvents daManufacturer As SqlClient.SqlDataAdapter
    Friend WithEvents DsManufacturer1 As dsManufacturer
    Friend WithEvents bsManufacturer As BindingSource
    Friend WithEvents colRecordID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMfrName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAddr1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAddr2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colState As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPhone As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContactName As DevExpress.XtraGrid.Columns.GridColumn
End Class
