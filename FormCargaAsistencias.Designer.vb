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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmCargaAsis))
        dtGVCargaAsistencias = New DataGridView()
        idEstu = New DataGridViewTextBoxColumn()
        nombre = New DataGridViewTextBoxColumn()
        apellido = New DataGridViewTextBoxColumn()
        asistencia = New DataGridViewCheckBoxColumn()
        cmbBxCurso = New ComboBox()
        dtTPFechaAsistencia = New DateTimePicker()
        btnGuardarAsis = New Button()
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
        dtGVCargaAsistencias.Location = New Point(453, 23)
        dtGVCargaAsistencias.Name = "dtGVCargaAsistencias"
        dtGVCargaAsistencias.RowHeadersVisible = False
        dtGVCargaAsistencias.RowHeadersWidth = 51
        dtGVCargaAsistencias.RowTemplate.Height = 29
        dtGVCargaAsistencias.Size = New Size(515, 555)
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
        cmbBxCurso.DisplayMember = "0"
        cmbBxCurso.FormattingEnabled = True
        cmbBxCurso.ItemHeight = 20
        cmbBxCurso.Location = New Point(342, 23)
        cmbBxCurso.Name = "cmbBxCurso"
        cmbBxCurso.Size = New Size(82, 28)
        cmbBxCurso.TabIndex = 2
        cmbBxCurso.Text = "Curso"
        cmbBxCurso.ValueMember = "0"
        ' 
        ' dtTPFechaAsistencia
        ' 
        dtTPFechaAsistencia.Location = New Point(34, 23)
        dtTPFechaAsistencia.Name = "dtTPFechaAsistencia"
        dtTPFechaAsistencia.Size = New Size(269, 27)
        dtTPFechaAsistencia.TabIndex = 3
        ' 
        ' btnGuardarAsis
        ' 
        btnGuardarAsis.Location = New Point(128, 333)
        btnGuardarAsis.Name = "btnGuardarAsis"
        btnGuardarAsis.Size = New Size(94, 29)
        btnGuardarAsis.TabIndex = 4
        btnGuardarAsis.Text = "Guardar"
        btnGuardarAsis.UseVisualStyleBackColor = True
        ' 
        ' frmCargaAsis
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(991, 601)
        Controls.Add(btnGuardarAsis)
        Controls.Add(dtTPFechaAsistencia)
        Controls.Add(cmbBxCurso)
        Controls.Add(dtGVCargaAsistencias)
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
End Class
