<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaAsis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaAsis))
        dtGVCargaAsistencias = New DataGridView()
        idEstu = New DataGridViewTextBoxColumn()
        nombre = New DataGridViewTextBoxColumn()
        apellido = New DataGridViewTextBoxColumn()
        asistencia = New DataGridViewCheckBoxColumn()
        cmbBxCurso = New ComboBox()
        dtTPFechaAsistencia = New DateTimePicker()
        btnGuardarAsis = New Button()
        btnSalirAsis = New Button()
        btnInicio = New Button()
        CType(dtGVCargaAsistencias, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dtGVCargaAsistencias
        ' 
        dtGVCargaAsistencias.AllowUserToAddRows = False
        dtGVCargaAsistencias.AllowUserToDeleteRows = False
        dtGVCargaAsistencias.AllowUserToOrderColumns = True
        dtGVCargaAsistencias.Anchor = AnchorStyles.None
        dtGVCargaAsistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dtGVCargaAsistencias.Columns.AddRange(New DataGridViewColumn() {idEstu, nombre, apellido, asistencia})
        dtGVCargaAsistencias.Location = New Point(23, 51)
        dtGVCargaAsistencias.Name = "dtGVCargaAsistencias"
        dtGVCargaAsistencias.RowHeadersVisible = False
        dtGVCargaAsistencias.RowHeadersWidth = 51
        dtGVCargaAsistencias.RowTemplate.Height = 29
        dtGVCargaAsistencias.Size = New Size(515, 465)
        dtGVCargaAsistencias.TabIndex = 0
        ' 
        ' idEstu
        ' 
        idEstu.HeaderText = "IdEstu"
        idEstu.MinimumWidth = 6
        idEstu.Name = "idEstu"
        idEstu.Visible = False
        idEstu.Width = 125
        ' 
        ' nombre
        ' 
        nombre.HeaderText = "Nombre"
        nombre.MinimumWidth = 6
        nombre.Name = "nombre"
        nombre.ReadOnly = True
        nombre.Width = 180
        ' 
        ' apellido
        ' 
        apellido.HeaderText = "Apellido"
        apellido.MinimumWidth = 6
        apellido.Name = "apellido"
        apellido.ReadOnly = True
        apellido.Width = 180
        ' 
        ' asistencia
        ' 
        asistencia.HeaderText = "Asistencia"
        asistencia.MinimumWidth = 6
        asistencia.Name = "asistencia"
        asistencia.Resizable = DataGridViewTriState.True
        asistencia.SortMode = DataGridViewColumnSortMode.Automatic
        asistencia.Width = 112
        ' 
        ' cmbBxCurso
        ' 
        cmbBxCurso.FormattingEnabled = True
        cmbBxCurso.ItemHeight = 20
        cmbBxCurso.Location = New Point(840, 50)
        cmbBxCurso.Name = "cmbBxCurso"
        cmbBxCurso.Size = New Size(82, 28)
        cmbBxCurso.TabIndex = 2
        ' 
        ' dtTPFechaAsistencia
        ' 
        dtTPFechaAsistencia.Location = New Point(556, 51)
        dtTPFechaAsistencia.Name = "dtTPFechaAsistencia"
        dtTPFechaAsistencia.Size = New Size(269, 27)
        dtTPFechaAsistencia.TabIndex = 3
        ' 
        ' btnGuardarAsis
        ' 
        btnGuardarAsis.Location = New Point(677, 349)
        btnGuardarAsis.Name = "btnGuardarAsis"
        btnGuardarAsis.Size = New Size(180, 62)
        btnGuardarAsis.TabIndex = 4
        btnGuardarAsis.Text = "Guardar"
        btnGuardarAsis.UseVisualStyleBackColor = True
        ' 
        ' btnSalirAsis
        ' 
        btnSalirAsis.Anchor = AnchorStyles.None
        btnSalirAsis.BackColor = Color.Transparent
        btnSalirAsis.BackgroundImage = My.Resources.Resources.apagarN_small
        btnSalirAsis.BackgroundImageLayout = ImageLayout.Zoom
        btnSalirAsis.FlatAppearance.BorderSize = 0
        btnSalirAsis.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnSalirAsis.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnSalirAsis.FlatStyle = FlatStyle.Flat
        btnSalirAsis.Font = New Font("Calibri", 12F, FontStyle.Italic, GraphicsUnit.Point)
        btnSalirAsis.Location = New Point(947, 12)
        btnSalirAsis.Name = "btnSalirAsis"
        btnSalirAsis.Size = New Size(30, 30)
        btnSalirAsis.TabIndex = 9
        btnSalirAsis.UseVisualStyleBackColor = False
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
        btnInicio.Location = New Point(13, 7)
        btnInicio.Name = "btnInicio"
        btnInicio.Size = New Size(38, 40)
        btnInicio.TabIndex = 11
        btnInicio.UseVisualStyleBackColor = False
        ' 
        ' frmCargaAsis
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(991, 569)
        Controls.Add(btnInicio)
        Controls.Add(btnSalirAsis)
        Controls.Add(btnGuardarAsis)
        Controls.Add(dtTPFechaAsistencia)
        Controls.Add(cmbBxCurso)
        Controls.Add(dtGVCargaAsistencias)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmCargaAsis"
        Padding = New Padding(20)
        StartPosition = FormStartPosition.CenterScreen
        Text = "Carga de Asistencias"
        CType(dtGVCargaAsistencias, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dtGVCargaAsistencias As DataGridView
    Friend WithEvents cmbBxCurso As ComboBox
    Friend WithEvents dtTPFechaAsistencia As DateTimePicker
    Friend WithEvents btnGuardarAsis As Button
    Friend WithEvents idEstu As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents apellido As DataGridViewTextBoxColumn
    Friend WithEvents asistencia As DataGridViewCheckBoxColumn
    Friend WithEvents btnSalirAsis As Button
    Friend WithEvents btnInicio As Button
End Class
