<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsistenciaEstudiante
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmAsistenciaEstudiante))
        lstVwAsis = New ListView()
        columnaFecha = New ColumnHeader()
        columnaAsis = New ColumnHeader()
        menuAsis = New MenuStrip()
        SalirMenuAsis = New ToolStripMenuItem()
        menuAsis.SuspendLayout()
        SuspendLayout()
        ' 
        ' lstVwAsis
        ' 
        lstVwAsis.Columns.AddRange(New ColumnHeader() {columnaFecha, columnaAsis})
        lstVwAsis.Location = New Point(41, 83)
        lstVwAsis.Name = "lstVwAsis"
        lstVwAsis.Size = New Size(243, 328)
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
        ' menuAsis
        ' 
        menuAsis.ImageScalingSize = New Size(20, 20)
        menuAsis.Items.AddRange(New ToolStripItem() {SalirMenuAsis})
        menuAsis.Location = New Point(0, 0)
        menuAsis.Name = "menuAsis"
        menuAsis.Size = New Size(484, 36)
        menuAsis.TabIndex = 9
        menuAsis.Text = "MenuStrip1"
        ' 
        ' SalirMenuAsis
        ' 
        SalirMenuAsis.Alignment = ToolStripItemAlignment.Right
        SalirMenuAsis.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        SalirMenuAsis.Name = "SalirMenuAsis"
        SalirMenuAsis.Size = New Size(64, 32)
        SalirMenuAsis.Text = "Salir"
        ' 
        ' frmAsistenciaEstudiante
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        AutoValidate = AutoValidate.Disable
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(484, 493)
        Controls.Add(lstVwAsis)
        Controls.Add(menuAsis)
        MainMenuStrip = menuAsis
        Name = "frmAsistenciaEstudiante"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Asistencias"
        menuAsis.ResumeLayout(False)
        menuAsis.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lstVwAsis As ListView
    Friend WithEvents columnaFecha As ColumnHeader
    Friend WithEvents columnaAsis As ColumnHeader
    Friend WithEvents menuAsis As MenuStrip
    Friend WithEvents SalirMenuAsis As ToolStripMenuItem
End Class
