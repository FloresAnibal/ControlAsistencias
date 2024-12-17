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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcceso))
        txtBxUsuario = New TextBox()
        txtBxPass = New TextBox()
        lblUsuario = New Label()
        lblPassword = New Label()
        btnAcceder = New Button()
        rdBtnEstu = New RadioButton()
        rdBtnPrece = New RadioButton()
        btnSalirAcceso = New Button()
        SuspendLayout()
        ' 
        ' txtBxUsuario
        ' 
        txtBxUsuario.Location = New Point(119, 127)
        txtBxUsuario.Name = "txtBxUsuario"
        txtBxUsuario.Size = New Size(173, 27)
        txtBxUsuario.TabIndex = 0
        ' 
        ' txtBxPass
        ' 
        txtBxPass.Location = New Point(119, 257)
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
        lblUsuario.Location = New Point(159, 81)
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
        lblPassword.Location = New Point(134, 211)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(147, 35)
        lblPassword.TabIndex = 3
        lblPassword.Text = "Contraseña"
        ' 
        ' btnAcceder
        ' 
        btnAcceder.Font = New Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        btnAcceder.Location = New Point(120, 429)
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
        rdBtnEstu.Font = New Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        rdBtnEstu.Location = New Point(134, 314)
        rdBtnEstu.Name = "rdBtnEstu"
        rdBtnEstu.Size = New Size(134, 32)
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
        rdBtnPrece.Font = New Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        rdBtnPrece.Location = New Point(134, 358)
        rdBtnPrece.Name = "rdBtnPrece"
        rdBtnPrece.Size = New Size(147, 32)
        rdBtnPrece.TabIndex = 7
        rdBtnPrece.Text = "Preceptor/a"
        rdBtnPrece.TextAlign = ContentAlignment.BottomCenter
        rdBtnPrece.UseVisualStyleBackColor = False
        ' 
        ' btnSalirAcceso
        ' 
        btnSalirAcceso.Anchor = AnchorStyles.None
        btnSalirAcceso.BackColor = Color.Transparent
        btnSalirAcceso.BackgroundImage = My.Resources.Resources.apagarN_small
        btnSalirAcceso.BackgroundImageLayout = ImageLayout.Zoom
        btnSalirAcceso.FlatAppearance.BorderSize = 0
        btnSalirAcceso.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnSalirAcceso.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnSalirAcceso.FlatStyle = FlatStyle.Flat
        btnSalirAcceso.Font = New Font("Calibri", 12F, FontStyle.Italic, GraphicsUnit.Point)
        btnSalirAcceso.Location = New Point(364, 12)
        btnSalirAcceso.Name = "btnSalirAcceso"
        btnSalirAcceso.Size = New Size(30, 30)
        btnSalirAcceso.TabIndex = 8
        btnSalirAcceso.UseVisualStyleBackColor = False
        ' 
        ' frmAcceso
        ' 
        AcceptButton = btnAcceder
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(406, 569)
        ControlBox = False
        Controls.Add(btnSalirAcceso)
        Controls.Add(rdBtnPrece)
        Controls.Add(rdBtnEstu)
        Controls.Add(btnAcceder)
        Controls.Add(lblPassword)
        Controls.Add(lblUsuario)
        Controls.Add(txtBxPass)
        Controls.Add(txtBxUsuario)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "frmAcceso"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Acceso"
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
    Friend WithEvents btnSalirAcceso As Button
End Class
