<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsistenciaEstu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsistenciaEstu))
        lstVwAsis = New ListView()
        columnaFecha = New ColumnHeader()
        columnaAsis = New ColumnHeader()
        btnSalirEstu = New Button()
        btnInicio = New Button()
        SuspendLayout()
        ' 
        ' lstVwAsis
        ' 
        lstVwAsis.Columns.AddRange(New ColumnHeader() {columnaFecha, columnaAsis})
        lstVwAsis.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        lstVwAsis.Location = New Point(74, 114)
        lstVwAsis.Name = "lstVwAsis"
        lstVwAsis.Size = New Size(257, 328)
        lstVwAsis.TabIndex = 8
        lstVwAsis.UseCompatibleStateImageBehavior = False
        lstVwAsis.View = View.Details
        ' 
        ' columnaFecha
        ' 
        columnaFecha.Text = "Fecha"
        columnaFecha.Width = 120
        ' 
        ' columnaAsis
        ' 
        columnaAsis.Text = "Asistencia"
        columnaAsis.Width = 100
        ' 
        ' btnSalirEstu
        ' 
        btnSalirEstu.Anchor = AnchorStyles.None
        btnSalirEstu.BackColor = Color.Transparent
        btnSalirEstu.BackgroundImage = My.Resources.Resources.apagarN_small
        btnSalirEstu.BackgroundImageLayout = ImageLayout.Zoom
        btnSalirEstu.FlatAppearance.BorderSize = 0
        btnSalirEstu.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnSalirEstu.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnSalirEstu.FlatStyle = FlatStyle.Flat
        btnSalirEstu.Font = New Font("Calibri", 12F, FontStyle.Italic, GraphicsUnit.Point)
        btnSalirEstu.Location = New Point(364, 12)
        btnSalirEstu.Name = "btnSalirEstu"
        btnSalirEstu.Size = New Size(30, 30)
        btnSalirEstu.TabIndex = 9
        btnSalirEstu.UseVisualStyleBackColor = False
        ' 
        ' btnInicio
        ' 
        btnInicio.Anchor = AnchorStyles.None
        btnInicio.BackColor = Color.Transparent
        btnInicio.BackgroundImage = My.Resources.Resources.homeN_small
        btnInicio.BackgroundImageLayout = ImageLayout.Zoom
        btnInicio.FlatAppearance.BorderSize = 0
        btnInicio.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnInicio.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnInicio.FlatStyle = FlatStyle.Flat
        btnInicio.Font = New Font("Calibri", 12F, FontStyle.Italic, GraphicsUnit.Point)
        btnInicio.Location = New Point(12, 7)
        btnInicio.Name = "btnInicio"
        btnInicio.Size = New Size(38, 40)
        btnInicio.TabIndex = 10
        btnInicio.UseVisualStyleBackColor = False
        ' 
        ' frmAsistenciaEstu
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        AutoValidate = AutoValidate.Disable
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(406, 569)
        Controls.Add(btnInicio)
        Controls.Add(btnSalirEstu)
        Controls.Add(lstVwAsis)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmAsistenciaEstu"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Asistencias"
        ResumeLayout(False)
    End Sub
    Friend WithEvents lstVwAsis As ListView
    Friend WithEvents columnaFecha As ColumnHeader
    Friend WithEvents columnaAsis As ColumnHeader
    Friend WithEvents btnSalirEstu As Button
    Friend WithEvents btnInicio As Button
End Class
