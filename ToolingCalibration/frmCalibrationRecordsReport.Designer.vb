<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalibrationRecordsReport
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnGenerateReport = New System.Windows.Forms.Button()
        Me.txtRecordID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDateCalibrated = New System.Windows.Forms.DateTimePicker()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.cbCalibratedBy = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(59, 554)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(151, 51)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Location = New System.Drawing.Point(232, 554)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(151, 51)
        Me.btnGenerateReport.TabIndex = 1
        Me.btnGenerateReport.Text = "Generate Report"
        Me.btnGenerateReport.UseVisualStyleBackColor = True
        '
        'txtRecordID
        '
        Me.txtRecordID.Location = New System.Drawing.Point(123, 60)
        Me.txtRecordID.Name = "txtRecordID"
        Me.txtRecordID.Size = New System.Drawing.Size(197, 20)
        Me.txtRecordID.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "RecordID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Date Calibrated"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Calibrated By"
        '
        'dtpDateCalibrated
        '
        Me.dtpDateCalibrated.Location = New System.Drawing.Point(123, 112)
        Me.dtpDateCalibrated.Name = "dtpDateCalibrated"
        Me.dtpDateCalibrated.Size = New System.Drawing.Size(197, 20)
        Me.dtpDateCalibrated.TabIndex = 8
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=172.16.3.7\getsmart;Initial Catalog=ToolingCalibration;Persist Securi" &
    "ty Info=True;User ID=sa1;Password=""The water is wet!"""
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'cbCalibratedBy
        '
        Me.cbCalibratedBy.FormattingEnabled = True
        Me.cbCalibratedBy.Location = New System.Drawing.Point(123, 171)
        Me.cbCalibratedBy.Name = "cbCalibratedBy"
        Me.cbCalibratedBy.Size = New System.Drawing.Size(197, 21)
        Me.cbCalibratedBy.TabIndex = 9
        '
        'frmCalibrationRecordsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 661)
        Me.Controls.Add(Me.cbCalibratedBy)
        Me.Controls.Add(Me.dtpDateCalibrated)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRecordID)
        Me.Controls.Add(Me.btnGenerateReport)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "frmCalibrationRecordsReport"
        Me.Text = "Calibration Records Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnGenerateReport As Button
    Friend WithEvents txtRecordID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpDateCalibrated As DateTimePicker
    Friend WithEvents SqlConnection1 As SqlClient.SqlConnection
    Friend WithEvents cbCalibratedBy As ComboBox
End Class
