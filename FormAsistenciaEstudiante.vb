Imports System.Data.OleDb

Public Class frmAsistenciaEstu

    ' Cadena de conexión a la base de datos Access
    Private connectionString As String = modConexion.cadenaConexion

    Private Sub frmAsistenciaEstudiante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Limpiar el ListView antes de mostrar nuevos resultados
        lstVwAsis.Items.Clear()

        ' Obtener el DNI ingresado por el usuario que está alojado en el formulario de acceso
        Dim dni As String = frmAcceso.txtBxUsuario.Text

        ' Consulta SQL para obtener NOMBRE, FECHA y ESTADO para el estudiante con el DNI especificado
        Dim sqlQuery As String = "SELECT Estudiantes.nomb_estu, Asistencias.fecha_asis, Asistencias.estado_asis
                                  FROM Estudiantes 
                                  INNER JOIN Asistencias ON Estudiantes.id_estu = Asistencias.id_estu
                                  WHERE Estudiantes.dni_estu = @DNI;"

        ' Crear la conexión a la base de datos
        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(sqlQuery, connection)
                ' Agregar el parámetro para el DNI
                command.Parameters.AddWithValue("@DNI", dni)

                ' Abrir la conexión
                connection.Open()

                ' Crear un adaptador de datos
                Dim adapter As New OleDbDataAdapter(command)

                ' Crear un DataTable para almacenar los resultados
                Dim dataTable As New DataTable()

                ' Llenar el DataTable con los resultados de la consulta
                adapter.Fill(dataTable)

                ' Cerrar la conexión
                connection.Close()

                ' Iterar sobre los resultados del DataTable y agregarlos al ListView
                For Each row As DataRow In dataTable.Rows
                    ' Obtener la fecha y hora de la fila y convertirla a un objeto DateTime
                    Dim fechaHora As DateTime = Convert.ToDateTime(row("fecha_asis"))

                    ' Obtener solo la fecha en formato de cadena corta (sin la hora)
                    Dim fecha As String = fechaHora.ToShortDateString()

                    ' Obtener el estado de asistencia de la fila (true o false) y convertirlo a un valor booleano
                    Dim estado As Boolean = Convert.ToBoolean(row("estado_asis"))

                    ' Convertir el valor booleano del estado a una cadena "Presente" o "Ausente" según corresponda
                    Dim estadoString As String = If(estado, "Presente", "Ausente")

                    ' Crear un nuevo elemento de ListViewItem con la fecha y el estado en formato de cadena
                    Dim item As New ListViewItem({fecha, estadoString})

                    ' Agregar el elemento al ListView
                    lstVwAsis.Items.Add(item)
                Next

            End Using
        End Using
    End Sub



    '*******************************- COMPORTAMIENTO DEL BOTÓN SALIR -*******************************
    Private Sub btnSalirEstu_Click(sender As Object, e As EventArgs) Handles btnSalirEstu.Click
        ' Cierra la aplicación, finaliza todos los formularios y termina el proceso de la aplicación.
        Application.Exit
    End Sub

    Private Sub btnSalirEstu_MouseHover(sender As Object, e As EventArgs) Handles btnSalirEstu.MouseHover
        ' Este evento se desencadena cuando el mouse entra en el área del botón
        ' Cambia la imagen de fondo del botón cuando el mouse está sobre él
        btnSalirEstu.BackgroundImage = My.Resources.apagarR_small
    End Sub

    Private Sub btnSalirEstu_MouseLeave(sender As Object, e As EventArgs) Handles btnSalirEstu.MouseLeave
        ' Este evento se desencadena cuando el mouse sale del área del botón
        ' Restaura la imagen de fondo original del botón cuando el mouse sale de él
        btnSalirEstu.BackgroundImage = My.Resources.apagarN_small
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

    '*************************************************************************************************

End Class



'+++++++++++++++++++++++++++++++++++- DETALLES DE LA CONSULTA SQL -+++++++++++++++++++++++++++++++++++

' SELECT Estudiantes.nomb_estu, Asistencias.fecha_asis, Asistencias.estado_asis:
' Esta línea indica que la consulta seleccionará tres columnas de la base de datos. Estas columnas son
' nomb_estu de la tabla Estudiantes, y fecha_asis y estado_asis de la tabla Asistencias. La consulta devolverá
' estos datos en el resultado.

' FROM Estudiantes INNER JOIN Asistencias ON Estudiantes.id_estu = Asistencias.id_estu:
' En esta línea, se especifica que los datos provienen de dos tablas: Estudiantes y Asistencias. La palabra
' clave INNER JOIN indica que se realizará una unión interna entre estas dos tablas utilizando la condición de
' igualdad Estudiantes.id_estu = Asistencias.id_estu. Esto significa que la consulta combinará los registros
' donde el valor de id_estu en la tabla Estudiantes sea igual al valor de id_estu en la tabla Asistencias.

' WHERE Estudiantes.dni_estu = @DNI;:
' Esta línea establece una condición para filtrar los resultados de la consulta. Solo se seleccionarán los
' registros donde el valor de dni_estu en la tabla Estudiantes sea igual al valor proporcionado en el parámetro
' @DNI. En otras palabras, la consulta recuperará los datos de estudiantes y asistencias para un estudiante
' específico identificado por su número de identificación (dni_estu).

'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

'####################################- SENTENCIA IF SIMPLIFICADA -####################################

' La sentencia: If(estado, "Presente", "Ausente")

' Equivale a: If estado = True Then
'               estadoString = "presente"
'             Else
'               estadoString = "ausente"
'             End If

'#####################################################################################################