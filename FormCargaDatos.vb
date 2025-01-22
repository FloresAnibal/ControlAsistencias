' Librerías importadas
Imports System.Data.OleDb   'Para acceder a bases de datos a través de OLE DB
Imports System.Drawing.Printing ' Para administrar tareas relacionadas con la impresión en aplicaciones

Public Class frmCargaDatos

    ' Declaramos una matriz de tipo TextBox
    Dim campos() As TextBox

    Private Sub frmCargaDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carga de la matriz con todos los TextBox del formulario. Para facilitar las validaciones
        campos = {txtBxNombres, txtBxApellido, txtBxDni, txtBxFechaNac, txtBxCorreo, txtBxTelefono, txtBxCalle, txtBxAltura}
    End Sub

    ' Configuración de la cadena de conexión
    Private connectionString As String = modConexion.cadenaConexion

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        If btnNuevo.Text = "Nuevo" Then
            ' Cambiamos la leyenda del botón
            btnNuevo.Text = "Cancelar"

            ' Habilitamos todos los TextBox y el ComboBox
            HabilitarTodo()

            ' Llamamos al procedimiento que está dentro de un MÓDULO para cargar la lista de cursos en el ComboBox
            modCursos.CargarCursos(cmbBxCargaCurso)

            ' Activamos/Desactivamos botones según el caso
            btnGuardarDatos.Enabled = True
            btnBuscar.Enabled = False

        Else
            ' Cambiamos la leyenda del botón
            btnNuevo.Text = "Nuevo"

            ' Vaciar los TextBox y el ComboBox llamando al procedimiento que lo hará 
            VaciarTodo()

            ' Bloqueamos todos los TextBox y el ComboBox
            InhabilitarTodo()

            txtBxDni.Enabled = True

            ' Activamos/Desactivamos botones según el caso
            btnGuardarDatos.Enabled = False
            btnEditar.Enabled = False
            btnBuscar.Enabled = True

        End If
    End Sub


    Private Sub btnGuardarDatos_Click(sender As Object, e As EventArgs) Handles btnGuardarDatos.Click
        ' Se llama a la función para validar los campos. Se pasa la variable "campos" que contiene todos los TextBox
        If modValidaciones.camposLlenos(campos) = True And cmbBxCargaCurso.SelectedIndex > 0 Then

            Try
                ' Creamos la variable que contendrá la consulta SQL que luego será ejecutada
                Dim sqlQuery As String = "INSERT INTO Estudiantes (nomb_estu, apell_estu, dni_estu, fecha_nac_estu, nro_tel_estu, email_estu, calle_estu, altura_calle_estu, id_curso) 
                                          VALUES (@Nom, @Ape, @Dni, @Nac, @Tel, @Cor, @Cal, @Alt, @Cur)"

                ' Crea una instancia de la clase OleDbConnection y la asignamos a la variable connection
                Using connection As New OleDbConnection(connectionString)   ' Using se utiliza para garantizar que la conexión se abra y se cierre correctamente

                    ' Abrir la conexión a la base de datos
                    connection.Open()

                    'Preparación para ejecutar comandos SQL en una base de datos utilizando la conexión OleDbConnection especificada. 
                    Using command As New OleDbCommand(sqlQuery, connection)
                        ' Asignar parámetros
                        command.Parameters.AddWithValue("@Nom", txtBxNombres.Text)
                        command.Parameters.AddWithValue("@Ape", txtBxApellido.Text)
                        command.Parameters.AddWithValue("@Dni", txtBxDni.Text)
                        command.Parameters.AddWithValue("@Nac", txtBxFechaNac.Text)
                        command.Parameters.AddWithValue("@Tel", txtBxTelefono.Text)
                        command.Parameters.AddWithValue("@Cor", txtBxCorreo.Text)
                        command.Parameters.AddWithValue("@Cal", txtBxCalle.Text)
                        command.Parameters.AddWithValue("@Alt", txtBxAltura.Text)
                        command.Parameters.AddWithValue("@Cur", cmbBxCargaCurso.SelectedIndex)
                        ' ' Ejecutar la consulta SQL que puede ser una inserción, actualización o eliminación de datos en la base de datos
                        command.ExecuteNonQuery()
                    End Using
                End Using

                ' Mensaje por pantalla
                MsgBox("Los datos se registraron correctamente.")

                ' Vaciar los TextBox llamando al procedimiento que lo hará
                VaciarTodo()

                ' Desactivar todos los campos
                InhabilitarTodo()

                txtBxDni.Enabled = True

                ' Cambiamos la leyenda del botón
                btnNuevo.Text = "Nuevo"

                ' Activamos/Desactivamos botones según el caso
                btnGuardarDatos.Enabled = False
                btnBuscar.Enabled = True

            Catch ex As Exception
                MsgBox("Error al registrar los datos: " & ex.Message) ' & ex.Message Muestra información acerca del error
            End Try

        Else
            ' Mensaje por pantalla si el IF de mas a rriba no se cumple
            MsgBox("No se permiten campos vacíos")
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        Using connection As New OleDbConnection(connectionString)
            connection.Open()

            If btnEditar.Text = "Editar" Then
                ' Cambiamos la leyenda del botón
                btnEditar.Text = "Actualizar"
                btnBuscar.Text = "Cancelar"

                HabilitarTodo()

                ' Activamos/Desactivamos botones según el caso
                btnImprimirAlum.Enabled = False
                btnEliminar.Enabled = False

            Else
                Try
                    ' Preparamos la consulta para la actualización
                    Dim sqlQuery As String = "UPDATE Estudiantes 
                                              SET nomb_estu = @Nom, apell_estu = @Ape, dni_estu = @Dni, fecha_nac_estu = @Fech, nro_tel_estu = @Tel, email_estu = @Mail, calle_estu = @Calle, altura_calle_estu = @Altu, id_curso = @Cur
                                              WHERE dni_estu = @Dni"

                    Using command As New OleDbCommand(sqlQuery, connection)
                        ' Asignar parámetros para consulta SQL
                        command.Parameters.AddWithValue("@Nom", txtBxNombres.Text)
                        command.Parameters.AddWithValue("@Ape", txtBxApellido.Text)
                        command.Parameters.AddWithValue("@Dni", txtBxDni.Text)
                        command.Parameters.AddWithValue("@Fech", txtBxFechaNac.Text)
                        command.Parameters.AddWithValue("@Tel", txtBxTelefono.Text)
                        command.Parameters.AddWithValue("@Mail", txtBxCorreo.Text)
                        command.Parameters.AddWithValue("@Calle", txtBxCalle.Text)
                        command.Parameters.AddWithValue("@Altu", txtBxAltura.Text)
                        command.Parameters.AddWithValue("@Altu", cmbBxCargaCurso.SelectedIndex)
                        ' Ejecutamos la consulta SQL
                        command.ExecuteNonQuery()
                    End Using

                    MsgBox("Los datos se actualizaron correctamente.", vbInformation)

                    ' Cambiamos la leyenda de los botones
                    btnEditar.Text = "Editar"
                    btnBuscar.Text = "Buscar"
                    ' Activamos/Desactivamos botones según el caso
                    btnEditar.Enabled = False
                    btnNuevo.Enabled = True
                    btnEliminar.Enabled = False

                    VaciarTodo()

                    InhabilitarTodo()

                    txtBxDni.Enabled = True

                Catch ex As Exception
                    MsgBox("Error al actualizar los datos del estudiante: " & ex.Message, vbCritical)
                End Try
            End If
        End Using
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ' Cambiamos la leyenda del botón
        If btnBuscar.Text = "Buscar" Then

            ' Activamos/Desactivamos botones según el caso
            btnNuevo.Enabled = False
            btnEditar.Enabled = True

            ' Cargamos el contenido del TextBox para realizar la búsqueda por número de documento
            Dim dni As String = txtBxDni.Text

            Try 'permite controlar lo que sucede cuando se produce un error en el código

                Using connection As New OleDbConnection(connectionString)
                    connection.Open()

                    ' Consulta SQL para obtener los datos del estudiante por su DNI
                    Dim sqlQuery As String = "SELECT nomb_estu, apell_estu, fecha_nac_estu, nro_tel_estu, email_estu, calle_estu, altura_calle_estu, id_curso
                                              FROM Estudiantes WHERE dni_estu = @Dni"

                    Using command As New OleDbCommand(sqlQuery, connection)
                        command.Parameters.AddWithValue("@Dni", dni)

                        ' Crear un adaptador de datos y un DataTable
                        Dim adapter As New OleDbDataAdapter(command)    ' Actúa como intermediario entre la aplicación y la fuente de datos
                        Dim dataTable As New DataTable()    ' Almacena y manipula datos de manera similar a una tabla de Ecxel. 

                        ' Llenar el DataTable con los resultados de la consulta
                        adapter.Fill(dataTable)

                        ' Verificar si se encontraron datos. Se cuenta si hay filas cargadas, de haber significa que se encontraron resultados
                        If dataTable.Rows.Count > 0 Then
                            ' Asignar los valores a los TextBox correspondientes
                            Dim row As DataRow = dataTable.Rows(0)
                            txtBxNombres.Text = row("nomb_estu").ToString()
                            txtBxApellido.Text = row("apell_estu").ToString()
                            txtBxFechaNac.Text = Convert.ToDateTime(row("fecha_nac_estu")).ToShortDateString()
                            txtBxTelefono.Text = row("nro_tel_estu").ToString()
                            txtBxCorreo.Text = row("email_estu").ToString()
                            txtBxCalle.Text = row("calle_estu").ToString()
                            txtBxAltura.Text = row("altura_calle_estu").ToString()

                            ' Llamamos al procedimiento para cargar la lista de cursos
                            modCursos.CargarCursos(cmbBxCargaCurso)

                            ' Tomamos el valor de id_curso para que el ComboBox muestre el curso correspodiente
                            cmbBxCargaCurso.SelectedIndex = row("id_curso").ToString()

                        Else
                            MsgBox("No se encontraron datos para el DNI proporcionado.")
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MsgBox("Error al obtener datos del estudiante: " & ex.Message)
            End Try

            ' Cambaimos la leyenda del botón
            btnBuscar.Text = "Limpiar"

            ' Activamos/Desactivamos botones según el caso
            btnEliminar.Enabled = True
            btnImprimirAlum.Enabled = True

        Else

            VaciarTodo()
            InhabilitarTodo()

            txtBxDni.Enabled = True

            ' Cambaimos la leyenda del botón
            btnBuscar.Text = "Buscar"

            ' Activamos/Desactivamos botones según el caso
            btnEditar.Enabled = False
            btnEliminar.Enabled = False
            btnNuevo.Enabled = True
            btnImprimirAlum.Enabled = False

        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Using connection As New OleDbConnection(connectionString)
            connection.Open()

            Try
                ' Consulta para realizar la eliminación
                Dim sqlQuery As String = "DELETE FROM Estudiantes WHERE dni_estu = @Dni"

                Using command As New OleDbCommand(sqlQuery, connection)
                    ' Asignar parámetro para la eliminación
                    command.Parameters.AddWithValue("@Dni", txtBxDni.Text)
                    ' Ejecutamos la consulta SQL
                    command.ExecuteNonQuery()
                End Using

                MsgBox("El estudiante se eliminó correctamente.")

                ' Vaciar todos los campos
                VaciarTodo()

                ' Deshabilitar todos los TextBox y vaciarlos
                InhabilitarTodo()

                txtBxDni.Enabled = True

                ' Activamos/Desactivamos botones según el caso
                btnNuevo.Enabled = True
                btnEditar.Enabled = False
                btnEliminar.Enabled = False
                btnImprimirAlum.Enabled = False

                ' Cambiamos la leyenda del botón
                btnBuscar.Text = "Buscar"

            Catch ex As Exception
                MsgBox("Error al eliminar al estudiante: " & ex.Message)
            End Try

        End Using
    End Sub

    '**************- MODIFICACION PARA ELIMINAR ASISTENCIAS -**********************************************

    'Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    '    Using connection As New OleDbConnection(connectionString)
    '        connection.Open()

    '        Try
    '            ' Consulta para obtener el id_estu del estudiante
    '            Dim sqlQueryIdEstu As String = "SELECT id_estu FROM Estudiantes WHERE dni = @Dni"

    '            Using commandIdEstu As New OleDbCommand(sqlQueryIdEstu, connection)
    '                commandIdEstu.Parameters.AddWithValue("@Dni", txtBxDni.Text)
    '                Dim idEstu As Object = commandIdEstu.ExecuteScalar()

    '                If Not IsDBNull(idEstu) Then
    '                    ' Consulta para eliminar las asistencias del estudiante
    '                    Dim sqlQueryAsistencia As String = "DELETE FROM ASISTENCIAS WHERE id_estu = @id_estu"

    '                    Using commandAsistencia As New OleDbCommand(sqlQueryAsistencia, connection)
    '                        commandAsistencia.Parameters.AddWithValue("@id_estu", idEstu)
    '                        commandAsistencia.ExecuteNonQuery()
    '                    End Using

    '                    ' Consulta para realizar la eliminación del estudiante
    '                    Dim sqlQueryEstudiante As String = "DELETE FROM Estudiantes WHERE dni = @Dni"

    '                    Using commandEstudiante As New OleDbCommand(sqlQueryEstudiante, connection)
    '                        commandEstudiante.Parameters.AddWithValue("@Dni", txtBxDni.Text)
    '                        commandEstudiante.ExecuteNonQuery()
    '                    End Using

    '                    MsgBox("El estudiante y sus asistencias se eliminaron correctamente.")

    '                Else
    '                    MsgBox("No se encontró un estudiante con el DNI proporcionado.")
    '                End If
    '            End Using

    '            ' Vaciar todos los campos
    '            VaciarTodo()

    '            ' Deshabilitar todos los TextBox y vaciarlos
    '            InhabilitarTodo()

    '            txtBxDni.Enabled = True

    '            ' Activamos/Desactivamos botones según el caso
    '            btnNuevo.Enabled = True
    '            btnEditar.Enabled = False
    '            btnEliminar.Enabled = False
    '            btnImprimirAlum.Enabled = False

    '        Catch ex As Exception
    '            MsgBox("Error al eliminar al estudiante: " & ex.Message)
    '        End Try

    '    End Using
    'End Sub

    '*****************************************************************************************************


    '************- PROCEDIMIENTOS PARA VACIAR, HABILITAR E INHABILITAR TEXTBOX Y COMBOBOX-*****************

    Private Sub VaciarTodo()
        'Vaciar todos los TextBox
        For Each campo As TextBox In campos
            campo.Text = ""
        Next

        ' Se vacía el elemento DataSource para poder limpiar el ComboBox
        cmbBxCargaCurso.DataSource = Nothing

        ' Se vacia el ComboBox
        cmbBxCargaCurso.Items.Clear()
    End Sub

    Private Sub HabilitarTodo()
        ' Habilitar todos los TextBox  
        For Each campo As TextBox In campos
            campo.Enabled = True
        Next

        ' Habilitar el ComboBox
        cmbBxCargaCurso.Enabled = True

    End Sub

    Private Sub InhabilitarTodo()
        ' Bloquar todos los TextBox  
        For Each campo As TextBox In campos
            campo.Enabled = False
        Next

        ' Se vacía el elemento DataSource para poder limpiar el ComboBox
        cmbBxCargaCurso.DataSource = Nothing

        ' Se vacia el ComboBox
        cmbBxCargaCurso.Items.Clear()

        ' Bloquear el ComboBox
        cmbBxCargaCurso.Enabled = False

    End Sub
    '****************************************************************************************************


    '*********************************- COMPORTAMIENTO DEL BOTÓN SALIR -*********************************

    ' Evento que se activa cuando hacemos clic
    Private Sub btnSalirCargaDatos_Click(sender As Object, e As EventArgs) Handles btnSalirCargaDatos.Click
        ' Cierra la aplicación, finaliza todos los formularios y termina el proceso de la aplicación.
        Application.Exit()
    End Sub

    ' Evento que se activa cuando el mouse está encima del objeto
    Private Sub btnSalirCargaDatos_MouseHover(sender As Object, e As EventArgs) Handles btnSalirCargaDatos.MouseHover
        ' Este evento se desencadena cuando el mouse entra en el área del botón

        ' Cambia la imagen de fondo del botón cuando el mouse está sobre él
        btnSalirCargaDatos.BackgroundImage = My.Resources.apagarR_small
    End Sub

    ' Evento que se activa cuando el mouse no está encima del objeto
    Private Sub btnSalirCargaDatos_MouseLeave(sender As Object, e As EventArgs) Handles btnSalirCargaDatos.MouseLeave
        ' Este evento se desencadena cuando el mouse sale del área del botón

        ' Restaura la imagen de fondo original del botón cuando el mouse sale de él
        btnSalirCargaDatos.BackgroundImage = My.Resources.apagarN_small
    End Sub

    '**************************************************************************************************

    '*******************************- COMPORTAMIENTO DEL BOTÓN INICIO -*******************************
    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        'Cierro el formulario actual
        Me.Close()
        'Abro el forulario de Inicio
        frmAcceso.Show()
    End Sub

    Private Sub btnInicio_MouseHover(sender As Object, e As EventArgs) Handles btnInicio.MouseHover
        ' Este evento se desencadena cuando el mouse entra en el área del botón
        ' Cambia la imagen de fondo del botón cuando el mouse está sobre él
        btnInicio.BackgroundImage = My.Resources.homeA_small
    End Sub

    Private Sub btnInicio_MouseLeave(sender As Object, e As EventArgs) Handles btnInicio.MouseLeave
        ' Este evento se desencadena cuando el mouse sale del área del botón
        ' Restaura la imagen de fondo original del botón cuando el mouse sale de él
        btnInicio.BackgroundImage = My.Resources.homeN_small
    End Sub

    '************************************************************************


    '********************- COMPORTAMIENTO DE LOS CAMPOS PARA VALIDAR LAS ENTRADAS -********************
    ' Todas las validaciones se encuentran en un MÓDULO

    ' Evento que se activa cuando presionamos una tecla dentro del objeto
    Private Sub txtBxNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBxNombres.KeyPress
        ' Se llama al procedimiento que validará la entrada. Se envía la variable "e" que contiene el evento
        modValidaciones.soloLetras(e)
    End Sub

    Private Sub txtBxApellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBxApellido.KeyPress
        ' Se llama al procedimiento que validará la entrada. Se envía la variable "e" que contiene el evento
        modValidaciones.soloLetras(e)
    End Sub

    Private Sub txtBxFechaNac_Leave(sender As Object, e As EventArgs) Handles txtBxFechaNac.Leave
        ' Se llama al procedimiento que validará la entrada. Se envía el TextBox para analizar su contenido
        modValidaciones.soloFecha(txtBxFechaNac)
    End Sub

    Private Sub txtBxDni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBxDni.KeyPress
        ' Se llama al procedimiento que validará la entrada. Se envía la variable "e" que contiene el evento
        modValidaciones.soloNumeros(e)
    End Sub

    Private Sub txtBxAltura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBxAltura.KeyPress
        ' Se llama al procedimiento que validará la entrada. Se envía la variable "e" que contiene el evento
        modValidaciones.soloNumeros(e)
    End Sub

    Private Sub txtBxTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBxTelefono.KeyPress
        ' Se llama al procedimiento que validará la entrada. Se envía la variable "e" que contiene el evento
        modValidaciones.soloNumeros(e)
    End Sub

    Private Sub txtBxCorreo_Leave(sender As Object, e As EventArgs) Handles txtBxCorreo.Leave
        ' El evento Leave se produce cuando el objeto pierde el foco
        ' Se llama al procedimiento que validará la entrada. Se envía el TextBox para analizar su contenido
        modValidaciones.soloMail(txtBxCorreo)
    End Sub
    '*************************************************************************************************


    '000000000000000000000000000000000000- IMPRESIÓN 1 Alumno -000000000000000000000000000000000000000000000000

    Private Sub btnImprimirAlum_Click(sender As Object, e As EventArgs) Handles btnImprimirAlum.Click
        ' Crear un objeto PrintDocument para administrar la impresión
        Dim printDocument As New PrintDocument()

        ' Agregar un manejador de evento para el evento PrintPage, que se ejecuta cuando se realiza la impresión
        AddHandler printDocument.PrintPage, AddressOf ImprimirContenido

        ' Crear un cuadro de diálogo de vista previa de impresión
        Dim printPreviewDialog As New PrintPreviewDialog()
        ' Crear un cuadro de diálogo de impresión
        Dim printdialog As New PrintDialog()

        ' Asignar el objeto PrintDocument al cuadro de diálogo de vista previa
        printPreviewDialog.Document = printDocument

        ' Mostrar el cuadro de diálogo de vista previa de impresión y verificar si el usuario hizo clic en "OK"

        ' Iniciar la impresión del documento
        If printdialog.ShowDialog() = DialogResult.OK Then
            If printPreviewDialog.ShowDialog() = DialogResult.OK Then
                printDocument.Print()
            End If
        End If
    End Sub

    Private Sub ImprimirContenido(sender As Object, e As PrintPageEventArgs)
        ' Definir las fuentes y pinceles
        Dim fontTitulo As New Font("Arial", 14, FontStyle.Bold)
        Dim fontEncabezado As New Font("Arial", 12, FontStyle.Bold)
        Dim fontContenido As New Font("Arial", 9, FontStyle.Regular)
        Dim brushNegro As New SolidBrush(Color.Black)

        ' Posiciones iniciales
        Dim y As Single = e.MarginBounds.Top
        Dim xTitulo As Single = e.MarginBounds.Left + 100
        Dim xContenido As Single = e.MarginBounds.Left

        ' Título
        e.Graphics.DrawString("Información del Estudiante", fontTitulo, brushNegro, xTitulo, y)
        y += fontTitulo.GetHeight()

        y += 20 ' Añade 20 unidades de espacio entre el título y el contenido

        ' Contenido de TextBox
        e.Graphics.DrawString("Nombres: " & txtBxNombres.Text, fontEncabezado, brushNegro, xContenido, y)
        y += fontEncabezado.GetHeight()

        e.Graphics.DrawString("Apellido: " & txtBxApellido.Text, fontEncabezado, brushNegro, xContenido, y)
        y += fontEncabezado.GetHeight()

        e.Graphics.DrawString("Fecha de Nacimiento: " & txtBxFechaNac.Text, fontEncabezado, brushNegro, xContenido, y)
        y += fontEncabezado.GetHeight()

        e.Graphics.DrawString("DNI: " & txtBxDni.Text, fontEncabezado, brushNegro, xContenido, y)
        y += fontEncabezado.GetHeight()

        e.Graphics.DrawString("Teléfono: " & txtBxTelefono.Text, fontEncabezado, brushNegro, xContenido, y)
        y += fontEncabezado.GetHeight()

        e.Graphics.DrawString("E-mail: " & txtBxCorreo.Text, fontEncabezado, brushNegro, xContenido, y)
        y += fontEncabezado.GetHeight()

        e.Graphics.DrawString("Dirección: " & txtBxCalle.Text & " N° " & txtBxAltura.Text, fontEncabezado, brushNegro, xContenido, y)
        y += fontEncabezado.GetHeight()


        ' Manejar salto de página si es necesario
        If y + fontContenido.GetHeight() > e.MarginBounds.Bottom Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

End Class

