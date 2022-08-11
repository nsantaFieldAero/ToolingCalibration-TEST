<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalibDueAssignTo
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
        Me.txtRecordID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnGenerateReport = New System.Windows.Forms.Button()
        Me.dtDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbDates = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbPastDue = New System.Windows.Forms.CheckBox()
        Me.cboAssignedTo = New System.Windows.Forms.ComboBox()
        Me.cboManufacturer = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.txtToolID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbDivision = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRecordID
        '
        Me.txtRecordID.Location = New System.Drawing.Point(122, 29)
        Me.txtRecordID.Name = "txtRecordID"
        Me.txtRecordID.Size = New System.Drawing.Size(200, 20)
        Me.txtRecordID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Record ID"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(79, 532)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(124, 49)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Location = New System.Drawing.Point(231, 532)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(124, 49)
        Me.btnGenerateReport.TabIndex = 3
        Me.btnGenerateReport.Text = "Generate Report"
        Me.btnGenerateReport.UseVisualStyleBackColor = True
        '
        'dtDateFrom
        '
        Me.dtDateFrom.Location = New System.Drawing.Point(147, 51)
        Me.dtDateFrom.Name = "dtDateFrom"
        Me.dtDateFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtDateFrom.TabIndex = 4
        '
        'dtDateTo
        '
        Me.dtDateTo.Location = New System.Drawing.Point(507, 50)
        Me.dtDateTo.Name = "dtDateTo"
        Me.dtDateTo.Size = New System.Drawing.Size(200, 20)
        Me.dtDateTo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Last Calibration Date From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(380, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Last Calibration Date To"
        '
        'cbDates
        '
        Me.cbDates.AutoSize = True
        Me.cbDates.Location = New System.Drawing.Point(16, 28)
        Me.cbDates.Name = "cbDates"
        Me.cbDates.Size = New System.Drawing.Size(15, 14)
        Me.cbDates.TabIndex = 8
        Me.cbDates.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbDates)
        Me.GroupBox1.Controls.Add(Me.dtDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtDateTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 195)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 86)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Check Here to Use Dates"
        '
        'cbPastDue
        '
        Me.cbPastDue.AutoSize = True
        Me.cbPastDue.Location = New System.Drawing.Point(48, 308)
        Me.cbPastDue.Name = "cbPastDue"
        Me.cbPastDue.Size = New System.Drawing.Size(127, 17)
        Me.cbPastDue.TabIndex = 10
        Me.cbPastDue.Text = "Calibrations Past Due"
        Me.cbPastDue.UseVisualStyleBackColor = True
        '
        'cboAssignedTo
        '
        Me.cboAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssignedTo.FormattingEnabled = True
        Me.cboAssignedTo.Location = New System.Drawing.Point(122, 359)
        Me.cboAssignedTo.Name = "cboAssignedTo"
        Me.cboAssignedTo.Size = New System.Drawing.Size(200, 21)
        Me.cboAssignedTo.TabIndex = 11
        '
        'cboManufacturer
        '
        Me.cboManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboManufacturer.FormattingEnabled = True
        Me.cboManufacturer.Location = New System.Drawing.Point(122, 416)
        Me.cboManufacturer.Name = "cboManufacturer"
        Me.cboManufacturer.Size = New System.Drawing.Size(200, 21)
        Me.cboManufacturer.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 362)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Assigned To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 419)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Manufacturer"
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=172.16.3.7\getsmart;Initial Catalog=ToolingCalibration;Persist Securi" &
    "ty Info=True;User ID=sa1;Password=""The water is wet!"""
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'txtToolID
        '
        Me.txtToolID.Location = New System.Drawing.Point(122, 84)
        Me.txtToolID.Name = "txtToolID"
        Me.txtToolID.Size = New System.Drawing.Size(200, 20)
        Me.txtToolID.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(62, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Tool ID"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(60, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Division"
        '
        'cbDivision
        '
        Me.cbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDivision.FormattingEnabled = True
        Me.cbDivision.Location = New System.Drawing.Point(122, 140)
        Me.cbDivision.Name = "cbDivision"
        Me.cbDivision.Size = New System.Drawing.Size(200, 21)
        Me.cbDivision.TabIndex = 19
        '
        'frmCalibDueAssignTo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 661)
        Me.Controls.Add(Me.cbDivision)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtToolID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboManufacturer)
        Me.Controls.Add(Me.cboAssignedTo)
        Me.Controls.Add(Me.cbPastDue)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGenerateReport)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRecordID)
        Me.Name = "frmCalibDueAssignTo"
        Me.Text = "Tools Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtRecordID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents dtDateFrom As DateTimePicker
    Friend WithEvents dtDateTo As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbDates As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbPastDue As CheckBox
    Friend WithEvents cboAssignedTo As ComboBox
    Friend WithEvents cboManufacturer As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents SqlConnection1 As SqlClient.SqlConnection
    Friend WithEvents Label6 As Label
    Friend WithEvents txtToolID As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cbDivision As ComboBox
End Class
