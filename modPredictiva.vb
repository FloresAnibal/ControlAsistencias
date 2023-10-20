Imports System.Data.OleDb

Module modPredictiva

    ' Configuración de la cadena de conexión
    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.16.0; Data Source=E:\ISES\Programación Visual\Visual Studio\ProyectosControlAsistencias - copia\Base de Datos\BaseDatosAsistencias.accdb"

    Public Sub busquedaPredictiva()
        ' Verificar si el cuadro de texto está vacío
        If frmCargaDatos.txtBxNombres.Text = "" Then
            ' Ocultar el ListView
            frmCargaDatos.lstVwEstu.Visible = False
        Else
            Try
                ' Abrir la conexión a la base de datos utilizando la instrucción Using
                Using connection As New OleDbConnection(connectionString)
                    ' Abrimos la conexión
                    connection.Open()
                    ' Consulta SQL para seleccionar solo el campo nomb_estu que comienza con el texto ingresado
                    Dim sqlQuery As String = "SELECT nomb_estu FROM Estudiantes WHERE nomb_estu LIKE @NombreEstudiante"

                    ' Crear un adaptador de datos para ejecutar la consulta
                    Using Adapter As New OleDbDataAdapter(sqlQuery, connection)
                        ' Asignar el valor del parámetro @NombreEstudiante
                        Adapter.SelectCommand.Parameters.AddWithValue("@NombreEstudiante", frmCargaDatos.txtBxNombres.Text & "%")
                        ' Crear un DataTable para almacenar los resultados de la consulta
                        Dim dataTable As New DataTable()
                        ' Llenar el DataTable con los resultados de la consulta
                        Adapter.Fill(dataTable)

                        ' Verificar si se obtuvieron resultados
                        If dataTable.Rows.Count <> 0 Then
                            ' Mostrar el ListView
                            frmCargaDatos.lstVwEstu.Visible = True
                            ' Limpiar los elementos anteriores del ListView
                            frmCargaDatos.lstVwEstu.Items.Clear()

                            ' Agregar cada resultado al ListView
                            For Each row As DataRow In dataTable.Rows
                                frmCargaDatos.lstVwEstu.Items.Add(row("nomb_estu").ToString())
                            Next

                        Else
                            ' Ocultar el ListView si no hay resultados
                            frmCargaDatos.lstVwEstu.Visible = False
                        End If
                    End Using
                End Using

            Catch ex As Exception
                ' Mostrar mensaje de error si ocurre una excepción
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

End Module
