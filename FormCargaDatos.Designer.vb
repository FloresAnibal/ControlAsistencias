<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaDatos
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmCargaDatos))
        lblNombres = New Label()
        lblApellido = New Label()
        lblDni = New Label()
        lblFechaNac = New Label()
        lblCorreo = New Label()
        lblTelefono = New Label()
        lblAltura = New Label()
        lblCalle = New Label()
        txtBxNombres = New TextBox()
        txtBxApellido = New TextBox()
        txtBxDni = New TextBox()
        txtBxFechaNac = New TextBox()
        txtBxCorreo = New TextBox()
        txtBxTelefono = New TextBox()
        txtBxAltura = New TextBox()
        txtBxCalle = New TextBox()
        btnGuardarDatos = New Button()
        lblCargaEstu = New Label()
        btnNuevo = New Button()
        btnEditar = New Button()
        btnBuscar = New Button()
        btnEliminar = New Button()
        lstVwEstu = New ListView()
        nomb_estu = New ColumnHeader()
        SuspendLayout()
        ' 
        ' lblNombres
        ' 
        lblNombres.AutoSize = True
        lblNombres.BackColor = Color.Transparent
        lblNombres.Location = New Point(33, 176)
        lblNombres.Name = "lblNombres"
        lblNombres.Size = New Size(64, 20)
        lblNombres.TabIndex = 0
        lblNombres.Text = "Nombre"
        ' 
        ' lblApellido
        ' 
        lblApellido.AutoSize = True
        lblApellido.BackColor = Color.Transparent
        lblApellido.Location = New Point(33, 216)
        lblApellido.Name = "lblApellido"
        lblApellido.Size = New Size(66, 20)
        lblApellido.TabIndex = 1
        lblApellido.Text = "Apellido"
        ' 
        ' lblDni
        ' 
        lblDni.AutoSize = True
        lblDni.BackColor = Color.Transparent
        lblDni.Location = New Point(33, 315)
        lblDni.Name = "lblDni"
        lblDni.Size = New Size(166, 20)
        lblDni.TabIndex = 3
        lblDni.Text = "Número de Documento"
        ' 
        ' lblFechaNac
        ' 
        lblFechaNac.AutoSize = True
        lblFechaNac.BackColor = Color.Transparent
        lblFechaNac.Location = New Point(33, 264)
        lblFechaNac.Name = "lblFechaNac"
        lblFechaNac.Size = New Size(149, 20)
        lblFechaNac.TabIndex = 2
        lblFechaNac.Text = "Fecha de Nacimiento"
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.BackColor = Color.Transparent
        lblCorreo.Location = New Point(31, 540)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(52, 20)
        lblCorreo.TabIndex = 7
        lblCorreo.Text = "e-mail"
        ' 
        ' lblTelefono
        ' 
        lblTelefono.AutoSize = True
        lblTelefono.BackColor = Color.Transparent
        lblTelefono.Location = New Point(31, 492)
        lblTelefono.Name = "lblTelefono"
        lblTelefono.Size = New Size(146, 20)
        lblTelefono.TabIndex = 6
        lblTelefono.Text = "Número de Teléfono"
        ' 
        ' lblAltura
        ' 
        lblAltura.AutoSize = True
        lblAltura.BackColor = Color.Transparent
        lblAltura.Location = New Point(36, 433)
        lblAltura.Name = "lblAltura"
        lblAltura.Size = New Size(49, 20)
        lblAltura.TabIndex = 5
        lblAltura.Text = "Altura"
        ' 
        ' lblCalle
        ' 
        lblCalle.AutoSize = True
        lblCalle.BackColor = Color.Transparent
        lblCalle.Location = New Point(33, 380)
        lblCalle.Name = "lblCalle"
        lblCalle.Size = New Size(42, 20)
        lblCalle.TabIndex = 4
        lblCalle.Text = "Calle"
        ' 
        ' txtBxNombres
        ' 
        txtBxNombres.Location = New Point(115, 173)
        txtBxNombres.Name = "txtBxNombres"
        txtBxNombres.Size = New Size(215, 27)
        txtBxNombres.TabIndex = 8
        ' 
        ' txtBxApellido
        ' 
        txtBxApellido.Enabled = False
        txtBxApellido.Location = New Point(115, 213)
        txtBxApellido.Name = "txtBxApellido"
        txtBxApellido.Size = New Size(215, 27)
        txtBxApellido.TabIndex = 9
        ' 
        ' txtBxDni
        ' 
        txtBxDni.Location = New Point(205, 315)
        txtBxDni.Name = "txtBxDni"
        txtBxDni.Size = New Size(125, 27)
        txtBxDni.TabIndex = 11
        ' 
        ' txtBxFechaNac
        ' 
        txtBxFechaNac.Enabled = False
        txtBxFechaNac.Location = New Point(188, 261)
        txtBxFechaNac.Name = "txtBxFechaNac"
        txtBxFechaNac.Size = New Size(142, 27)
        txtBxFechaNac.TabIndex = 10
        ' 
        ' txtBxCorreo
        ' 
        txtBxCorreo.Enabled = False
        txtBxCorreo.Location = New Point(91, 537)
        txtBxCorreo.Name = "txtBxCorreo"
        txtBxCorreo.Size = New Size(237, 27)
        txtBxCorreo.TabIndex = 15
        ' 
        ' txtBxTelefono
        ' 
        txtBxTelefono.Enabled = False
        txtBxTelefono.Location = New Point(183, 492)
        txtBxTelefono.Name = "txtBxTelefono"
        txtBxTelefono.Size = New Size(145, 27)
        txtBxTelefono.TabIndex = 14
        ' 
        ' txtBxAltura
        ' 
        txtBxAltura.Enabled = False
        txtBxAltura.Location = New Point(91, 433)
        txtBxAltura.Name = "txtBxAltura"
        txtBxAltura.Size = New Size(125, 27)
        txtBxAltura.TabIndex = 13
        ' 
        ' txtBxCalle
        ' 
        txtBxCalle.Enabled = False
        txtBxCalle.Location = New Point(81, 377)
        txtBxCalle.Name = "txtBxCalle"
        txtBxCalle.Size = New Size(249, 27)
        txtBxCalle.TabIndex = 12
        ' 
        ' btnGuardarDatos
        ' 
        btnGuardarDatos.Enabled = False
        btnGuardarDatos.Location = New Point(31, 611)
        btnGuardarDatos.Name = "btnGuardarDatos"
        btnGuardarDatos.Size = New Size(94, 29)
        btnGuardarDatos.TabIndex = 18
        btnGuardarDatos.Text = "Guardar"
        btnGuardarDatos.UseVisualStyleBackColor = True
        ' 
        ' lblCargaEstu
        ' 
        lblCargaEstu.AutoSize = True
        lblCargaEstu.BackColor = Color.Transparent
        lblCargaEstu.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        lblCargaEstu.Location = New Point(202, 18)
        lblCargaEstu.Name = "lblCargaEstu"
        lblCargaEstu.Size = New Size(293, 41)
        lblCargaEstu.TabIndex = 19
        lblCargaEstu.Text = "Registro Estudiante"
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(33, 100)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(94, 29)
        btnNuevo.TabIndex = 20
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Enabled = False
        btnEditar.Location = New Point(136, 100)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(94, 29)
        btnEditar.TabIndex = 21
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Location = New Point(236, 100)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(94, 29)
        btnBuscar.TabIndex = 22
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Enabled = False
        btnEliminar.Location = New Point(231, 611)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(94, 29)
        btnEliminar.TabIndex = 23
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' lstVwEstu
        ' 
        lstVwEstu.Columns.AddRange(New ColumnHeader() {nomb_estu})
        lstVwEstu.Enabled = False
        lstVwEstu.Location = New Point(448, 173)
        lstVwEstu.Name = "lstVwEstu"
        lstVwEstu.Size = New Size(162, 346)
        lstVwEstu.TabIndex = 24
        lstVwEstu.UseCompatibleStateImageBehavior = False
        lstVwEstu.View = View.Details
        ' 
        ' nomb_estu
        ' 
        nomb_estu.Text = "Nombres"
        nomb_estu.Width = 150
        ' 
        ' frmCargaDatos
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(672, 679)
        Controls.Add(lstVwEstu)
        Controls.Add(btnEliminar)
        Controls.Add(btnBuscar)
        Controls.Add(btnEditar)
        Controls.Add(btnNuevo)
        Controls.Add(lblCargaEstu)
        Controls.Add(btnGuardarDatos)
        Controls.Add(txtBxCorreo)
        Controls.Add(txtBxTelefono)
        Controls.Add(txtBxAltura)
        Controls.Add(txtBxCalle)
        Controls.Add(txtBxDni)
        Controls.Add(txtBxFechaNac)
        Controls.Add(txtBxApellido)
        Controls.Add(txtBxNombres)
        Controls.Add(lblCorreo)
        Controls.Add(lblTelefono)
        Controls.Add(lblAltura)
        Controls.Add(lblCalle)
        Controls.Add(lblDni)
        Controls.Add(lblFechaNac)
        Controls.Add(lblApellido)
        Controls.Add(lblNombres)
        Name = "frmCargaDatos"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Carga de Datos"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNombres As Label
    Friend WithEvents lblApellido As Label
    Friend WithEvents lblDni As Label
    Friend WithEvents lblFechaNac As Label
    Friend WithEvents lblCorreo As Label
    Friend WithEvents lblTelefono As Label
    Friend WithEvents lblAltura As Label
    Friend WithEvents lblCalle As Label
    Friend WithEvents txtBxNombres As TextBox
    Friend WithEvents txtBxApellido As TextBox
    Friend WithEvents txtBxDni As TextBox
    Friend WithEvents txtBxFechaNac As TextBox
    Friend WithEvents txtBxCorreo As TextBox
    Friend WithEvents txtBxTelefono As TextBox
    Friend WithEvents txtBxAltura As TextBox
    Friend WithEvents txtBxCalle As TextBox
    Friend WithEvents btnGuardarDatos As Button
    Friend WithEvents lblCargaEstu As Label
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lstVwEstu As ListView
    Friend WithEvents nomb_estu As ColumnHeader
End Class
