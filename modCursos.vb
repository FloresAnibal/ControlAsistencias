Imports System.Data.OleDb

Module modCursos

    ' Define la cadena de conexión en el módulo
    Private connectionString As String = modConexion.cadenaConexion

    ' Este procedimiento recibe un ComboBox
    Public Sub CargarCursos(ByRef cmbBox As ComboBox)
        ' Se vacía el DataSource para poder limpiar el ComboBox
        cmbBox.DataSource = Nothing
        ' Limpiar el ComboBox
        cmbBox.Items.Clear()

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
                cmbBox.DataSource = dataTable
                cmbBox.DisplayMember = "desc_curso"
                cmbBox.ValueMember = "id_curso"
            End Using
        End Using
    End Sub

End Module
