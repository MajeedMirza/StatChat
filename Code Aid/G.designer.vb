<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class G
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(G))
        Me.Ball = New System.Windows.Forms.Button()
        Me.ButtonL = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.VScrollBar3 = New System.Windows.Forms.VScrollBar()
        Me.ButtonR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Ball
        '
        Me.Ball.Enabled = False
        Me.Ball.Location = New System.Drawing.Point(486, 188)
        Me.Ball.Name = "Ball"
        Me.Ball.Size = New System.Drawing.Size(10, 10)
        Me.Ball.TabIndex = 2
        Me.Ball.UseVisualStyleBackColor = True
        '
        'ButtonL
        '
        Me.ButtonL.Enabled = False
        Me.ButtonL.Location = New System.Drawing.Point(12, 176)
        Me.ButtonL.Name = "ButtonL"
        Me.ButtonL.Size = New System.Drawing.Size(10, 35)
        Me.ButtonL.TabIndex = 3
        Me.ButtonL.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(412, 431)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(486, 431)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(556, 431)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "0"
        '
        'Timer2
        '
        Me.Timer2.Interval = 1
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Enabled = False
        Me.VScrollBar1.Location = New System.Drawing.Point(966, -6)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(18, 511)
        Me.VScrollBar1.TabIndex = 7
        '
        'VScrollBar3
        '
        Me.VScrollBar3.Enabled = False
        Me.VScrollBar3.Location = New System.Drawing.Point(7, -6)
        Me.VScrollBar3.Name = "VScrollBar3"
        Me.VScrollBar3.Size = New System.Drawing.Size(18, 511)
        Me.VScrollBar3.TabIndex = 9
        '
        'ButtonR
        '
        Me.ButtonR.Enabled = False
        Me.ButtonR.Location = New System.Drawing.Point(970, 188)
        Me.ButtonR.Name = "ButtonR"
        Me.ButtonR.Size = New System.Drawing.Size(10, 35)
        Me.ButtonR.TabIndex = 1
        Me.ButtonR.UseVisualStyleBackColor = True
        '
        'G
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(984, 462)
        Me.Controls.Add(Me.Ball)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonL)
        Me.Controls.Add(Me.VScrollBar3)
        Me.Controls.Add(Me.ButtonR)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Location = New System.Drawing.Point(20, 122)
        Me.MaximumSize = New System.Drawing.Size(1000, 500)
        Me.MinimumSize = New System.Drawing.Size(1000, 500)
        Me.Name = "G"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Downloads"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ball As System.Windows.Forms.Button
    Friend WithEvents ButtonL As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents VScrollBar3 As System.Windows.Forms.VScrollBar
    Friend WithEvents ButtonR As System.Windows.Forms.Button

End Class
