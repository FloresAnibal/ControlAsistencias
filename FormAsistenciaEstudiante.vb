Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmAsistenciaEstu

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

                    'If estado = True Then
                    '    estadoString = "presente"
                    'Else
                    '    estadoString = "ausente"
                    'End If

                    Dim item As New ListViewItem({fecha, estadoString})

                    lstVwAsis.Items.Add(item)
                End While

                ' Cerrar el lector de datos y la conexión
                reader.Close()
                connection.Close()
            End Using
        End Using
    End Sub


    Private Sub btnSalirEstu_Click_1(sender As Object, e As EventArgs) Handles btnSalirEstu.Click
        modFunciones.SalirAplicacion()
    End Sub

    Private Sub btnSalirEstu_MouseHover(sender As Object, e As EventArgs) Handles btnSalirEstu.MouseHover
        ' Este evento se desencadena cuando el mouse entra en el área del botón
        ' Cambia la imagen de fondo del botón cuando el mouse está sobre él
        btnSalirEstu.BackgroundImage = My.Resources.apagarR_small
    End Sub

    Private Sub btnSalirAcceso_MouseLeave(sender As Object, e As EventArgs) Handles btnSalirEstu.MouseLeave
        ' Este evento se desencadena cuando el mouse sale del área del botón
        ' Restaura la imagen de fondo original del botón cuando el mouse sale de él
        btnSalirEstu.BackgroundImage = My.Resources.apagarN_small
    End Sub


End Class