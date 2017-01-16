<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.rtbText = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ScrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeColourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AttachFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFontColourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtText = New System.Windows.Forms.RichTextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbText
        '
        Me.rtbText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbText.BackColor = System.Drawing.SystemColors.Window
        Me.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbText.ContextMenuStrip = Me.ContextMenuStrip1
        Me.rtbText.HideSelection = False
        Me.rtbText.Location = New System.Drawing.Point(12, 12)
        Me.rtbText.Name = "rtbText"
        Me.rtbText.ReadOnly = True
        Me.rtbText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtbText.Size = New System.Drawing.Size(274, 200)
        Me.rtbText.TabIndex = 2
        Me.rtbText.Text = "Click connect after entering the initials for the users. Press the ESC key to exi" & _
    "t."
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScrollToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ClearToolStripMenuItem, Me.MuteToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 114)
        '
        'ScrollToolStripMenuItem
        '
        Me.ScrollToolStripMenuItem.Checked = True
        Me.ScrollToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ScrollToolStripMenuItem.Name = "ScrollToolStripMenuItem"
        Me.ScrollToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ScrollToolStripMenuItem.Text = "Scroll"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'MuteToolStripMenuItem
        '
        Me.MuteToolStripMenuItem.Name = "MuteToolStripMenuItem"
        Me.MuteToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.MuteToolStripMenuItem.Text = "Mute"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'Timer4
        '
        Me.Timer4.Interval = 1
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeColourToolStripMenuItem, Me.DefaultToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(222, 48)
        '
        'ChangeColourToolStripMenuItem
        '
        Me.ChangeColourToolStripMenuItem.Name = "ChangeColourToolStripMenuItem"
        Me.ChangeColourToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ChangeColourToolStripMenuItem.Text = "Change Background Colour"
        '
        'DefaultToolStripMenuItem
        '
        Me.DefaultToolStripMenuItem.Name = "DefaultToolStripMenuItem"
        Me.DefaultToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.DefaultToolStripMenuItem.Text = "Default"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AttachFileToolStripMenuItem, Me.ToolStripMenuItem1, Me.ChangeFontColourToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(199, 92)
        '
        'AttachFileToolStripMenuItem
        '
        Me.AttachFileToolStripMenuItem.Name = "AttachFileToolStripMenuItem"
        Me.AttachFileToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.AttachFileToolStripMenuItem.Text = "Attach File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(198, 22)
        Me.ToolStripMenuItem1.Text = "Change Textbox Colour"
        '
        'ChangeFontColourToolStripMenuItem
        '
        Me.ChangeFontColourToolStripMenuItem.Name = "ChangeFontColourToolStripMenuItem"
        Me.ChangeFontColourToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ChangeFontColourToolStripMenuItem.Text = "Change Font Colour"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(198, 22)
        Me.ToolStripMenuItem2.Text = "Default"
        '
        'txtText
        '
        Me.txtText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtText.ContextMenuStrip = Me.ContextMenuStrip3
        Me.txtText.Location = New System.Drawing.Point(12, 222)
        Me.txtText.MaxLength = 490
        Me.txtText.Multiline = False
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(206, 16)
        Me.txtText.TabIndex = 0
        Me.txtText.Text = ""
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Location = New System.Drawing.Point(224, 220)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(62, 20)
        Me.btnSend.TabIndex = 1
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 250)
        Me.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.rtbText)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(314, 288)
        Me.Name = "Form2"
        Me.Text = "Stat Chat"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbText As System.Windows.Forms.RichTextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangeColourToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DefaultToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFontColourToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtText As System.Windows.Forms.RichTextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents AttachFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MuteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
