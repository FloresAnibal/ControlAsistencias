Imports System.Data.OleDb

Public Class frmCargaDatos

    ' Array de tipo TextBox
    Dim campos() As TextBox

    Private Sub frmCargaDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carga del array con todos los TextBox del formulario. Para facilitar las validaciones
        campos = {txtBxNombres, txtBxApellido, txtBxDni, txtBxFechaNac, txtBxCorreo, txtBxTelefono, txtBxCalle, txtBxAltura}
    End Sub

    ' Configuración de la cadena de conexión
    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.16.0; 
                                          Data Source=E:\ISES\Programación Visual\Visual Studio\ProyectosControlAsistencias - copia\Base de Datos\BaseDatosAsistencias.accdb"

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        If btnNuevo.Text = "Nuevo" Then
            ' Cambiamos la leyenda del botón
            btnNuevo.Text = "Cancelar"

            ' Habilitamos todos los TextBox y el ComboBox
            HabilitarTodo()

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
                Dim sqlQuery As String = "INSERT INTO Estudiantes (nomb_estu, apell_estu, dni_estu, fecha_nac_estu, nro_tel_estu, email_estu, calle_estu, altura_calle_estu, id_curso) 
                                          VALUES (@Nom, @Ape, @Dni, @Nac, @Tel, @Cor, @Cal, @Alt, @Cur)"

                Using connection As New OleDbConnection(connectionString)

                    connection.Open()

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
                        ' Ejecutamos la consulta SQL
                        command.ExecuteNonQuery()
                    End Using
                End Using

                MsgBox("Los datos se registraron correctamente.", "Éxito")

                ' Vaciar los TextBox llamando al procedimiento que lo hará
                VaciarTodo()

                ' Cambaimos la leyenda del botón
                btnNuevo.Text = "Nuevo"
                ' Activamos/Desactivamos botones según el caso
                btnGuardarDatos.Enabled = False
                btnBuscar.Enabled = True

            Catch ex As Exception
                MsgBox("Error al registrar los datos: " & ex.Message) ' & ex.Message Muestra información acerca del error
            End Try

        Else
            MsgBox("No se permiten campos vacíos", "Aviso")
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        Using connection As New OleDbConnection(connectionString)
            connection.Open()

            If btnEditar.Text = "Editar" Then
                ' Cambiamos la leyenda del botón
                btnEditar.Text = "Actualizar"

                HabilitarTodo()
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

                    InhabilitarTodo()

                    VaciarTodo()

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

            Try
                Using connection As New OleDbConnection(connectionString)
                    connection.Open()

                    ' Consulta SQL para obtener los datos del estudiante por su DNI
                    Dim sqlQuery As String = "SELECT nomb_estu, apell_estu, fecha_nac_estu, nro_tel_estu, email_estu, calle_estu, altura_calle_estu, id_curso
                                              FROM Estudiantes WHERE dni_estu = @Dni"

                    Using command As New OleDbCommand(sqlQuery, connection)
                        command.Parameters.AddWithValue("@Dni", dni)

                        ' Crear un adaptador de datos y un DataTable
                        Dim adapter As New OleDbDataAdapter(command)
                        Dim dataTable As New DataTable()

                        ' Llenar el DataTable con los resultados de la consulta
                        adapter.Fill(dataTable)

                        ' Verificar si se encontraron datos. Se cuenta si hay filas, de haber significa que se encontraron resultados
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
        Else
            VaciarTodo()
            ' Cambaimos la leyenda del botón
            btnBuscar.Text = "Buscar"
            ' Activamos/Desactivamos botones según el caso
            btnEditar.Enabled = False
            btnEliminar.Enabled = False
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Using connection As New OleDbConnection(connectionString)
            connection.Open()

            HabilitarTodo()

            Try
                ' Consulta para realizar la eliminación
                Dim sqlQuery As String = "DELETE FROM Estudiantes WHERE dni_estu = @Dni"

                Using command As New OleDbCommand(sqlQuery, connection)
                    ' Asignar parámetro para la eliminación
                    command.Parameters.AddWithValue("@Dni", txtBxDni.Text)
                    ' Ejecutamos la consulta SQL
                    command.ExecuteNonQuery()
                End Using

                MsgBox("El estudiante se eliminó correctamente.", vbInformation)

                ' Deshabilitar todos los TextBox y vaciarlos
                InhabilitarTodo()
                VaciarTodo()

            Catch ex As Exception
                MsgBox("Error al eliminar al estudiante: " & ex.Message, vbCritical)
            End Try

        End Using
    End Sub


    '************- PROCEDIMIENTOS PARA VACIAR, HABILITAR E INHABILITAR TEXTBOX Y COMBOBOX-*****************
    Private Sub VaciarTodo()
        'Vaciar todos los TextBox
        For Each campo As TextBox In campos
            campo.Text = ""
        Next

        ' Se vacía el DataSource para poder limpiar el ComboBox
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

        ' Llamamos al procedimiento para cargar la lista de cursos
        modCursos.CargarCursos(cmbBxCargaCurso)
    End Sub

    Private Sub InhabilitarTodo()
        ' Bloquar todos los TextBox  
        For Each campo As TextBox In campos
            campo.Enabled = False
        Next

        ' Se vacía el DataSource para poder limpiar el ComboBox
        cmbBxCargaCurso.DataSource = Nothing
        ' Se vacia el ComboBox
        cmbBxCargaCurso.Items.Clear()
        ' Bloquear el ComboBox
        cmbBxCargaCurso.Enabled = False

    End Sub
    '****************************************************************************************************


    Private Sub txtBxNombres_TextChanged(sender As Object, e As EventArgs) Handles txtBxNombres.TextChanged
        busquedaPredictiva()
    End Sub



    '*******************************- COMPORTAMIENTO DEL BOTÓN SALIR -*******************************
    Private Sub btnSalirCargaDatos_Click(sender As Object, e As EventArgs) Handles btnSalirCargaDatos.Click
        ' Cierra la aplicación, finaliza todos los formularios y termina el proceso de la aplicación.
        Application.Exit()
    End Sub

    Private Sub btnSalirCargaDatos_MouseHover(sender As Object, e As EventArgs) Handles btnSalirCargaDatos.MouseHover
        ' Este evento se desencadena cuando el mouse entra en el área del botón
        ' Cambia la imagen de fondo del botón cuando el mouse está sobre él
        btnSalirCargaDatos.BackgroundImage = My.Resources.apagarR_small
    End Sub

    Private Sub btnSalirCargaDatos_MouseLeave(sender As Object, e As EventArgs) Handles btnSalirCargaDatos.MouseLeave
        ' Este evento se desencadena cuando el mouse sale del área del botón
        ' Restaura la imagen de fondo original del botón cuando el mouse sale de él
        btnSalirCargaDatos.BackgroundImage = My.Resources.apagarN_small
    End Sub

    '*************************************************************************************************


    '********************- COMPORTAMIENTO DE LOS CAMPOS PARA VALIDAR LAS ENTRADAS -********************
    Private Sub txtBxNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBxNombres.KeyPress
        ' Se llama al procedimiento que validará la entrada. Se envía la variable "e" que contiene el evento
        modValidaciones.soloLetras(e)
    End Sub

    Private Sub txtBxApellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBxApellido.KeyPress
        ' Se llama al procedimiento que validará la entrada. Se envía la variable "e" que contiene el evento
        modValidaciones.soloLetras(e)
    End Sub

    Private Sub txtBxFechaNac_Leave(sender As Object, e As EventArgs) Handles txtBxFechaNac.Leave
        ' El evento Leave se produce cuando el objeto pierde el foco
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
End Class

