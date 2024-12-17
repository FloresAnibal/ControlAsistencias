<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrece
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrece))
        btnAsitencias = New Button()
        btnSalirPrece = New Button()
        btnRegistros = New Button()
        SuspendLayout()
        ' 
        ' btnAsitencias
        ' 
        btnAsitencias.Font = New Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        btnAsitencias.Location = New Point(75, 123)
        btnAsitencias.Name = "btnAsitencias"
        btnAsitencias.Size = New Size(239, 82)
        btnAsitencias.TabIndex = 5
        btnAsitencias.Text = "Carga de Asistencias"
        btnAsitencias.UseVisualStyleBackColor = True
        ' 
        ' btnSalirPrece
        ' 
        btnSalirPrece.Anchor = AnchorStyles.None
        btnSalirPrece.BackColor = Color.Transparent
        btnSalirPrece.BackgroundImage = My.Resources.Resources.apagarN_small
        btnSalirPrece.BackgroundImageLayout = ImageLayout.Zoom
        btnSalirPrece.FlatAppearance.BorderSize = 0
        btnSalirPrece.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnSalirPrece.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnSalirPrece.FlatStyle = FlatStyle.Flat
        btnSalirPrece.Font = New Font("Calibri", 12F, FontStyle.Italic, GraphicsUnit.Point)
        btnSalirPrece.Location = New Point(346, 12)
        btnSalirPrece.Name = "btnSalirPrece"
        btnSalirPrece.Size = New Size(30, 30)
        btnSalirPrece.TabIndex = 9
        btnSalirPrece.UseVisualStyleBackColor = False
        ' 
        ' btnRegistros
        ' 
        btnRegistros.Font = New Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        btnRegistros.Location = New Point(75, 284)
        btnRegistros.Name = "btnRegistros"
        btnRegistros.Size = New Size(239, 82)
        btnRegistros.TabIndex = 10
        btnRegistros.Text = "Carga de Alumnos"
        btnRegistros.UseVisualStyleBackColor = True
        ' 
        ' frmPrece
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(388, 522)
        Controls.Add(btnRegistros)
        Controls.Add(btnSalirPrece)
        Controls.Add(btnAsitencias)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmPrece"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormPrece"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnAsitencias As Button
    Friend WithEvents btnSalirPrece As Button
    Friend WithEvents btnRegistros As Button
End Class
