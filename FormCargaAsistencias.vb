Imports System.Data.OleDb
Public Class frmCargaAsis

    ' La cadena de conexión a la base de datos de Access
    Private connectionString As String = modConexion.cadenaConexion

    Private Sub frmCargaAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargarse el formularios se cargan los cursos en el ComboBox desde la base de datos

        ' Para la carga se llama a la función alojada en un módulo y entre paréntesis se envía el ComboBox
        modCursos.CargarCursos(cmbBxCurso)
    End Sub

    ' Evento que detecta un cambio en el valor del ComboBox
    Private Sub cmbBxCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBxCurso.SelectedIndexChanged
        ' Al seleccionar un curso se carga el DataGridView

        ' Limpiar el DataGridView antes de mostrar nuevos datos
        dtGVCargaAsistencias.Rows.Clear()

        ' Obtener el ID del Curso seleccionado
        Dim idCurso As Integer = cmbBxCurso.SelectedIndex

        ' Consulta SQL para obtener los datos de estudiantes y asistencias
        Dim sqlQuery As String = "SELECT id_estu, nomb_estu, apell_estu 
                                  FROM Estudiantes 
                                  WHERE id_curso = @ID_Curso"

        ' Crear la conexión a la base de datos
        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(sqlQuery, connection)

                ' Agregar los parámetros
                command.Parameters.AddWithValue("@ID_Curso", idCurso)

                ' Crear un adaptador de datos
                Dim adapter As New OleDbDataAdapter(command)
                Dim dataTable As New DataTable()

                ' Abrir la conexión y llenar la tabla con los resultados
                connection.Open()
                adapter.Fill(dataTable)
                connection.Close()

                ' Mostrar los resultados en el DataGridView
                For Each row As DataRow In dataTable.Rows
                    ' Obtener los valores de id_estu, nomb_estu y apell_estu
                    Dim id As Integer = row("id_estu")
                    Dim nombre As String = row("nomb_estu").ToString()
                    Dim apellido As String = row("apell_estu").ToString()

                    ' Agregar una nueva fila al DataGridView y asignar los valores
                    dtGVCargaAsistencias.Rows.Add(id, nombre, apellido)

                Next

            End Using
        End Using
    End Sub


    Private Sub btnGuardarAsis_Click(sender As Object, e As EventArgs) Handles btnGuardarAsis.Click
        ' Obtener la fecha seleccionada
        Dim fechaSeleccionada As String = dtTPFechaAsistencia.Value.ToString("dd/MM/yyyy")
        Dim dniPreceptor As Integer = frmAcceso.txtBxUsuario.Text

        ' Crear la conexión a la base de datos
        Using connection As New OleDbConnection(connectionString)
            ' Abrir la conexión
            connection.Open()

            ' Iterar sobre las filas del DataGridView para guardar los registros en la tabla Asistencias
            For Each row As DataGridViewRow In dtGVCargaAsistencias.Rows
                Dim idEstudiante As Integer = Convert.ToInt32(row.Cells(0).Value)
                Dim asistencia As Boolean = Convert.ToBoolean(row.Cells(3).Value)

                ' Insertar el nuevo registro en la tabla Asistencias llamando al procedimiento encargado de ello
                InsertarAsistencia(connection, fechaSeleccionada, asistencia, idEstudiante, dniPreceptor)
                ' Entre paréntesis se envían las variables con los datos necesarios
            Next

            ' Cerrar la conexión
            connection.Close()
        End Using

        MessageBox.Show("Registros de asistencia guardados correctamente.")

        ' Limpiar el DataGridView
        dtGVCargaAsistencias.Rows.Clear()

        ' Limpiar el DataTimePicker
        dtTPFechaAsistencia.Value = DateTime.Now

        'Limpiar ComboBox
        cmbBxCurso.SelectedIndex = 0

    End Sub

    ' Procedimiento que guarda los datos de asistencia en la base de datos
    Private Sub InsertarAsistencia(connection As OleDbConnection, fecha As String, presente As Boolean, idEstudiante As Integer, dniPrece As Integer)

        'Consulta SQL para insertar un nuevo registro en la tabla Asistencias
        Dim sqlQuery As String = "INSERT INTO Asistencias (fecha_asis, estado_asis, id_estu, id_prece)
                                  SELECT @Fecha, @Presente, @ID_Estudiante, Preceptores.id_prece
                                  FROM Preceptores
                                  WHERE Preceptores.dni_prece = @DNI_Preceptor"

        ' Crear un nuevo comando
        Using command As New OleDbCommand(sqlQuery, connection)
            ' Agregar los parámetros para la fecha, estado, ID_Estudiante y dniPrece
            command.Parameters.AddWithValue("@Fecha", fecha)
            command.Parameters.AddWithValue("@Presente", presente)
            command.Parameters.AddWithValue("@ID_Estudiante", idEstudiante)
            command.Parameters.AddWithValue("@DNI_Preceptor", dniPrece)

            ' Ejecutar la consulta
            command.ExecuteNonQuery()
        End Using
    End Sub


    '*******************************- COMPORTAMIENTO DEL BOTÓN SALIR -*******************************
    Private Sub btnSalirAsis_Click(sender As Object, e As EventArgs) Handles btnSalirAsis.Click
        ' Cierra la aplicación, finaliza todos los formularios y termina el proceso de la aplicación.
        Application.Exit()
    End Sub

    Private Sub btnSalirAsis_MouseHover(sender As Object, e As EventArgs) Handles btnSalirAsis.MouseHover
        ' Este evento se desencadena cuando el mouse entra en el área del botón
        ' Cambia la imagen de fondo del botón cuando el mouse está sobre él
        btnSalirAsis.BackgroundImage = My.Resources.apagarR_small
    End Sub

    Private Sub btnSalirAsis_MouseLeave(sender As Object, e As EventArgs) Handles btnSalirAsis.MouseLeave
        ' Este evento se desencadena cuando el mouse sale del área del botón
        ' Restaura la imagen de fondo original del botón cuando el mouse sale de él
        btnSalirAsis.BackgroundImage = My.Resources.apagarN_small
    End Sub
    '*************************************************************************************************

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

End Class


'+++++++++++++++++++++++++++++++++++- DETALLES DE LA CONSULTA SQL -+++++++++++++++++++++++++++++++++++

' INSERT INTO Asistencias (fecha_asis, estado_asis, id_estu, id_prece):
' Esto indica que se insertarán datos en la tabla "Asistencias" en las columnas "fecha_asis", "estado_asis",
' "id_estu" y "id_prece."

' SELECT @Fecha, @Presente, @ID_Estudiante, Preceptores.id_prece:
' Esta parte de la consulta está realizando una selección de datos.

' @Fecha, @Presente, y @ID_Estudiante son variables o parámetros que asignan valores a las columnas "fecha_asis",
' "estado_asis" y "id_estu" de la tabla "Asistencias".

' Preceptores.id_prece es una columna seleccionada de la tabla "Preceptores" y se asigna a la columna "id_prece"
' de la tabla "Asistencias."

' FROM Preceptores:
' Indica que los datos provienen de la tabla "Preceptores."

' WHERE Preceptores.dni_prece = @DNI_Preceptor:
' Esto filtra los resultados de la tabla "Preceptores" para que solo se seleccione la fila donde el valor de la
' columna "dni_prece" coincide con el valor de la variable @DNI_Preceptor

'****************************************************************************************************************************