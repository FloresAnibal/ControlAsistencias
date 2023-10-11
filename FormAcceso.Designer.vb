<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAcceso
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmAcceso))
        txtBxUsuario = New TextBox()
        txtBxPass = New TextBox()
        lblUsuario = New Label()
        lblPassword = New Label()
        btnAcceder = New Button()
        rdBtnEstu = New RadioButton()
        rdBtnPrece = New RadioButton()
        menuAcceso = New MenuStrip()
        SalirMenuAcceso = New ToolStripMenuItem()
        menuAcceso.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtBxUsuario
        ' 
        txtBxUsuario.Location = New Point(117, 142)
        txtBxUsuario.Name = "txtBxUsuario"
        txtBxUsuario.Size = New Size(173, 27)
        txtBxUsuario.TabIndex = 0
        ' 
        ' txtBxPass
        ' 
        txtBxPass.Location = New Point(117, 272)
        txtBxPass.Name = "txtBxPass"
        txtBxPass.PasswordChar = "*"c
        txtBxPass.Size = New Size(173, 27)
        txtBxPass.TabIndex = 1
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.BackColor = Color.Transparent
        lblUsuario.Font = New Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        lblUsuario.ForeColor = Color.Black
        lblUsuario.Location = New Point(157, 96)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(105, 35)
        lblUsuario.TabIndex = 2
        lblUsuario.Text = "Usuario"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        lblPassword.ForeColor = Color.Black
        lblPassword.Location = New Point(132, 226)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(147, 35)
        lblPassword.TabIndex = 3
        lblPassword.Text = "Contraseña"
        ' 
        ' btnAcceder
        ' 
        btnAcceder.Font = New Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        btnAcceder.Location = New Point(117, 432)
        btnAcceder.Name = "btnAcceder"
        btnAcceder.Size = New Size(161, 49)
        btnAcceder.TabIndex = 4
        btnAcceder.Text = "Acceder"
        btnAcceder.UseVisualStyleBackColor = True
        ' 
        ' rdBtnEstu
        ' 
        rdBtnEstu.AutoSize = True
        rdBtnEstu.BackColor = Color.Transparent
        rdBtnEstu.Checked = True
        rdBtnEstu.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        rdBtnEstu.Location = New Point(132, 329)
        rdBtnEstu.Name = "rdBtnEstu"
        rdBtnEstu.Size = New Size(133, 32)
        rdBtnEstu.TabIndex = 5
        rdBtnEstu.TabStop = True
        rdBtnEstu.Text = "Estudiante"
        rdBtnEstu.TextAlign = ContentAlignment.BottomCenter
        rdBtnEstu.UseVisualStyleBackColor = False
        ' 
        ' rdBtnPrece
        ' 
        rdBtnPrece.AutoSize = True
        rdBtnPrece.BackColor = Color.Transparent
        rdBtnPrece.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        rdBtnPrece.Location = New Point(132, 373)
        rdBtnPrece.Name = "rdBtnPrece"
        rdBtnPrece.Size = New Size(145, 32)
        rdBtnPrece.TabIndex = 7
        rdBtnPrece.Text = "Preceptor/a"
        rdBtnPrece.TextAlign = ContentAlignment.BottomCenter
        rdBtnPrece.UseVisualStyleBackColor = False
        ' 
        ' menuAcceso
        ' 
        menuAcceso.ImageScalingSize = New Size(20, 20)
        menuAcceso.Items.AddRange(New ToolStripItem() {SalirMenuAcceso})
        menuAcceso.Location = New Point(0, 0)
        menuAcceso.Name = "menuAcceso"
        menuAcceso.Size = New Size(406, 31)
        menuAcceso.TabIndex = 8
        menuAcceso.Text = "MenuStrip1"
        ' 
        ' SalirMenuAcceso
        ' 
        SalirMenuAcceso.Alignment = ToolStripItemAlignment.Right
        SalirMenuAcceso.Font = New Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point)
        SalirMenuAcceso.Name = "SalirMenuAcceso"
        SalirMenuAcceso.Size = New Size(55, 27)
        SalirMenuAcceso.Text = "Salir"
        ' 
        ' frmAcceso
        ' 
        AcceptButton = btnAcceder
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(406, 541)
        ControlBox = False
        Controls.Add(rdBtnPrece)
        Controls.Add(rdBtnEstu)
        Controls.Add(btnAcceder)
        Controls.Add(lblPassword)
        Controls.Add(lblUsuario)
        Controls.Add(txtBxPass)
        Controls.Add(txtBxUsuario)
        Controls.Add(menuAcceso)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = menuAcceso
        MaximizeBox = False
        Name = "frmAcceso"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Acceso"
        menuAcceso.ResumeLayout(False)
        menuAcceso.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtBxUsuario As TextBox
    Friend WithEvents txtBxPass As TextBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents btnAcceder As Button
    Friend WithEvents rdBtnEstu As RadioButton
    Friend WithEvents rdBtnPrece As RadioButton
    Friend WithEvents menuAcceso As MenuStrip
    Friend WithEvents SalirMenuAcceso As ToolStripMenuItem
End Class
