Imports System.Data.OleDb

Public Class frmAsistenciaEstudiante

    ' Cadena de conexión a la base de datos Access
    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source= E:\ISES\Programación Visual\Visual Studio\ProyectosControlAsistencias - copia\Base de Datos\BaseDatosAsistencias.accdb"

    Private Sub frmAsistenciaEstudiante_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Limpiar el ListView antes de mostrar nuevos resultados
        lstVwAsis.Items.Clear()

        ' Obtener el DNI ingresado por el usuario en el formulario de acceso
        Dim dni As String = frmAcceso.txtBxUsuario.Text

        ' Consulta SQL para obtener NOMBRE, FECHA y ESTADO para el estudiante con el DNI especificado
        Dim query As String = "SELECT Estudiantes.nomb_estu, Asistencias.fecha_asis, Asistencias.estado_asis
                               FROM Estudiantes INNER JOIN Asistencias ON Estudiantes.id_estu = Asistencias.id_estu
                               WHERE Estudiantes.dni_estu = @DNI;"

        ' Crear la conexión a la base de datos
        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                ' Agregar el parámetro para el DNI
                command.Parameters.AddWithValue("@DNI", dni)

                ' Abrir la conexión
                connection.Open()

                ' Ejecutar la consulta y obtener un lector de datos
                Dim reader As OleDbDataReader = command.ExecuteReader()

                ' Iterar sobre los resultados y agregarlos al ListView
                While reader.Read()
                    ' Utilizamos Convert.ToDateTime para convertir la cadena de fecha y hora en un objeto DateTime
                    Dim fechaHora As DateTime = Convert.ToDateTime(reader("fecha_asis"))

                    ' Usamos ToShortDateString para obtener solo la fecha en formato de cadena corta
                    Dim fecha As String = fechaHora.ToShortDateString()

                    ' Usamos Convert.ToBoolean para convertir la cadena en un valor Booleano
                    ' Para mostrar "Presente" si el estado es True y "Ausente" si el estado es False
                    Dim estado As Boolean = Convert.ToBoolean(reader("estado_asis"))

                    ' Convertir el estado booleano a una cadena "Presente" o "Ausente"
                    Dim estadoString As String = If(estado, "Presente", "Ausente")

                    Dim item As New ListViewItem({fecha, estadoString})

                    lstVwAsis.Items.Add(item)
                End While

                ' Cerrar el lector de datos y la conexión
                reader.Close()
                connection.Close()
            End Using
        End Using
    End Sub

    Private Sub SalirMenuAsis_Click(sender As Object, e As EventArgs) Handles SalirMenuAsis.Click
        ' Cierra la aplicación, finaliza todos los formularios y termina el proceso de la aplicación.
        Application.Exit()
    End Sub
End Class