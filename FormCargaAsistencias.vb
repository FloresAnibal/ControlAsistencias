Imports System.Data.OleDb

Public Class frmCargaAsis

    ' La cadena de conexión a la base de datos de Access
    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source= E:\ISES\Programación Visual\Visual Studio\ProyectosControlAsistencias - copia\Base de Datos\BaseDatosAsistencias.accdb"

    Private Sub frmCargaAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar los cursos en el ComboBox desde la base de datos
        CargarComboBox()
    End Sub

    ' Evento que detecta un cambio en el valor del ComboBox
    Private Sub cmbBxCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBxCurso.SelectedIndexChanged

        ' Llamada al procedimiento que carga el DataGridView
        CargarDataGridView()

    End Sub

    Private Sub CargarComboBox()
        ' Limpiar el ComboBox
        cmbBxCurso.Items.Clear()

        ' Consulta SQL para obtener los cursos
        Dim sqlQuery As String = "SELECT id_curso, desc_curso FROM Cursos;"

        ' Crear la conexión a la base de datos
        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(sqlQuery, connection)

                ' Crear un adaptador de datos para obtener datos de la base de datos
                Dim adapter As New OleDbDataAdapter(command)

                ' Crear un nuevo DataTable para almacenar los datos
                Dim dataTable As New DataTable()

                ' Definir las columnas del DataTable
                dataTable.Columns.Add("id_curso", GetType(Integer))
                dataTable.Columns.Add("desc_curso", GetType(String))

                ' Agregar una fila al DataTable para mostrar "Cursos" como opción predeterminada en el ComboBox
                dataTable.Rows.Add(0, "Cursos")

                ' Abrir la conexión a la base de datos
                connection.Open()

                ' Llenar el DataTable con los resultados de la consulta
                adapter.Fill(dataTable)

                ' Cerrar la conexión a la base de datos
                connection.Close()

                ' Configurar el ComboBox para mostrar los datos del DataTable
                cmbBxCurso.DataSource = dataTable
                cmbBxCurso.DisplayMember = "desc_curso"
                cmbBxCurso.ValueMember = "id_curso"
            End Using
        End Using
    End Sub



    Private Sub CargarDataGridView()
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

                ' Insertar el nuevo registro en la tabla Asistencias
                InsertarAsistencia(connection, fechaSeleccionada, asistencia, idEstudiante, dniPreceptor)
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

    Private Sub InsertarAsistencia(connection As OleDbConnection, fecha As String, presente As Boolean, idEstudiante As Integer, dniPrece As Integer)
        'Consulta SQL para insertar un nuevo registro en la tabla Asistencias
        Dim sqlQuery As String = "INSERT INTO Asistencias (fecha_asis, estado_asis, id_estu, id_prece)
                                    SELECT @Fecha, @Presente, @ID_Estudiante, Preceptores.id_prece
                                    FROM Preceptores
                                    WHERE Preceptores.dni_prece = @DNI_Preceptor"
        'Esta consulta está insertando datos en la tabla "Asistencias," donde los valores de "fecha_asis",
        '"estado_asis", "id_estu", y "id_prece" se obtienen de las variables proporcionadas (@Fecha, @Presente, @ID_Estudiante)
        'y de la tabla "Preceptores" (específicamente, el valor de "id_prece" donde "dni_prece" coincide con @DNI_Preceptor).

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

    Private Sub btnSalirAsis_Click_1(sender As Object, e As EventArgs) Handles btnSalirAsis.Click
        modFunciones.SalirAplicacion()
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

End Class


'**************************************************************************************************************************

'INSERT INTO Asistencias (fecha_asis, estado_asis, id_estu, id_prece): Esto indica que se insertarán datos en
'la tabla "Asistencias" en las columnas "fecha_asis," "estado_asis," "id_estu," y "id_prece."

'SELECT @Fecha, @Presente, @ID_Estudiante, Preceptores.id_prece:Esta parte de la consulta está realizando una
'selección de datos.

'@Fecha, @Presente, y @ID_Estudiante son variables o parámetros que asignan valores a las columnas "fecha_asis".
'"estado_asis" y "id_estu" de la tabla "Asistencias".

'Preceptores.id_prece es una columna seleccionada de la tabla "Preceptores" y se asigna a la columna "id_prece"
'de la tabla "Asistencias."

'FROM Preceptores: Indica que los datos provienen de la tabla "Preceptores."

'WHERE Preceptores.dni_prece = @DNI_Preceptor: Esto filtra los resultados de la tabla "Preceptores" para que
'solo se seleccione la fila donde el valor de la columna "dni_prece" coincide con el valor de la variable @DNI_Preceptor

'****************************************************************************************************************************